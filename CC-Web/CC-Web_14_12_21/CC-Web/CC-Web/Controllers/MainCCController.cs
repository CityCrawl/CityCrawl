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
        public async Task<IActionResult> Index()
        {
            return View(await _context.virksomheder.ToListAsync());
        }

        public async Task<IActionResult> Profil(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var virksomhed = await _context.virksomheder.Include(v => v.Pubcrawls)
                .FirstOrDefaultAsync(m => m.Email == id);

            await _context.SaveChangesAsync();

            if (virksomhed == null)
            {
                return NotFound();
            }

            return View(virksomhed);
        }

        public IActionResult Welcome()
        {
            return View("Welcome");
        }

        private bool VirksomhedExists(int id)
        {
            return _context.virksomheder.Any(e => e.VirksomhedID == id);
        }
    }
}