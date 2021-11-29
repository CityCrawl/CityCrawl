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
    public class CityCrawlsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly 

        public CityCrawlsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CityCrawls
        public async Task<IActionResult> Index()
        {
            return View(await _context.cityCrawls.ToListAsync());
        }

        // GET: CityCrawls/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cityCrawl = await _context.cityCrawls
                .FirstOrDefaultAsync(m => m.CityCrawlID == id);
            if (cityCrawl == null)
            {
                return NotFound();
            }

            return View(cityCrawl);
        }

        // GET: CityCrawls/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CityCrawls/Create
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

        // GET: CityCrawls/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cityCrawl = await _context.cityCrawls.FindAsync(id);
            if (cityCrawl == null)
            {
                return NotFound();
            }
            return View(cityCrawl);
        }

        // POST: CityCrawls/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CityCrawlID")] CityCrawl cityCrawl)
        {
            if (id != cityCrawl.CityCrawlID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cityCrawl);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CityCrawlExists(cityCrawl.CityCrawlID))
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
            return View(cityCrawl);
        }

        // GET: CityCrawls/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cityCrawl = await _context.cityCrawls
                .FirstOrDefaultAsync(m => m.CityCrawlID == id);
            if (cityCrawl == null)
            {
                return NotFound();
            }

            return View(cityCrawl);
        }

        // POST: CityCrawls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cityCrawl = await _context.cityCrawls.FindAsync(id);
            _context.cityCrawls.Remove(cityCrawl);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CityCrawlExists(int id)
        {
            return _context.cityCrawls.Any(e => e.CityCrawlID == id);
        }
    }
}
