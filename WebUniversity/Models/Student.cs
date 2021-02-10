using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebUniversity.Models;

namespace WebUniversity
{
    public class Student
    {
        public int Id { set; get; }
        [Display(Name = "Student Name")]
        [Required]
       
        [StringLength(100, MinimumLength = 3, ErrorMessage = "{0} is too long.")]
       [NameValidation("Mac","Test")]
        public string Name { set; get; }
        //
       // [Remote("ValidateName", "Home")]
        public virtual ICollection<Discipline> Disciplines { set; get; }

        public Student()
        {
            Disciplines = new List<Discipline>();
        }





    }

   
}
