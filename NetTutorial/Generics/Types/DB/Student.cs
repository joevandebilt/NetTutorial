using System;
using System.Collections.Generic;
using System.Text;

namespace NetTutorial.Generics.Types.DB
{
    public class DbStudent : BaseEntity
    {
        public DbStudent()
        {
            Courses = new List<string>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public DateTime DoB { get; set; }
        public List<string> Courses { get; set; }
    }
}
