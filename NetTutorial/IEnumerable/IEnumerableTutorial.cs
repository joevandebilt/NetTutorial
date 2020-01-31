using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetTutorial.IEnumerable
{
    public static class IEnumerableTutorial
    {
        /***** Enumerable *****/
        public static void RunIEnumerableTutorial()
        {
            /*
             * IEnumerable is part of the .Net Generic Collection library - as discussed in Generics it is both an interface and Generic Type
             * I.e. an IEnumerable is a collection of something <T> type T can be an object, class or data type - However static types cannot be used
             * See below that an IEnumerable of this calss is invalid
             * 
             */
            IEnumerable<string> strings;
            IEnumerable<DateTime> dateTimes;
            // It Doesn't like this ---> IEnumerable<IEnumerableTutorial> tutorials

            /*
             * What the fuck is it though? IEnumerable is an interface that impliments only 1 method, GetEnumerator()
             * The point of GetEnumerator is to return a method by which the elements in the collection can be called by a foreach loop 
             * 
             * An Enumerator is another interface that defines a set of functions to  move through the elements
             * 
             * The point of all this is to try and standardise a collection of data. IEnumerable itself is not a collection type, it is an interface.
             * 
             * This means that collections can be passed through the application, and the compiler can make smarter decisions with memory allocation before 
             * making a solid implimentation of something. 
             * 
             * Take the following example
             */

            //We get a list of dates from our database, or an API
            IEnumerable<DateTime> allMyDateTimes = GetAllDateTimesFromTheDB();

            //We only want a certain subset of this collection
            //This is linq - it allows collections to be queried like SQL - very handy; essentially all I'm asking it to do is find elements in the collection older than today
            //Notice how .Where() also returns an IEnumerable
            var filterList = allMyDateTimes.Where(x => x < DateTime.Today);     

            //Notice now that if you hover over filterList you now cannot see the count, or individual elements;

            //And we want them displayed in order
            var orderedList = filterList.OrderBy(x => x);

            //So essentially we don't need the original collection we from the DB/API, and we only wanted the contents of orderedList
            //Because this object is IEnumerable, it hasn't actually been implimented yet - it's structure isn't defined 
            //which unfortunately means we can't interact with it yet

            //This will throw an error ---> var earliestDate = orderedList[0];

            //However - all we need to do is cast our IEnumerable to a type which inherits the IEnumerable interface 
            //There are several types, but the most common is List<T> or Array<T> - there are actually extension methods to 
            //convert IEnumerables between these types
            List<DateTime> physicalList = orderedList.ToList();
            DateTime[] physicalArray = orderedList.ToArray();

            //and then we can access it 
            Assert.AreEqual(physicalList[0], physicalArray[0]);
            var earliestDate = physicalList[0];

            //So whats the point? Well it's really handy with large volumes of data, because the dataset can be filtered before 
            //enumeration without having to be enumerated onto the stack. You find that most of your memory allocation comes when a collection is Enumerated
            //You may think thats bullshit - because how can we filter out the date of an object before we enumerate to find out what it is? 
            //That's a good question - I don't know the answer but I'd guess that it just applies that filter upon enumeration


            //To Summarize: an IEnumerable is a generic collection which can be Enumerated once it is cast as a type which inherits IEnumerable
            //IEnumerables are light on memory as they have not yet enumerated their contents, and can allow you to filter that collection without enumerating it
            //Before Enumeration you cannot interact with the objects in the colleciton, including accessing their properties or counting the number of items in the collection
            //An IEnumerable becomes enumerated when it is cast to an Enumerable Type; such as List or Array

            Console.WriteLine($"The earliest date in our list was {earliestDate.ToString()}");
        }


        private static IEnumerable<DateTime> GetAllDateTimesFromTheDB()
        {
            //Okay it's hard to do this in reverse so just ignore what this 
            //function is doing and accept it's returning a collection of dates

            List<DateTime> randomDates = new List<DateTime>();
            Random rnd = new Random(DateTime.Now.Second);
            for (int i=0; i<10; i++)
            {
                randomDates.Add(DateTime.Today.AddDays(rnd.Next(-50, 50)));
            }
            return randomDates;
        }
    }
}
