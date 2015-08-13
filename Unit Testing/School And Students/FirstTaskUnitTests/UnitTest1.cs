namespace FirstTaskUnitTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Students_and_courses;
    using System;
    using System.Collections.Generic;

    [TestClass]
    public class UnitTest1
    {
        private const string NAME = "Michael";

        [TestMethod]
        [ExpectedException(typeof(Exception), AllowDerivedTypes = true)]
        public void ExpectedToThrowWhenStudentNameIsEmpty()
        {
            var student = new Student(string.Empty);
        }

        [TestMethod]
        public void ExpectedToGenerateValidId()
        {
            var student = new Student(NAME);
            Assert.AreEqual(10001, student.Id);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), AllowDerivedTypes = true)]
        public void ExpectIDvalueToNotOverFlow()
        {
            var listOfStudents = new List<Student>();
            for (int i = 0; i < 100003; i++)
            {
                var randomName = i.ToString();
                var student = new Student(randomName);
                listOfStudents.Add(student);
            }
            var course = new Course(listOfStudents);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), AllowDerivedTypes = true)]
        public void ExpectedMaxStudentsCountToNotExceedThirty()
        {
            var listOfStudents = new List<Student>();
            for (int i = 0; i < 33; i++)
            {
                var randomName = i.ToString();
                var student = new Student(randomName);
                listOfStudents.Add(student);
            }
            var course = new Course(listOfStudents);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), AllowDerivedTypes = true)]
        public void TestStudentIdGetter()
        {
            for (int i = 0; i < 90001; i++)
            {
                var student = new Student("A#" + i);
                var currId = student.Id;
            }
        }

        [TestMethod]
        public void TestSudentNameGetter()
        {
            var student = new Student(NAME);
            Assert.AreEqual(student.Name, NAME);
        }

        [TestMethod]
        public void TestCourseAddStudent()
        {
            var students = new List<Student>();
            var course = new Course(students);

            var anotherStudent = new Student("Adam");
            course.AddStudent(anotherStudent);
            Assert.AreEqual(students.Count + 1, course.Students.Count);
        }

        [TestMethod]
        public void TestCourseRemoveStudent()
        {
            var students = new List<Student>();
            var course = new Course(students);

            var student = new Student("Adam");
            course.AddStudent(student);
            course.AddStudent(student);
            course.RemoveStudent(student);
            Assert.AreEqual(students.Count + 1, course.Students.Count);
        }
    }
}