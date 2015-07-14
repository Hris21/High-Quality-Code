namespace Control_Flow_Conditional_Statements___Loops
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Problem 1 – Three Numbers
    /// You are given 3 integer number A, B and C. Find:
    /// The biggest number among them
    /// The smallest number among them
    /// The arithmetic mean of the three numbers
    /// The arithmetic mean is the sum of a collection of numbers divided by the number of numbers in the
    /// collection. The result should be rounded with 2 digits after the decimal point.
    /// </summary>
    class ThreeNumbersProblem
    {
        public static void Main()
        {
            int valueOne = int.Parse(Console.ReadLine());
            int valueTwo = int.Parse(Console.ReadLine());
            int valueThree = int.Parse(Console.ReadLine());
            int maxValue = int.MinValue;
            int minValue = int.MaxValue;

            if (maxValue < valueOne)
            {
                maxValue = valueOne;
            }

            if (maxValue < valueTwo)
            {
                maxValue = valueTwo;
            }

            if (maxValue < valueThree)
            {
                maxValue = valueThree;
            }

            if (minValue > valueOne)
            {
                minValue = valueOne;
            }

            if (minValue > valueTwo)
            {
                minValue = valueTwo;
            }

            if (minValue > valueThree)
            {
                minValue = valueThree;
            }

            double valuesSummed = (valueOne + valueTwo + valueThree) / 3.00d;

            Print(minValue, maxValue);
            Console.WriteLine("{0:F2}", valuesSummed);
        }

        public static void Print(int minValue, int maxValue)
        {
            Console.WriteLine("The smallest value is {0} " + " The biggest value is {1} ", minValue, maxValue);
        }
    }
}