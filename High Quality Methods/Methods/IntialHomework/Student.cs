namespace Methods
{
    using System;

    public class Student
    {
        private string firstName;
        private string lastName;

        public Student(string firstName, string lastName, DateTime birthDate)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.BirthDate = birthDate;
            this.AdditionalInfo = string.Empty;
        }

        public string FirstName
        {
            get
            {
                return this.FirstName;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentOutOfRangeException("First name must not be null or empty.");
                }

                this.FirstName = value;
            }

        }
        public string LastName
        {
            get
            {
                return this.LastName;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentOutOfRangeException("Last name must not be null or empty.");
                }

                this.LastName = value;
            }
        }

        public DateTime BirthDate { get; set; }

        public string AdditionalInfo { get; set; }

        public bool IsOlderThan(Student other)
        {
            DateTime firstStudentAge = this.BirthDate;
            DateTime otherStudentAge = other.BirthDate;

            bool firstStudentIsOlder = firstStudentAge < otherStudentAge;

            return firstStudentIsOlder;
        }
    }
}
