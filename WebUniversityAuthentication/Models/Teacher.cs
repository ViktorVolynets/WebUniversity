using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;


namespace WebUniversityAuthentication
{
    public class Teacher : IValidatableObject
    {
        public int Id { set; get; }
        [Required]
        [StringLength(100, MinimumLength = 3)]
        [NameValidation("Mac", "Test")]
        public string Name { set; get; }
        //
        public virtual List<Discipline> Disciplines { set; get; }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            bool IsForbidden(string prop)
            {
                string[] forbiddens = { "aaa", "bbb", "ccc" };
                return forbiddens.Any(f => prop == f);
            }

            if (IsForbidden(Name))
                yield return new ValidationResult("Name is a forbidden word.", new string[] { "Name" });
  
        }
    }
}
