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
    public class WorkoutListsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WorkoutListsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: WorkoutLists
        public async Task<IActionResult> Index(string userId)
        {
            var a = userId;
            return View(await _context.WorkoutList.ToListAsync());
        }

        // GET: WorkoutLists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var Exercise_Name = (from a in _context.WorkoutList
                                 where a.WorkoutId == id
                                 select a.Exercise_Name).FirstOrDefault();
            ViewBag.Exercise_Name = Exercise_Name;
 
           var ExerciseOne = (from a in _context.WorkoutList     
                              join b in _context.Exercises on a.Exercise_One equals b.ExerciseID
                              where a.WorkoutId == id
                        select b.Exercise_Name
                      ).FirstOrDefault();
            ViewBag.ExerciseOne = ExerciseOne;

            var ExerciseTwo = (from a in _context.WorkoutList
                               join b in _context.Exercises on a.Exercise_Two equals b.ExerciseID
                               where a.WorkoutId == id
                               select b.Exercise_Name
                     ).FirstOrDefault();
            ViewBag.ExerciseTwo = ExerciseTwo;

            var ExerciseThree = (from a in _context.WorkoutList
                               join b in _context.Exercises on a.Exercise_Three equals b.ExerciseID
                               where a.WorkoutId == id
                               select b.Exercise_Name
                    ).FirstOrDefault();
            ViewBag.ExerciseThree = ExerciseThree;

            var ExerciseFour = (from a in _context.WorkoutList
                                 join b in _context.Exercises on a.Exercise_Four equals b.ExerciseID
                                 where a.WorkoutId == id
                                 select b.Exercise_Name
                    ).FirstOrDefault();
            ViewBag.ExerciseFour = ExerciseFour;

            var ExerciseFive = (from a in _context.WorkoutList
                                 join b in _context.Exercises on a.Exercise_Five equals b.ExerciseID
                                 where a.WorkoutId == id
                                 select b.Exercise_Name
                    ).FirstOrDefault();
            ViewBag.ExerciseFive = ExerciseFive;

            var ExerciseSix = (from a in _context.WorkoutList
                                 join b in _context.Exercises on a.Exercise_Six equals b.ExerciseID
                                 where a.WorkoutId == id
                                 select b.Exercise_Name
                    ).FirstOrDefault();
            ViewBag.ExerciseSix = ExerciseSix;

            var ExerciseSeven = (from a in _context.WorkoutList
                                 join b in _context.Exercises on a.Exercise_Seven equals b.ExerciseID
                                 where a.WorkoutId == id
                                 select b.Exercise_Name
                    ).FirstOrDefault();
            ViewBag.ExerciseSeven = ExerciseSeven;

            var ExerciseEight = (from a in _context.WorkoutList
                                 join b in _context.Exercises on a.Exercise_Eight equals b.ExerciseID
                                 where a.WorkoutId == id
                                 select b.Exercise_Name
                    ).FirstOrDefault();
            ViewBag.ExerciseEight = ExerciseEight;

            var ExerciseNine = (from a in _context.WorkoutList
                                 join b in _context.Exercises on a.Exercise_Nine equals b.ExerciseID
                                 where a.WorkoutId == id
                                 select b.Exercise_Name
                    ).FirstOrDefault();
            ViewBag.ExerciseNine = ExerciseNine;

            var ExerciseTen = (from a in _context.WorkoutList
                                 join b in _context.Exercises on a.Exercise_Ten equals b.ExerciseID
                                 where a.WorkoutId == id
                                 select b.Exercise_Name
                    ).FirstOrDefault();
            ViewBag.ExerciseTen = ExerciseTen;

            var workoutList = await _context.WorkoutList
                .FirstOrDefaultAsync(m => m.WorkoutId == id);
            if (workoutList == null)
            {
                return NotFound();
            }

            return View(workoutList);
        }

        // GET: WorkoutLists/Create
        public IActionResult Create()
        {
            ViewData["ExerciseID"] = new SelectList(_context.Exercises, "ExerciseID", "Exercise_Name");
            return View();
        }

        // POST: WorkoutLists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WorkoutId,UserId,Exercise_One,Exercise_Two,Exercise_Three,Exercise_Four,Exercise_Five,Exercise_Six,Exercise_Seven,Exercise_Eight,Exercise_Nine,Exercise_Ten,Exercise_Name")] WorkoutList workoutList)
        {
            if (ModelState.IsValid)
            {
                _context.Add(workoutList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(workoutList);
        }

        // GET: WorkoutLists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            ViewData["ExerciseID"] = new SelectList(_context.Exercises, "ExerciseID", "Exercise_Name");

            var workoutList = await _context.WorkoutList.FindAsync(id);
            if (workoutList == null)
            {
                return NotFound();
            }
            return View(workoutList);
        }

      

    // POST: WorkoutLists/Edit/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WorkoutId,UserId,Exercise_One,Exercise_Two,Exercise_Three,Exercise_Four,Exercise_Five,Exercise_Six,Exercise_Seven,Exercise_Eight,Exercise_Nine,Exercise_Ten,Exercise_Name")] WorkoutList workoutList)
        {
            if (id != workoutList.WorkoutId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workoutList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkoutListExists(workoutList.WorkoutId))
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
            return View(workoutList);
        }

        // GET: WorkoutLists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workoutList = await _context.WorkoutList
                .FirstOrDefaultAsync(m => m.WorkoutId == id);
            if (workoutList == null)
            {
                return NotFound();
            }

            return View(workoutList);
        }

        // POST: WorkoutLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var workoutList = await _context.WorkoutList.FindAsync(id);
            _context.WorkoutList.Remove(workoutList);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult DisplaySelection()
        {
            return View();
        }


        public IActionResult WorkoutTwoDays()
        {
            return View();
        }

        public IActionResult WorkoutThreeDays()
        {
            return View();
        }

        public IActionResult WorkoutFourDays()
        {
            return View();
        }
        public IActionResult WorkoutFiveDays()
        {
            return View();
        }
        public IActionResult WorkoutSixDays()
        {
            return View();
        }

        private bool WorkoutListExists(int id)
        {
            return _context.WorkoutList.Any(e => e.WorkoutId == id);
        }
    }
}
