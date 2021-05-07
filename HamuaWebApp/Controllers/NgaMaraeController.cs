using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HamuaHapuRegistration.Data;
using HamuaHapuRegistration.Models;

namespace HamuaHapuRegistration.Controllers
{
    public class NgaMaraeController : Controller
    {
        private readonly HamuaHapuRegistrationContext _context;

        public NgaMaraeController(HamuaHapuRegistrationContext context)
        {
            _context = context;
        }

        // GET: NgaMarae
        public async Task<IActionResult> Index()
        {
            return View(await _context.NgaMarae.ToListAsync());
        }

        // GET: NgaMarae/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ngaMarae = await _context.NgaMarae
                .FirstOrDefaultAsync(m => m.ID == id);
            if (ngaMarae == null)
            {
                return NotFound();
            }

            return View(ngaMarae);
        }

        // GET: NgaMarae/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NgaMarae/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Area,Marae,Hapu")] NgaMarae ngaMarae)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ngaMarae);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ngaMarae);
        }

        // GET: NgaMarae/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ngaMarae = await _context.NgaMarae.FindAsync(id);
            if (ngaMarae == null)
            {
                return NotFound();
            }
            return View(ngaMarae);
        }

        // POST: NgaMarae/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Area,Marae,Hapu")] NgaMarae ngaMarae)
        {
            if (id != ngaMarae.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ngaMarae);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NgaMaraeExists(ngaMarae.ID))
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
            return View(ngaMarae);
        }

        // GET: NgaMarae/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ngaMarae = await _context.NgaMarae
                .FirstOrDefaultAsync(m => m.ID == id);
            if (ngaMarae == null)
            {
                return NotFound();
            }

            return View(ngaMarae);
        }

        // POST: NgaMarae/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ngaMarae = await _context.NgaMarae.FindAsync(id);
            _context.NgaMarae.Remove(ngaMarae);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NgaMaraeExists(int id)
        {
            return _context.NgaMarae.Any(e => e.ID == id);
        }
    }
}
