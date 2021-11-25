﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CC_Web.Models.Data;
using CC_web_ny.Data;

namespace CC_web_ny.Controllers
{
    public class VirksomhedsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VirksomhedsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Virksomheds
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Virksomheder.Include(v => v.CC);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Virksomheds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var virksomhed = await _context.Virksomheder
                .Include(v => v.CC)
                .FirstOrDefaultAsync(m => m.VirksomhedID == id);
            if (virksomhed == null)
            {
                return NotFound();
            }

            return View(virksomhed);
        }

        public async Task<IActionResult> Profil(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var virksomhed = await _context.Virksomheder
                .Include(v => v.CC)
                .FirstOrDefaultAsync(m => m.VirksomhedID == id);
            if (virksomhed == null)
            {
                return NotFound();
            }

            return View(virksomhed);
        }

        // GET: Virksomheds/Create
        public IActionResult Create()
        {
            ViewData["CityCrawlId"] = new SelectList(_context.CityCrawl, "CityCrawlID", "CityCrawlID");
            return View();
        }

        // POST: Virksomheds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VirksomhedID,CVR,Virksomhedsnavn,KontaktPerson,CityCrawlId")] Virksomhed virksomhed)
        {
            if (ModelState.IsValid)
            {
                _context.Add(virksomhed);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CityCrawlId"] = new SelectList(_context.CityCrawl, "CityCrawlID", "CityCrawlID", virksomhed.CityCrawlId);
            return View(virksomhed);
        }

        // GET: Virksomheds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var virksomhed = await _context.Virksomheder.FindAsync(id);
            if (virksomhed == null)
            {
                return NotFound();
            }
            ViewData["CityCrawlId"] = new SelectList(_context.CityCrawl, "CityCrawlID", "CityCrawlID", virksomhed.CityCrawlId);
            return View(virksomhed);
        }

        // POST: Virksomheds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VirksomhedID,CVR,Virksomhedsnavn,KontaktPerson,CityCrawlId")] Virksomhed virksomhed)
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
            ViewData["CityCrawlId"] = new SelectList(_context.CityCrawl, "CityCrawlID", "CityCrawlID", virksomhed.CityCrawlId);
            return View(virksomhed);
        }

        // GET: Virksomheds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var virksomhed = await _context.Virksomheder
                .Include(v => v.CC)
                .FirstOrDefaultAsync(m => m.VirksomhedID == id);
            if (virksomhed == null)
            {
                return NotFound();
            }

            return View(virksomhed);
        }

        // POST: Virksomheds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var virksomhed = await _context.Virksomheder.FindAsync(id);
            _context.Virksomheder.Remove(virksomhed);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VirksomhedExists(int id)
        {
            return _context.Virksomheder.Any(e => e.VirksomhedID == id);
        }
    }
}
