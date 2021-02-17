using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace WebUniversityAuthentication
{
    public class Discipline : IValidatableObject
    {
        public int Id { set; get; }
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Title { set; get; }
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Annotation { set; get; }
     
        public int TeacherId { set; get; }
        //
    

        public virtual ICollection<Student> Students { set; get; }
        public virtual Teacher Teacher { set; get; }


        public Discipline()
        {
            Students = new List<Student>();
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            bool IsForbidden(string prop)
            {
                string[] forbiddens = { "aaa", "bbb", "ccc" };
                return forbiddens.Any(f => prop == f);
            }

            if (IsForbidden(Title))
                yield return new ValidationResult("Title is a forbidden word.", new string[] { "Title" });
            if (IsForbidden(Annotation))
                yield return new ValidationResult("Annotation is a forbidden word.", new string[] { "Annotation" });
        }


    }
}
