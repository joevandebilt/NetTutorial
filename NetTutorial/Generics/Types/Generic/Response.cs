using NetTutorial.Generics.Types.Extended;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetTutorial.Generics.Types.Generic
{
    //We have created a class "Response" which is built off of baseObject, so it inherits the Success and Error Messages objects (this is just because I'm lazy)
    //But we've extended Response by letting it have generic type T, 
    //the class can see that we have a public Property of Type T which is the payload
    public class Response<T> : BaseObject
    {
        public T Payload { get; set; }
    }
}
