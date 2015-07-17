namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;

    class CoursesExamples
    {
        static void Main()
        {
            LocalCourse localCourse = new LocalCourse("Databases", "John Doe");
            Console.WriteLine(localCourse);

            localCourse.Lab = "Enterprise";
            Console.WriteLine(localCourse);

            localCourse.Students = new List<string>() { "Peter", "Maria" };
            Console.WriteLine(localCourse);

            localCourse.TeacherName = "Svetlin Nakov";
            localCourse.Students.Add("Milena");
            localCourse.Students.Add("Todor");
            Console.WriteLine(localCourse);

            OffsiteCourse offsiteCourse = new OffsiteCourse(
                "PHP and WordPress Development",
                "Jane Doe",
                new List<string>() { "Thomas", "Ani", "Steve" });
            Console.WriteLine(offsiteCourse);
        }
    }
}
