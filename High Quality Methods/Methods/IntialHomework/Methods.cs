namespace Methods
{
    using System;

    public static class MathematicalUtilities
    {
        /// <summary>
        /// In case we know the three sides Heron's Formula would be the perfect choice.
        /// </summary>
        /// <returns>The area of a triangle.</returns>
        public static double CalcTriangleArea(double a, double b, double c)
        {
            double sideA = a;
            double sideB = b;
            double sideC = c;

            if (sideA <= 0 || sideB <= 0 || sideC <= 0)
            {
                throw new ArgumentException("Sides should be positive.");
            }

            bool isValidTriangle = (sideA + sideB > sideC) && (sideA + sideC > sideB) && (sideB + sideC > sideA);

            if (!isValidTriangle)
            {
                throw new ArgumentOutOfRangeException("These sides does not form a valid triangle.");
            }

            double semiPerimeter = (sideA + sideB + sideC) / 2;
            double area = Math.Sqrt(semiPerimeter * (semiPerimeter - sideA) * (semiPerimeter - sideB) * (semiPerimeter - sideC));

            return area;
        }

        public static string NumberToDigit(int number)
        {
            if (number > 10)
            {
                throw new ArgumentOutOfRangeException("The method is modified to work correctly only with single digit input.");
            }

            string theInputAsString = string.Empty;

            switch (number)
            {
                case 0: theInputAsString = "zero"; break;
                case 1: theInputAsString = "one"; break;
                case 2: theInputAsString = "two"; break;
                case 3: theInputAsString = "three"; break;
                case 4: theInputAsString = "four"; break;
                case 5: theInputAsString = "five"; break;
                case 6: theInputAsString = "six"; break;
                case 7: theInputAsString = "seven"; break;
                case 8: theInputAsString = "eight"; break;
                case 9: theInputAsString = "nine"; break;
            }

            return theInputAsString;
        }

        public static int FindMaxValue(params int[] elements)
        {
            if (elements == null || elements.Length == 0)
            {
                throw new ArgumentException("The arguments cannot be and empty array or null.");
            }

            int argumentsLength = elements.Length;
            int biggestValue = 0;

            for (int i = 1; i < argumentsLength; i++)
            {
                if (elements[i] > biggestValue)
                {
                    biggestValue = elements[i];
                }
            }

            return biggestValue;
        }

        public static void PrintAsNumber(object number, string format)
        {
            if (format == "f")
            {
                Console.WriteLine("{0:f2}", number);
            }

            if (format == "%")
            {
                Console.WriteLine("{0:p0}", number);
            }

            if (format == "r")
            {
                Console.WriteLine("{0,8}", number);
            }

            else
            {
                throw new ArgumentException("Unrecognized format.");
            }
        }

        public static double CalculateDistance(double x1, double y1, double x2, double y2)
        {
            double distance = Math.Sqrt(((x2 - x1) * (x2 - x1)) + ((y2 - y1) * (y2 - y1)));
            return distance;
        }

        public static bool IsHorizontal(double y1, double y2)
        {
            bool isHorizontal = y1 == y2;
            return isHorizontal;
        }

        public static bool IsVertical(double x1, double x2)
        {
            bool isVertical = (x1 == x2);
            return isVertical;
        }
    }
}
