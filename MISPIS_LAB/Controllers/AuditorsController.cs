using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MISPIS_LAB.Data;
using MISPIS_LAB.Models;

namespace MISPIS_LAB.Controllers
{
    public class AuditorsController : Controller
    {
        private readonly ProjectContext _context;

        public AuditorsController(ProjectContext context)
        {
            _context = context;
        }

        // GET: Auditors
        public async Task<IActionResult> Index()
        {
            return View(await _context.Auditors.ToListAsync());
        }

        // GET: Auditors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var auditor = await _context.Auditors
                .SingleOrDefaultAsync(m => m.ID == id);
            if (auditor == null)
            {
                return NotFound();
            }

            return View(auditor);
        }

        // GET: Auditors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Auditors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Position")] Auditor auditor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(auditor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(auditor);
        }

        // GET: Auditors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var auditor = await _context.Auditors.SingleOrDefaultAsync(m => m.ID == id);
            if (auditor == null)
            {
                return NotFound();
            }
            return View(auditor);
        }

        // POST: Auditors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Position")] Auditor auditor)
        {
            if (id != auditor.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(auditor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AuditorExists(auditor.ID))
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
            return View(auditor);
        }

        // GET: Auditors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var auditor = await _context.Auditors
                .SingleOrDefaultAsync(m => m.ID == id);
            if (auditor == null)
            {
                return NotFound();
            }

            return View(auditor);
        }

        // POST: Auditors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var auditor = await _context.Auditors.SingleOrDefaultAsync(m => m.ID == id);
            _context.Auditors.Remove(auditor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AuditorExists(int id)
        {
            return _context.Auditors.Any(e => e.ID == id);
        }
    }
}
