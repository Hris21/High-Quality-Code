namespace Compare_simple_Maths
{
    using System;
    using System.Diagnostics;

    class SimpleMathComparer
    {
        public static void DisplayExecutionTime(Action action)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            action();
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
        }

        internal static void Add()
        {
            Console.Write("Addition of int:   ");
            DisplayExecutionTime(() =>
            {
                int sum = 0;
                for (int i = 0; i < 3990099; i++)
                {
                    sum += 100;
                }
            });

            Console.Write("Addition of long:  ");
            DisplayExecutionTime(() =>
            {
                long sum = 0L;
                for (int i = 0; i < 3990099; i++)
                {
                    sum += 100L;
                }
            });

            Console.Write("Addition of float:  ");
            DisplayExecutionTime(() =>
            {
                float sum = 0f;
                for (int i = 0; i < 3990099; i++)
                {
                    sum += 100f;
                }
            });

            Console.Write("Addition of double:  ");
            DisplayExecutionTime(() =>
            {
                double sum = 0.0;
                for (int i = 0; i < 3990099; i++)
                {
                    sum += 100.0;
                }
            });

            Console.Write("Addition of decimal: ");
            DisplayExecutionTime(() =>
            {
                decimal sum = 0m;
                for (int i = 0; i < 3990099; i++)
                {
                    sum += 100m;
                }
            });
        }
        internal static void Substract()
        {
            Console.Write("Substraction of int:  ");
            DisplayExecutionTime(() =>
            {
                int sum = 3990099;
                for (int i = 0; i < 39909; i++)
                {
                    sum -= 100;
                }
            });

            Console.Write("Substraction of long: ");
            DisplayExecutionTime(() =>
            {
                long sum = 3990099L;
                for (int i = 0; i < 39909; i++)
                {
                    sum -= 100L;
                }
            });

            Console.Write("Substraction of float: ");
            DisplayExecutionTime(() =>
            {
                float sum = 3990099f;
                for (int i = 0; i < 39909; i++)
                {
                    sum -= 100f;
                }
            });

            Console.Write("Substraction of double: ");
            DisplayExecutionTime(() =>
            {
                double sum = 3990099;
                for (int i = 0; i < 39909; i++)
                {
                    sum -= 100.0;
                }
            });

            Console.Write("Substraction of decimal: ");
            DisplayExecutionTime(() =>
            {
                decimal sum = 39909m;
                for (int i = 0; i < 3990099; i++)
                {
                    sum -= 100m;
                }
            });
        }

        internal static void Increment()
        {
            Console.Write("Increment of int: ");
            DisplayExecutionTime(() =>
            {
                int intCrement = 0;  // See the pun  ? Funny  ? No ? meh...
                for (int i = 0; i < 3990099; i++)
                {
                    intCrement++;
                }
            });
            Console.Write("Increment of long: ");
            DisplayExecutionTime(() =>
            {
                long longCrement = 0;
                for (long i = 0; i < 3990099; i++)
                {
                    longCrement++;
                }
            });
            Console.Write("Increment of float: ");
            DisplayExecutionTime(() =>
            {
                float floatCrement = 0f;
                for (float i = 0; i < 3990099f; i++)
                {
                    floatCrement++;
                }
            });
            Console.Write("Increment of double: ");
            DisplayExecutionTime(() =>
            {
                double doubleCrement = 0;
                for (double i = 0; i < 3990099; i++)
                {
                    doubleCrement++;
                }
            });
            Console.Write("Increment of decimal: ");
            DisplayExecutionTime(() =>
            {
                decimal outOfOriginalityCrement = 0m;
                for (decimal i = 1; i < 3990099m; i++)
                {
                    outOfOriginalityCrement++;
                }
            });

        }

        internal static void Multiply()
        {
            Console.Write("Multiplication of int: ");
            DisplayExecutionTime(() =>
            {
                int toBeMultiplied = 1;
                for (int multiplier = 1; multiplier < 7777; multiplier++)
                {
                    toBeMultiplied *= multiplier;
                }
            });
            Console.Write("Multiplication of long: ");
            DisplayExecutionTime(() =>
            {
                long toBeMultiplied = 1;
                for (long multiplier = 1; multiplier < 7777; multiplier++)
                {
                    toBeMultiplied *= multiplier;
                }
            });
            Console.Write("Multiplication of float: ");
            DisplayExecutionTime(() =>
            {
                float toBeMultiplied = 1f;
                for (float multiplier = 1; multiplier < 7777f; multiplier++)
                {
                    toBeMultiplied *= multiplier;
                }
            });
            Console.Write("Multiplication of double: ");
            DisplayExecutionTime(() =>
            {
                double toBeMultiplied = 1;
                for (double muliplier = 1; muliplier < 7777; muliplier++)
                {
                    toBeMultiplied *= muliplier;
                }
            });
            Console.Write("Multiplication of decimal: ");
            DisplayExecutionTime(() =>
            {
                decimal toBeMulltiplied = 1m;
                for (int multiplier = 1; multiplier < 7; multiplier++)
                {
                    toBeMulltiplied *= 1.0m;
                }
            });

        }

        internal static void Divide()
        {
            Console.Write("Diviation of int: ");
            DisplayExecutionTime(() =>
            {
                int divident = 3990099;
                for (int divider = 1; divider <= 3990099; divider++)
                {
                    divident /= divider;
                }
            });
            Console.Write("Diviation of long: ");
            DisplayExecutionTime(() =>
            {
                long divident = 3990099;
                for (long divider = 1; divider <= 3990099; divider++)
                {
                    divident /= divider;
                }
            });
            Console.Write("Diviation of float: ");
            DisplayExecutionTime(() =>
            {
                float divident = 3990099f;
                for (float divider = 1; divider <= 3990099f; divider++)
                {
                    divident /= divider;
                }
            });
            Console.Write("Diviation of double: ");
            DisplayExecutionTime(() =>
            {
                double divident = 3990099;
                for (double divider = 1; divider <= 3990099; divider++)
                {
                    divident /= divider;
                }
            });
            Console.Write("Diviation of decimal: ");
            DisplayExecutionTime(() =>
            {
                decimal divident = 3990099m;
                for (decimal divider = 1; divider <= 3990099m; divider++)
                {
                    divident /= divider;
                }
            });

        }
        static void Main()
        {
            Add();
            Console.WriteLine(new string('=', 45));
            Substract();
            Console.WriteLine(new string('=', 45));
            Multiply();
            Console.WriteLine(new string('=', 45));
            Increment();
            Console.WriteLine(new string('=', 45));
            Divide();
            Console.WriteLine("The End");
        }
    }
}
