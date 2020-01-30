using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetTutorial.Extension_Methods
{
    public static class ExtensionMethodsTutorial
    {
        /***** Extension Methods *****/
        public static void RunExtensionMethodsTutorial()
        {
            /*
             * Some objects have built-in methods, for example string has ToUpper() and ToLower(), DateTime has .AddDays()
             * It is possible to write your own methods for these objects, known as extension methods, the below code is an 
             * extenion method which counts the number of characters of a particular string.
             * 
             */

            string ourTestString = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.";
            
            //TopTip: Hover over 'ourTestString' with your mouse to see the value currently assigned to that variable

            int fCount = ourTestString.CountCharacters('F');    // <---- Use F12 with cursor over CountCharactes to go to definition! 
            Assert.AreEqual(fCount, 0);     //There are no 'F' in our string

            int aCount = ourTestString.CountCharacters('A');
            Assert.AreEqual(aCount, 0);     //Weirdly there is no 'A' character in our String - this is obviously because 'A' != 'a'

            //We can create an overload method for CountCharacters where we specify that the input is not case sensitive
            aCount = ourTestString.CountCharacters('A', false);
            Assert.AreEqual(aCount, 2); //There's our A's 

            //Extension methods can apply to almost anything, classes, interfaces, objects and types 
            //the only caveat is that the extension method must be a static method and the parameters must contain a 'this' keyword

            //Try to create an extension method that counts the number of non-alphabetic characters in our input string, uncomment the section below
            /*
                int punctuationCount = ourTestString.CountPunctuation();
                Assert.AreEqual(punctuationCount, 2);
            */
        }
    }
}
