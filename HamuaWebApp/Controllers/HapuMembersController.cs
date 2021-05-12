using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using HamuaHapuRegistration.Models;

namespace HamuaHapuRegistration.Controllers
{
    public class HapuMembersController : Controller
    {
        public HapuMembersController()
        {
        }

        // GET: HapuMembers
        public async Task<IActionResult> Index()
        {
            return View();
        }

        // GET: HapuMembers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            return View();
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
            return View(hapuMember);
        }

        // GET: HapuMembers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            return View();
        }

        // POST: HapuMembers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,FirstName,MiddleName,Surname,DOB,Birthplace,Occupation")] HapuMember hapuMember)
        {
            return View();
        }

        // GET: HapuMembers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            return View();
        }

        // POST: HapuMembers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            return View();
        }

        private bool HapuMemberExists(int id)
        {
            return false;
        }
    }
}