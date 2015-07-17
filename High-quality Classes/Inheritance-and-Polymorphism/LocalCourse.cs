namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class LocalCourse : Course
    {
        public LocalCourse(string courseName, string teacherName)
            : base(courseName, teacherName)
        {
            this.Lab = null;
        }

        public LocalCourse(string courseName, string teacherName, IList<string> students)
            : base(courseName, teacherName, students)
        {
            this.Lab = null;
        }


        private string GetStudentsAsString()
        {
            if (this.Students == null || this.Students.Count == 0)
            {
                return "{ }";
            }
            else
            {
                return "{ " + string.Join(", ", this.Students) + " }";
            }
        }

        public string Lab { get; set; }

        public override string ToString()
        {
            string result = base.ToString();

            if (this.Lab != null)
            {
                result += string.Format("; Lab = ", this.Lab);
            }

            result += " }";
            return result;
        }
    }
}
