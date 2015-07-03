namespace Naming_Identifiers_in_C_Sharp
{
    using System;
    public class OuterClass
    {
        private const int MAX_COUNT = 6;
        public class InnerClass
        {
            public static void PrintVariableAsString(bool variableToConvert)
            {
                var convertedToString = variableToConvert.ToString();
                Console.WriteLine(convertedToString);
            }
        }
        public static void Main()
        {
            var newInnerClass = new InnerClass();
            InnerClass.PrintVariableAsString(true);
        }
    }
}