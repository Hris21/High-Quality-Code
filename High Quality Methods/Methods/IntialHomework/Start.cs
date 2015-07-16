namespace Methods
{
    using System;

    public class Start
    {
        public static void Main()
        {
            Console.WriteLine(MathematicalUtilities.CalcTriangleArea(3, 4, 5));

            Console.WriteLine(MathematicalUtilities.NumberToDigit(5));

            Console.WriteLine(MathematicalUtilities.FindMaxValue(5, -1, 3, 2, 14, 2, 3));

            MathematicalUtilities.PrintAsNumber(1.3, "f");
            MathematicalUtilities.PrintAsNumber(0.75, "%");
            MathematicalUtilities.PrintAsNumber(2.30, "r");

            Console.WriteLine(MathematicalUtilities.CalculateDistance(3, -1, 3, 2.5));
            Console.WriteLine("Horizontal? " + MathematicalUtilities.IsHorizontal(-1, 2.5));
            Console.WriteLine("Vertical? " + MathematicalUtilities.IsVertical(3, 3));

            Student hristiyan = new Student("Hristiyan", "Bale", new DateTime(1997, 08, 21));
            Student stella = new Student("Stiliyana", "Dimitrova", new DateTime(1998, 11, 17));

            Console.WriteLine("{0} older than {1} -> {2}", hristiyan.FirstName, stella.FirstName, hristiyan.IsOlderThan(stella));
        }
    }
}
