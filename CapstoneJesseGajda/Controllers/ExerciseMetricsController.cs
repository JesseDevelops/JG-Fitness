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

namespace CapstoneJesseGajda
{
    [Authorize]
    public class ExerciseMetricsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ExerciseMetricsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ExerciseMetrics
        public async Task<IActionResult> Index(string exerciseId, string userId)
        {
            ViewData["ExerciseID"] = new SelectList(_context.Exercises, "ExerciseID", "Exercise_Name");
            if (!String.IsNullOrEmpty(exerciseId))
            {
                var exerciseIdInt = Convert.ToInt32(exerciseId);
                var result = (from a in _context.Exercises
                              where a.ExerciseID == exerciseIdInt
                              select a.Exercise_Name).FirstOrDefault();
                ViewBag.ExerciseName = result;


                var minWeight = (from a in _context.ExerciseMetrics
                                 where a.ExerciseId == exerciseIdInt && a.UserId == userId
                                 select a).DefaultIfEmpty().Min(a => a.WeightUsed);
                    ViewBag.MinWeight = minWeight;

                var maxWeight = (from a in _context.ExerciseMetrics
                                 where a.ExerciseId == exerciseIdInt && a.UserId == userId
                                 select a).DefaultIfEmpty().Max(a => a.WeightUsed);
                    ViewBag.MaxWeight = maxWeight;

                var avgWeight = (from a in _context.ExerciseMetrics
                                 where a.ExerciseId == exerciseIdInt && a.UserId == userId
                                 select a).DefaultIfEmpty().Average(a => a.WeightUsed);
                    ViewBag.AvgWeight = avgWeight;

            }




            return View(await _context.ExerciseMetrics.ToListAsync());
        }

        // GET: ExerciseMetrics/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exerciseMetrics = await _context.ExerciseMetrics
                .FirstOrDefaultAsync(m => m.ExerciseMetricId == id);
            if (exerciseMetrics == null)
            {
                return NotFound();
            }

            return View(exerciseMetrics);
        }

        // GET: ExerciseMetrics/Create
        public IActionResult Create()
        {
           // var exercises = (from a in _context.Exercises
          //                   select new {a.ExerciseID, a.Exercise_Name }).Distinct().OrderBy(a=>a.Exercise_Name);
            ViewData["ExerciseID"] = new SelectList(_context.Exercises, "ExerciseID", "Exercise_Name");


            return View();
        }

        // POST: ExerciseMetrics/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ExerciseMetricId,UserId,ExerciseId,Date,WeightUsed")] ExerciseMetrics exerciseMetrics)
        {
            if (ModelState.IsValid)
            {
                _context.Add(exerciseMetrics);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(exerciseMetrics);
        }

        // GET: ExerciseMetrics/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exerciseMetrics = await _context.ExerciseMetrics.FindAsync(id);
            if (exerciseMetrics == null)
            {
                return NotFound();
            }
            return View(exerciseMetrics);
        }

        // POST: ExerciseMetrics/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ExerciseMetricId,UserId,ExerciseId,Date,WeightUsed")] ExerciseMetrics exerciseMetrics)
        {
            if (id != exerciseMetrics.ExerciseMetricId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(exerciseMetrics);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExerciseMetricsExists(exerciseMetrics.ExerciseMetricId))
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
            return View(exerciseMetrics);
        }

        // GET: ExerciseMetrics/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exerciseMetrics = await _context.ExerciseMetrics
                .FirstOrDefaultAsync(m => m.ExerciseMetricId == id);
            if (exerciseMetrics == null)
            {
                return NotFound();
            }

            return View(exerciseMetrics);
        }

        // POST: ExerciseMetrics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var exerciseMetrics = await _context.ExerciseMetrics.FindAsync(id);
            _context.ExerciseMetrics.Remove(exerciseMetrics);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExerciseMetricsExists(int id)
        {
            return _context.ExerciseMetrics.Any(e => e.ExerciseMetricId == id);
        }
    }
}
