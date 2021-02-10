using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebUniversity.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebUniversity;

namespace WebUniversity.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly MyDbContext _db;

        public HomeController(ILogger<HomeController> logger, MyDbContext db)
        {
            _logger = logger;
            _db = db;
        }

    
        public IActionResult Index()
        {
            var myDbContext = _db.Students.Include(d => d.Disciplines);         
            return View(myDbContext.ToList());
        }


        public IActionResult Create()
        {  
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name")] Student student)
        {
            if (ModelState.IsValid)
            {
                _db.Add(student);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(student);

        }

        public async Task<IActionResult> Edit(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var student = await  _db.Students.FindAsync(id);
            _db.Entry(student).Collection("Disciplines").Load();
         
            if (student == null)
            {
                return NotFound();
            }
            ViewBag.Distiplines = _db.Disciplines;
            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Student student, int[] Disciplines)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    if (Disciplines.Count()>3)
                    {

                        ModelState.AddModelError("Disciplines", "You can choose no more than 3 disciplines");
                        ViewBag.Distiplines = _db.Disciplines;
                        return View(student);
                    }

                    var studentDb = _db.Students.Include(d => d.Disciplines).Where(s => s.Id == student.Id).FirstOrDefault();
                    studentDb.Name = student.Name;

                    foreach (var item in _db.Disciplines)
                    {
                        if (Disciplines.ToList().Contains(item.Id))
                        {
                            studentDb.Disciplines.Add(item);
                        }
                        else
                        {
                            studentDb.Disciplines.Remove(item);
                        }
                    }

                    _db.Entry(studentDb).State = EntityState.Modified;

                    await _db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {

                }
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Distiplines = _db.Disciplines;
            return View(student);
        }




        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

     
    }
}
