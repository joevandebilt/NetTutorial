using System;
using System.Collections.Generic;
using System.Text;

namespace NetTutorial.Generics.Types.DB
{
    public class BaseEntity
    {
        public int ID { get; set; }
        public Guid UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
