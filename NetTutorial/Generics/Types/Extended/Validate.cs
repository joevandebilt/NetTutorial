using System;
using System.Collections.Generic;
using System.Text;

namespace NetTutorial.Generics.Types.Extended
{
    public static class ValidateExtended
    {
        public static void ValidateResponse(BaseObject baseObject)
        {
            //Say we wanted to validate our packet
            if (baseObject.Success)
            {
                //yay this is great
            }
            else if (baseObject.ErrorMessages.Count > 0)
            {
                //Uh oh we have some errors to report - just throw the first one 
                throw new Exception(baseObject.ErrorMessages[0]);
            }
            else
            {
                throw new ArgumentNullException("The response is totally empty");
            }
        }
    }
}
