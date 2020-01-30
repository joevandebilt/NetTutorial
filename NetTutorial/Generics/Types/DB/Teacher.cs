using System;
using System.Collections.Generic;
using System.Text;

namespace NetTutorial.Generics.Types.DB
{
    public class DbTeacher : BaseEntity
    {
        public DbTeacher()
        {
            
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
