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
    

        public virtual ICollection<Student> Students { set; get; }
        public Teacher Teacher { set; get; }


        public Discipline()
        {
            Students = new List<Student>();
        }

    }
}
