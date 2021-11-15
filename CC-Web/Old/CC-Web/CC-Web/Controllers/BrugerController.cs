using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CC_Web.Models.CC_DbContext;
using CC_Web.Models.Data;

namespace CC_Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrugerController : ControllerBase
    {
        private readonly CC_DbContext _context;

        public BrugerController(CC_DbContext context)
        {
            _context = context;
        }

        // GET: api/Bruger
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bruger>>> Getbrugere()
        {
            return await _context.brugere.ToListAsync();
        }

        // GET: api/Bruger/5
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

        // PUT: api/Bruger/5
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

        // POST: api/Bruger
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Bruger>> PostBruger(Bruger bruger)
        {
            _context.brugere.Add(bruger);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBruger", new { id = bruger.BrugerID }, bruger);
        }

        // DELETE: api/Bruger/5
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
