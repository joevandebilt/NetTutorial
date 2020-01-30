using System;
using System.Collections.Generic;
using System.Text;

namespace NetTutorial.Generics.Types.Extended
{
    public class BaseObject
    {
        public BaseObject()
        {
            ErrorMessages = new List<string>();
        }
        public bool Success
        {
            get
            {
                return (ErrorMessages.Count == 0);
            }
            set
            { }
        }
        public List<string> ErrorMessages { get; set; }
    }
}
