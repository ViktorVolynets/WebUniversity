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
        public IActionResult Create(string name)
        {
            var teacher = new Teacher { Name = name };
            _db.Teachers.Add(teacher);
            _db.SaveChanges();
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
            var teacher = _db.Teachers.Find(t.Id);
            teacher.Name = t.Name;
        
            _db.SaveChanges();
            return View(teacher);
        }
        [HttpGet]
        public IActionResult Delete (int id)
        {
            var teacher = _db.Teachers.Find(id);
            return View();
        }

      




    }
}
