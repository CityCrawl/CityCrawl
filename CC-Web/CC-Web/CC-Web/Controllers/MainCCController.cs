using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CC_Web.Data;
using CC_Web.Models.Data;

namespace CC_Web.Controllers
{
    public class MainCCController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MainCCController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MainCC
        public async Task<IActionResult> Index()
        {
            return View(await _context.virksomheder.ToListAsync());
        }

        // GET: MainCC/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var virksomhed = await _context.virksomheder
                .FirstOrDefaultAsync(m => m.VirksomhedID == id);
            if (virksomhed == null)
            {
                return NotFound();
            }

            return View(virksomhed);
        }

        // GET: Profil

        public async Task<IActionResult> Profil(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var virksomhed = await _context.virksomheder
                .FirstOrDefaultAsync(m => m.Virksomhedsnavn == id);
            if (virksomhed == null)
            {
                return NotFound();
            }

            return View(virksomhed);
        }

        // GET: Welcome

        public IActionResult Welcome()
        {
            return View();
        }

        // Post beskrivelse



        // GET: MainCC/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MainCC/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VirksomhedID,CVR,Virksomhedsnavn,KontaktPerson,Email,Password")] Virksomhed virksomhed)
        {
            if (ModelState.IsValid)
            {
                _context.Add(virksomhed);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(virksomhed);
        }

        // GET: MainCC/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var virksomhed = await _context.virksomheder.FindAsync(id);
            if (virksomhed == null)
            {
                return NotFound();
            }
            return View(virksomhed);
        }

        // POST: MainCC/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VirksomhedID,CVR,Virksomhedsnavn,KontaktPerson,Email,Password")] Virksomhed virksomhed)
        {
            if (id != virksomhed.VirksomhedID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(virksomhed);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VirksomhedExists(virksomhed.VirksomhedID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(virksomhed);
        }

        // GET: MainCC/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var virksomhed = await _context.virksomheder
                .FirstOrDefaultAsync(m => m.VirksomhedID == id);
            if (virksomhed == null)
            {
                return NotFound();
            }

            return View(virksomhed);
        }

        // POST: MainCC/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var virksomhed = await _context.virksomheder.FindAsync(id);
            _context.virksomheder.Remove(virksomhed);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VirksomhedExists(int id)
        {
            return _context.virksomheder.Any(e => e.VirksomhedID == id);
        }
    }
}
