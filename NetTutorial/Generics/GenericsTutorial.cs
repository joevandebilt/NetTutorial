using NetTutorial.Generics.Types.DB;
using NetTutorial.Generics.Types.Extended;
using NetTutorial.Generics.Types.Generic;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetTutorial.Generics
{
    public static class GenericsTutorial
    {
        /***** Generics *****/
        public static void RunGenericsTutorial()
        {
            //Generics can be split into 2 groups - generic types and generic methods.

            /*
             * A generic type is very similar to simple object inheritence where-in the Type (T) 
             * is used as a property in the object, rather than as a part of it. 
             * 
             * The main objective is to create a wrapper for an object, the best example I can think of is for an
             * API response packet. You always want to return a common set of fields but the actual structure of the 
             * payload will change.
             * 
             * For example lets say in our API we always want a Success, a list of error messages and the result. 
             * First example is an object using inhereitance - the second uses generics
             */

            var student = new StudentResponse();

            //Now we have our extendedOBject we can interact with it
            Console.WriteLine($"Welcome to the party {student.FirstName}");

            //Lets say we want to validate our response
            ValidateExtended.ValidateResponse(student);

            //That code works, and it's great! but suppose we actually had a different object, that still inherited the BaseObject
            var teacher = new TeacherResponse();
            ValidateExtended.ValidateResponse(teacher);

            //They can both run through that method because they share a common object set - but what happens if we have all our students? 
            List<StudentResponse> AllStudents = new List<StudentResponse>() { student };

            //ValidateExtended.ValidateResponse(AllStudents); 
            // ^ Ohnohed - this won't work because the AllStudents object doesn't inherit the baseobject, so we have to do it like this 

            foreach (var studentToValidate in AllStudents)
            {
                ValidateExtended.ValidateResponse(studentToValidate);
            }

            //Thats some pretty annoying code, especially seeing as we don't need each individual student to have a success flag, just the packed


            //Now suppose we created a generic object which took type Student and Teacher
            var genericStudent = new Response<Student>();
            var genericTeacher = new Response<Teacher>();

            // So we've create our response but because it's just a generic property, the constructor of "Student" and "Teacher" has even run
            // This is advantages as it means if we need to (in the event of an error) then the payload can remain Null
            genericStudent.Payload = new Student();
            genericTeacher.Payload = new Teacher();
            

            //It's a little more bulky, but we can still interact with our objects
            Console.WriteLine($"{genericStudent.Payload.FirstName}, {genericTeacher.Payload.FirstName} would like to see you in their office");

            //Unlike inherited objects though, we can set our payload to be _anything_ including more generic things, like lists
            var genericAllStudents = new Response<List<Student>>();
            genericAllStudents.Payload = new List<Student> { new Student() };

            //And we can validate the base properties just as easily
            if (!genericAllStudents.Success)
            {
                throw new Exception("This isn't successful - get outta here!");
            }


            //Generic methods - what if we wanted to create a method to validate our Response class, the same way we validate the extended types?
            //Thats fine, we just do it the same way - but because it's a generic type, we can do it with all of our responses
            ValidateGeneric.ValidateGenericResponse(genericStudent);
            ValidateGeneric.ValidateGenericResponse(genericTeacher);
            ValidateGeneric.ValidateGenericResponse(genericAllStudents);

            //Lets do 
            AnotherExample();
        }

        private static void AnotherExample()
        {
            /* 
             * Another example of Generic methods is creating a generic method for a particular type of object, 
             * for example an interface or Collection 
             * 
             * Another good example would be for Generics are database entities. Lets say our schemas has tables with the same consistent properties
             *  ID (primary key)
             *  UpdatedBy (GUID)
             *  UpdatedOn (DATETIME)
             *  CreatedBy (GUID)
             *  CreatedOn (DATETIME)
             */

            //Lets give this default object some character
            DbStudent student = new DbStudent();
            student.FirstName = "Joe";
            student.LastName = "van de Bilt";
            student.Age = 28;

            //Now lets Save him through our Generic Service
            Service.Save(student);

            //and we can do the same with a teacher, but lets initalise the object a little differently
            var teacher = new DbTeacher
            {
                ID = 123,
                FirstName = "Sarah",
                LastName = "Stothard"
            };

            //Since we set the ID, notice that the Save method should use the Update method, 
            //and that the repository it creates is for a Teacher and not a Student
            Service.Save(teacher);
        }
    }
}
