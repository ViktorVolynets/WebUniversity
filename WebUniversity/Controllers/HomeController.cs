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
            // int n = _db.Students.Count();
            // return Content(n.ToString());
            return View(myDbContext.ToList());
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
         
          //  var student = _db.Students.Include(d => d.Disciplines);
            var student = await  _db.Students.FindAsync(id);
            _db.Entry(student).Collection("Disciplines").Load();
            //   Student t = (Student)student.Where(x => x.Id == id).Select(s => s);
            if (student == null)
            {
                return NotFound();
            }
            //  ViewData["Disciplin"] = new SelectList(_db.Disciplines, "Id", "Title", student.Disciplines.First().Id);
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
