namespace Naming_Identifiers_in_C_Sharp
{
    public class MainClass
    {
        internal enum Sex
        {
            Male, Female
        };

        internal class Person
        {
            public Sex PersonSex { get; set; }
            public string PersonName { get; set; }
            public int PersonAge { get; set; }
        }

        public void GeneratePerson(int PersonID)
        {
            Person newPerson = new Person();
            newPerson.PersonAge = PersonID;

            if (PersonID % 2 == 0)
            {
                newPerson.PersonName = "John";
                newPerson.PersonSex = Sex.Male;
            }
            else
            {
                newPerson.PersonName = "Jenny";
                newPerson.PersonSex = Sex.Female;
            }
        }
    }
}