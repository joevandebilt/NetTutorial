using System;
using System.Collections.Generic;
using System.Text;

namespace NetTutorial.Generics.Types.Generic
{
    public class Student
    {
        public Student()
        {
            Courses = new List<string>();
        }

        public string FirstName { get; set; } = "Chris";
        public string LastName { get; set; }
        public int Age { get; set; }
        public DateTime DoB { get; set; }
        public List<string> Courses { get; set; }
    }
}
