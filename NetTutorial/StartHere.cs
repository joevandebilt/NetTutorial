using NetTutorial.Extension_Methods;
using NetTutorial.Generics;
using NUnit.Framework;
using System;

namespace ConsoleApp1
{
    class StartHere
    {
        static void Main(string[] args)
        {
            //Breakpoint here - here are some handy shortcuts
            Console.WriteLine("Hello World");

            //F5 - Run, Continue running from breakpoint
            //F9 - Set/Remove breakpoint on current line
            //F10 - Step over, do not move into a function
            //F11 - Step Into, move into a function
            //F12 - Go to definition; Variable -> Declaration, Class -> Class Definition etc

            //You can break here, F11 to go into the code, or F12 to just navigate to the definition
            ExtensionMethodsTutorial.RunExtensionMethodsTutorial();

            //Same with this one
            GenericsTutorial.RunGenericsTutorial();
        }
    }
}
