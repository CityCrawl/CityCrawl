using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CC_Web.Data;
using CC_Web.Models.Data;

namespace CC_Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bruger>>> Getbrugere(string email, string password)
        {
            //Validere om email og password findes i databasen for Bruger
            var bruger = await _context.brugere
                .FirstOrDefaultAsync(m => m.Email == email && m.Password == password);
            if(bruger.Email != email)
            {
                throw new Exception("The user does not exist in CC-database");
            }
            if(bruger.Password != password)
            {
                throw new Exception("Incorrect user password");
            }

            return await _context.brugere.ToListAsync();
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bruger>> GetBruger(int id)
        {
            var bruger = await _context.brugere.FindAsync(id);

            if (bruger == null)
            {
                return NotFound();
            }

            return bruger;
        }

        // PUT: api/User/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBruger(int id, Bruger bruger)
        {
            if (id != bruger.BrugerID)
            {
                return BadRequest();
            }

            _context.Entry(bruger).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BrugerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/User
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("User")]
        public async Task<ActionResult<Bruger>> CreateBruger(Bruger bruger)
        {
            _context.brugere.Add(bruger);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBruger", new { id = bruger.BrugerID }, bruger);
        }

        // POST: api/Pubcrawls
        [HttpPost("Pubcrawl")]
        public async Task<ActionResult<Bruger>> CreatePubcrawl(Bruger bruger) //Denne kan ikke laves færdig før vi har styr på listerne
        {
            _context.brugere.Add(bruger);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPubcrawl", new { id = bruger.BrugerID }, bruger);
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBruger(int id)
        {
            var bruger = await _context.brugere.FindAsync(id);
            if (bruger == null)
            {
                return NotFound();
            }

            _context.brugere.Remove(bruger);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BrugerExists(int id)
        {
            return _context.brugere.Any(e => e.BrugerID == id);
        }
    }
}
