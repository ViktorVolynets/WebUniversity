using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUniversity
{
    public class Student
    {
        public int Id { set; get; }
        public string Name { set; get; }
        //
        public virtual ICollection<Discipline> Disciplines { set; get; }

        public Student()
        {
            Disciplines = new List<Discipline>();
        }

    }

   
}
