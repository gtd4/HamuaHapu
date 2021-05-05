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
    public class HapuMembersController : Controller
    {
        private readonly HamuaHapuRegistrationContext _context;

        public HapuMembersController(HamuaHapuRegistrationContext context)
        {
            _context = context;
        }

        // GET: HapuMembers
        public async Task<IActionResult> Index()
        {
            return View(await _context.HapuMember.ToListAsync());
        }

        // GET: HapuMembers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hapuMember = await _context.HapuMember
                .FirstOrDefaultAsync(m => m.ID == id);
            if (hapuMember == null)
            {
                return NotFound();
            }

            return View(hapuMember);
        }

        // GET: HapuMembers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HapuMembers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,FirstName,MiddleName,Surname,DOB,Birthplace,Occupation")] HapuMember hapuMember)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hapuMember);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hapuMember);
        }

        // GET: HapuMembers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hapuMember = await _context.HapuMember.FindAsync(id);
            if (hapuMember == null)
            {
                return NotFound();
            }
            return View(hapuMember);
        }

        // POST: HapuMembers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,FirstName,MiddleName,Surname,DOB,Birthplace,Occupation")] HapuMember hapuMember)
        {
            if (id != hapuMember.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hapuMember);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HapuMemberExists(hapuMember.ID))
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
            return View(hapuMember);
        }

        // GET: HapuMembers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hapuMember = await _context.HapuMember
                .FirstOrDefaultAsync(m => m.ID == id);
            if (hapuMember == null)
            {
                return NotFound();
            }

            return View(hapuMember);
        }

        // POST: HapuMembers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hapuMember = await _context.HapuMember.FindAsync(id);
            _context.HapuMember.Remove(hapuMember);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HapuMemberExists(int id)
        {
            return _context.HapuMember.Any(e => e.ID == id);
        }
    }
}
