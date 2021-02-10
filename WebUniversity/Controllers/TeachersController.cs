using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUniversity.Controllers
{
    public class TeachersController : Controller
    {
        private readonly MyDbContext _db;
       
        public TeachersController(MyDbContext db)
        {
            _db = db;

        }
        public IActionResult Index()
        {
            return View(_db.Teachers);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Teacher teacher)
        {
            if (ModelState.IsValid)
            {
               
                _db.Teachers.Add(teacher);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var teacher = _db.Teachers.Find(id); 
            return View(teacher);
        }

        [HttpPost]
        public IActionResult Edit(Teacher t)
        {
            if (ModelState.IsValid)
            {
                var teacher = _db.Teachers.Find(t.Id);
                teacher.Name = t.Name;

                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(t);
        }
        [HttpGet]
        public IActionResult Delete (int id)
        {
            var teacher = _db.Teachers.Find(id); 
            return View(teacher);
        }
        [HttpPost]
        public IActionResult Delete ([FromForm] Teacher t)
        {
           
                _db.Teachers.Remove(t);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
          

        }


    }
}
