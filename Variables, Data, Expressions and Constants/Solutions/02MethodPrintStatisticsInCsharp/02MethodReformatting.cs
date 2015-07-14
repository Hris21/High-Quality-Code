namespace Solutions._02MethodPrintStatisticsInCsharp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class MethodReformatting
    {
        public static void Main()
        {
            // The data is hard-coded for test purposes.
            PrintStatistics(new double[] {83.15, 2.1, 31.2, 9.2, 31.990 }, 4);
        }
        /// <summary>
        /// Prints the maximum, minimum value and the average sum in the given range.
        /// The average sum is formed from all the values to the end index summed and then divided by their count.
        /// </summary>
        /// <param name="values">An Array with values.</param>
        /// <param name="endIndex">The end index to which the operations to proceed.(end range)</param>
        public static void PrintStatistics(double[] values, int endIndex)
        {
            // Finds the index with maximum value, then prints it's value.
            double currentValue = 0;
            for (int i = 0; i < endIndex; i++)
            {
                if (values[i] > currentValue)
                {
                    currentValue = values[i];
                }
            }
            Print(currentValue);

            // Finds the index with minimum value, then prints it's value.
            // NB! the variable currentValue is used for both operations, thus it's previous value is replaced by the new one.

            for (int i = 0; i < endIndex; i++)
            {
                if (values[i] < currentValue)
                {
                    currentValue = values[i];
                }
            }
            Print(currentValue);

            // Finds the sum of all the values until the end index, then divides them by their count,which should be equal to the end index.

            double sumOfValues = 0;
            for (int i = 0; i < endIndex; i++)
            {
                sumOfValues += values[i];
            }

            double average = sumOfValues / endIndex;
            Print(average);
        }

        internal static void Print(double variableToPrint)
        {
            Console.WriteLine(variableToPrint);
        }
    }
}
