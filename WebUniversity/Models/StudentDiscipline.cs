using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUniversity
{
    public class StudentDiscipline
    {
        public int StudentId { set; get; }
        public int DisciplineId { set; get; }

        //
        public Student Student { get; set; }
        public Discipline Discipline { get; set; }

    }
}
