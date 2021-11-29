using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CC_Web.Models.CC_DbContext;
using CC_Web.Models.Data;

namespace CC_Web.Controllers
{
    public class CityCrawlController : Controller
    {
        private readonly CC_DbContext _context;

        public CityCrawlController(CC_DbContext context)
        {
            _context = context;
        }

        // GET: CityCrawl
        public async Task<IActionResult> Index()
        {
            return View(await _context.cityCrawls.ToListAsync());
        }

        // GET: CityCrawl/Details/5
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

        // GET: CityCrawl/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CityCrawl/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CityCrawlID,Begivenhed,Sted,Dato")] CityCrawl cityCrawl)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cityCrawl);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cityCrawl);
        }

        // GET: CityCrawl/Edit/5
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

        // POST: CityCrawl/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CityCrawlID,Begivenhed,Sted,Dato")] CityCrawl cityCrawl)
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

        // GET: CityCrawl/Delete/5
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

        // POST: CityCrawl/Delete/5
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
