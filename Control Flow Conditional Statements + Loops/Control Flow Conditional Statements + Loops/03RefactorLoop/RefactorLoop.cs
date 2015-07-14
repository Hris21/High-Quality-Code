namespace Control_Flow_Conditional_Statements___Loops
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class RefactorLoop
    {
        private const int GoldenNumber = 7;

        public static void Main()
        {
            Console.WriteLine("Enter the size of the array : ");
            int arraySize = int.Parse(Console.ReadLine());

            // The method below fills up the Array with the values,  you desire.
            var values = FillArray(arraySize);

            Console.Write("Enter the searched value and if it is found you get the golden number: ");
            int expectedValue = int.Parse(Console.ReadLine());
            bool valueIsFound = false;

            for (int i = 0; i < values.Length; i++)
            {
                if (i % 10 == 0)
                {
                    Console.WriteLine(values[i]);
                    if (values[i] == expectedValue)
                    {
                        valueIsFound = true;
                    }
                }
                else
                {
                    Console.WriteLine(values[i]);
                }
            }

            if (valueIsFound == true)
            {
                Console.WriteLine("Value Found {0}" + valueIsFound + " the golden number : {1} " + theGoldenNumber);
            }
        }

        internal static int[] FillArray(int arraySize)
        {
            int[] values = new int[arraySize];

            for (int i = 0; i < arraySize; i++)
            {
                Console.WriteLine("Array {0} = ", i);
                values[i] = int.Parse(Console.ReadLine());
            }

            return values;
        }
    }
}