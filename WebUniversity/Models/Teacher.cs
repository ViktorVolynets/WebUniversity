using System;
using System.Collections.Generic;
using System.Text;

namespace WebUniversity
{
    public class Teacher
    {
        public int Id { set; get; }
        public string Name { set; get; }
        //
        public List<Discipline> Disciplines { set; get; }
    }
}
