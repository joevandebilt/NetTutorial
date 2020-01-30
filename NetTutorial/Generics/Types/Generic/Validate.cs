using System;
using System.Collections.Generic;
using System.Text;

namespace NetTutorial.Generics.Types.Generic
{
    public static class ValidateGeneric
    {
        /*  
         *  Okay so this is a generic Method
         *  In the Method name we have defined a generic type, T
         *  In our parameters we have an input Response of Type T (Response<T>)
         *  
         *  Since the type T isn't used, we can validate Response
         */

        public static void ValidateGenericResponse<T>(Response<T> response)
        {
            if (response.Success)
            {
                //yay this is great
                if (response.Payload == null)
                {
                    //it says it's successful but the payload is null so thats a fuckin lie isn't it
                    throw new NullReferenceException("The response is successful, but the payload is empty");
                }
            }
            else if (response.ErrorMessages.Count > 0)
            {
                //Uh oh we have some errors to report - just throw the first one 
                throw new Exception(response.ErrorMessages[0]);
            }
            else
            {
                throw new ArgumentNullException("The response is totally empty");
            }
        }
    }
}
