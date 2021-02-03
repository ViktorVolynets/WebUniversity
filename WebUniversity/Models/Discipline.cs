using System;
using System.Collections.Generic;
using System.Text;

namespace WebUniversity
{
    public class Discipline
    {
        public int Id { set; get; }
        public string Title { set; get; }
        public string Annotation { set; get; }
        public int TeacherId { set; get; }
        //
    

        public List<StudentDiscipline> StudentDiscipline { set; get; }
        public Teacher Teacher { set; get; }
    }
}
