using System;
using System.Collections.Generic;
using System.Text;

namespace NetTutorial.Extension_Methods
{
    //Note that our class is public and static
    public static class StringExtensions
    {
        //We are extending a string's methods, therefore our first parameter is a string with the keyword 'this'
        // 'this' sets a scope for the compiler so it knows that CountCharacters is an extension for string objects
        public static int CountCharacters(this string input, char findCharacter)
        {
            return input.CountCharacters(findCharacter, true);
        }

        //This is an overload method - it has the same name and return type as the other method in this class but it has different parameter inputs
        public static int CountCharacters(this string input, char findCharacter, bool caseSensitive)
        { 
            //if we don't care about case sensitivity drop everything to lowercase
            if (!caseSensitive)
            {
                input = input.ToLower();
                findCharacter = findCharacter.ToString().ToLower()[0]; //Convert to string, lowercase, get first (only) char in string
            }

            //There will be a better way to do this but lets keep is simple
            int characterCount = 0;
            foreach (char character in input)
            {
                if (character == findCharacter)
                {
                    characterCount++;
                }
            }
            return characterCount;
        }
    }
}
