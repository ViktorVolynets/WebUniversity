using System;
using System.Collections.Generic;
using System.Text;

namespace WebUniversity
{
    public class TeacherDiscipline
    {
        public int TeacherId { set; get; }
        public int DisciplineId { set; get; }
        //
        public Teacher Teacher { get; set; }
        public Discipline Discipline { get; set; }

    }
}
