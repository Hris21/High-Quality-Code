namespace MathProblem
{
    using System;
    using System.Text;

    public class MathProblem
    {
        public const int BaseNumeralSystem = 19;

        public static void Main()
        {
            string input = Console.ReadLine();
            string[] numbersIn19Base = input.Split(' ');

            // sum in decimal the numbers in 19-base numeral system
            long sumInDecimal = 0;

            for (int i = 0; i < numbersIn19Base.Length; i++)
            {
                long currentNumberInDecimal = GetDecimalRepresentationOf19BaseNumber(numbersIn19Base[i]);
                sumInDecimal += currentNumberInDecimal;
            }

            // convert sum in decimal to 19-base numeral system
            StringBuilder sumIn19BaseReversed = new StringBuilder();
            long decimalNum = sumInDecimal;

            while (decimalNum > 0)
            {
                int remainder = (int)decimalNum % BaseNumeralSystem;
                char letter = (char)(remainder + 97);
                sumIn19BaseReversed.Append(letter);
                decimalNum /= BaseNumeralSystem;
            }

            StringBuilder sumIn19BaseCorrectOrder = new StringBuilder();
            for (int i = sumIn19BaseReversed.Length - 1; i >= 0; i--)
            {
                sumIn19BaseCorrectOrder.Append(sumIn19BaseReversed[i]);
            }

            Console.WriteLine("{0} = {1}", sumIn19BaseCorrectOrder.ToString(), sumInDecimal);
        }

        private static long RaiseNumberToPower(int number, int power)
        {
            long result = 1;

            for (int i = 0; i < power; i++)
            {
                result *= number;
            }

            return result;
        }

        private static long GetDecimalRepresentationOf19BaseNumber(string numberIn19Base)
        {
            long decimalNumber = 0;
            int power = 0;

            for (int i = numberIn19Base.Length - 1; i >= 0; i--)
            {
                int currentDigit = numberIn19Base[i] - 97;
                decimalNumber += currentDigit * RaiseNumberToPower(BaseNumeralSystem, power);
                power++;
            }

            return decimalNumber;
        }
    }
}