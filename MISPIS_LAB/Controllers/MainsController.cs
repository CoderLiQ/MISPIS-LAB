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
    public class MainsController : Controller
    {
        private readonly ProjectContext _context;

        public MainsController(ProjectContext context)
        {
            _context = context;
        }

        // GET: Mains
        public async Task<IActionResult> Index()
        {
            var projectContext = _context.Mains.Include(m => m.Auditor).Include(m => m.Author).Include(m => m.Incident);
            return View(await projectContext.ToListAsync());
        }

        // GET: Mains/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var main = await _context.Mains
                .Include(m => m.Auditor)
                .Include(m => m.Author)
                .Include(m => m.Incident)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (main == null)
            {
                return NotFound();
            }

            return View(main);
        }

        // GET: Mains/Create
        public IActionResult Create()
        {
            ViewData["AuditorID"] = new SelectList(_context.Auditors, "ID", "ID");
            ViewData["AuthorID"] = new SelectList(_context.Authors, "ID", "ID");
            ViewData["IncidentID"] = new SelectList(_context.Incidents, "ID", "ID");
            return View();
        }

        // POST: Mains/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,IncidentID,AuditorID,AuthorID")] Main main)
        {
            if (ModelState.IsValid)
            {
                _context.Add(main);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AuditorID"] = new SelectList(_context.Auditors, "ID", "ID", main.AuditorID);
            ViewData["AuthorID"] = new SelectList(_context.Authors, "ID", "ID", main.AuthorID);
            ViewData["IncidentID"] = new SelectList(_context.Incidents, "ID", "ID", main.IncidentID);
            return View(main);
        }

        // GET: Mains/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var main = await _context.Mains.SingleOrDefaultAsync(m => m.ID == id);
            if (main == null)
            {
                return NotFound();
            }
            ViewData["AuditorID"] = new SelectList(_context.Auditors, "ID", "ID", main.AuditorID);
            ViewData["AuthorID"] = new SelectList(_context.Authors, "ID", "ID", main.AuthorID);
            ViewData["IncidentID"] = new SelectList(_context.Incidents, "ID", "ID", main.IncidentID);
            return View(main);
        }

        // POST: Mains/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,IncidentID,AuditorID,AuthorID")] Main main)
        {
            if (id != main.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(main);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MainExists(main.ID))
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
            ViewData["AuditorID"] = new SelectList(_context.Auditors, "ID", "ID", main.AuditorID);
            ViewData["AuthorID"] = new SelectList(_context.Authors, "ID", "ID", main.AuthorID);
            ViewData["IncidentID"] = new SelectList(_context.Incidents, "ID", "ID", main.IncidentID);
            return View(main);
        }

        // GET: Mains/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var main = await _context.Mains
                .Include(m => m.Auditor)
                .Include(m => m.Author)
                .Include(m => m.Incident)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (main == null)
            {
                return NotFound();
            }

            return View(main);
        }

        // POST: Mains/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var main = await _context.Mains.SingleOrDefaultAsync(m => m.ID == id);
            _context.Mains.Remove(main);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MainExists(int id)
        {
            return _context.Mains.Any(e => e.ID == id);
        }
    }
}
