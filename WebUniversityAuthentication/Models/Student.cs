using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace WebUniversityAuthentication
{

    public class Student : IdentityUser

    {

        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "{0} is too long.")]
        [NameValidation("Mac","Test")]
        public string Group { set; get; }
        //
    
        public virtual ICollection<Discipline> Disciplines { set; get; }

        public Student()
        {
            Disciplines = new List<Discipline>();
        }





    }

   
}
