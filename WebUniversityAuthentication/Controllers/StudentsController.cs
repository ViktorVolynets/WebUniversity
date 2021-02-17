using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebUniversityAuthentication;
using WebUniversityAuthentication.Data;
using WebUniversityAuthentication.Filter;

namespace WebUniversityAuthentication.Controllers
{
    [Authorize]
    public class StudentsController : Controller
    {





        private readonly ApplicationDbContext _context;
        private UserManager<Student> _userManager;

        public StudentsController(UserManager<Student> userManager, ApplicationDbContext context)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Student
        public async Task<IActionResult> Index()
        {
            return View(await _userManager.Users.ToListAsync());
        }

     
        // GET: Student/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserName, Group")] Student student)
        {
            if (ModelState.IsValid)
            {
              var res = await _userManager.CreateAsync(student, "123456");
             
                if (res.Succeeded)
                return RedirectToAction(nameof(Index));
            }
            ModelState.AddModelError("UserName", "Student was not created");
            return View(student);
        }

        // GET: Student/Edit/5
       // [Authorize(Policy = "ForStudent")]
        [ForStudent]
        public async Task<IActionResult> Edit(string id)
        {
            _context.ChangeTracker.LazyLoadingEnabled = true;
            if (id == null)
            {
                return NotFound();
            }

            var student = await _userManager.FindByIdAsync(id);
          
            
            if (student == null)
            {
                return NotFound();
            }



            ViewBag.Distiplines = _context.Disciplines.ToList();
            
            return View(student);
        }

        // POST: Student/Edit/5
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "ForStudent")]
        public async Task<IActionResult> Edit([FromForm] Student student, int[] Disciplines)
        {
          

            if (ModelState.IsValid)
            {
                try
                {
                    if (Disciplines.Count() > 3)
                    {

                        ModelState.AddModelError("Disciplines", "You can choose no more than 3 disciplines");
                        ViewBag.Distiplines = _context.Disciplines.ToList();
                        return View(student);
                    }

                   var dis = _context.Disciplines.Where(s => Disciplines.Contains(s.Id)).Select(s => s);
                   
                    var studentdb = await _userManager.FindByIdAsync(student.Id);
                   
                    studentdb.UserName = student.UserName;
                    studentdb.Group = student.Group;
                    studentdb.Disciplines.Clear();
                    await _userManager.UpdateAsync(studentdb);

                    studentdb.Disciplines = dis.ToList();
                    var res =  await _userManager.UpdateAsync(studentdb);

                    if (res.Succeeded)
                        return RedirectToAction(nameof(Index));


                }
                catch (DbUpdateConcurrencyException)
                {
                  
                 
                }
               
            }
            ModelState.AddModelError("UserName", "Student was not edit");
            ViewBag.Distiplines = _context.Disciplines.ToList();
            return View(student);
        }

        // GET: Student/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Student student = await _userManager.FindByIdAsync(id);

            return View(student);
        }

        // POST: Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            Student student = await _userManager.FindByIdAsync(id);
            
            var result = await _userManager.DeleteAsync(student);
            if (result.Succeeded)
            {
                return RedirectToAction(nameof(Index));

            }
            return View(student);
        }

        private bool TeacherExists(int id)
        {
            return _context.Teachers.Any(e => e.Id == id);
        }
    }

  



}
