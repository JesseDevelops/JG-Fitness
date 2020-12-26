using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CapstoneJesseGajda.Data;
using CapstoneJesseGajda.Models;
using Microsoft.AspNetCore.Authorization;

namespace CapstoneJesseGajda.Controllers
{
    [Authorize]
    public class UserBMIsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserBMIsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: UserBMIs
        public async Task<IActionResult> Index()
        {
            return View(await _context.UserBMI.ToListAsync());
        }

        public ActionResult GetChartData()
        {
            return Json(_context.UserBMI.
                Select(p => new { p.BMI, p.Date, p.Bmi_Id, p.UserId }), new Newtonsoft.Json.JsonSerializerSettings());
        }

        // GET: UserBMIs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userBMI = await _context.UserBMI
                .FirstOrDefaultAsync(m => m.Bmi_Id == id);
            if (userBMI == null)
            {
                return NotFound();
            }

            return View(userBMI);
        }

        // GET: UserBMIs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserBMIs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Bmi_Id,UserId,Date,BMI")] UserBMI userBMI)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userBMI);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userBMI);
        }

        // GET: UserBMIs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userBMI = await _context.UserBMI.FindAsync(id);
            if (userBMI == null)
            {
                return NotFound();
            }
            return View(userBMI);
        }

        // POST: UserBMIs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,[Bind("Bmi_Id,UserId,Date,BMI")] UserBMI userBMI)
        {
            if (id != userBMI.Bmi_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userBMI);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserBMIExists(userBMI.Bmi_Id))
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
            return View(userBMI);
        }

        // GET: UserBMIs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userBMI = await _context.UserBMI
                .FirstOrDefaultAsync(m => m.Bmi_Id == id);
            if (userBMI == null)
            {
                return NotFound();
            }

            return View(userBMI);
        }

        // POST: UserBMIs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userBMI = await _context.UserBMI.FindAsync(id);
            _context.UserBMI.Remove(userBMI);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserBMIExists(int id)
        {
            return _context.UserBMI.Any(e => e.Bmi_Id == id);
        }
    }
}
