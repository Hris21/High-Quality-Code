using System;
using System.Collections.Generic;
using System.Text;

public class ExceptionsHomework
{
    public static T[] Subsequence<T>(T[] arr, int startIndex, int count)
    {
        int length = arr.Length;

        if (length == 0)
        {
            throw new ArgumentException("Array must not be empty.");
        }

        if (startIndex < 0 || startIndex > length - 1)
        {
            throw new ArgumentOutOfRangeException(string.Format("Start index must be a value between 0 and {0}.", length - 1));
        }

        if (count < 1)
        {
            throw new ArgumentOutOfRangeException(string.Format("Count must be greater than 0."));
        }

        if (startIndex + count > length)
        {
            throw new ArgumentOutOfRangeException(string.Format("'startIndex + count <= arrayLength' must hold true."));
        }

        List<T> result = new List<T>();
        for (int i = startIndex; i < startIndex + count; i++)
        {
            result.Add(arr[i]);
        }

        return result.ToArray();
    }

    public static string ExtractEnding(string str, int count)
    {
        if (count < 1)
        {
            throw new ArgumentOutOfRangeException("Count cannot be less than 1.");
        }

        if (count > str.Length)
        {
            throw new ArgumentOutOfRangeException("Count cannot be greater than length of string.");
        }

        StringBuilder result = new StringBuilder();
        for (int i = str.Length - count; i < str.Length; i++)
        {
            result.Append(str[i]);
        }

        return result.ToString();
    }

    public static bool CheckIfPrime(int number)
    {
        bool isPrime = true;

        if (number < 2)
        {
            isPrime = false;
            return isPrime;
        }

        for (int divisor = 2; divisor <= Math.Sqrt(number); divisor++)
        {
            if (number % divisor == 0)
            {
                isPrime = false;
                break;
            }
        }

        return isPrime;
    }

    public static void Main()
    {
        var substr = Subsequence("Hello!".ToCharArray(), 2, 3);
        Console.WriteLine(substr);

        var subarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 2);
        Console.WriteLine(string.Join(" ", subarr));

        var allarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 4);
        Console.WriteLine(string.Join(" ", allarr));

        // var emptyarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 0);
        // Console.WriteLine(string.Join(" ", emptyarr));

        Console.WriteLine(ExtractEnding("I love C#", 2));
        Console.WriteLine(ExtractEnding("Nakov", 4));
        Console.WriteLine(ExtractEnding("beer", 4));

        // Console.WriteLine(ExtractEnding("Hi", 100));

        Console.WriteLine("23 is prime = {0}", CheckIfPrime(23));

        List<Exam> peterExams = new List<Exam>()
        {
            new SimpleMathExam(2),
            new CSharpExam(55),
            new CSharpExam(100),
            new SimpleMathExam(1),
            new CSharpExam(0),
        };
        Student peter = new Student("Peter", "Petrov", peterExams);
        double peterAverageResult = peter.CalcAverageExamResultInPercents();
        Console.WriteLine("Average results = {0:p0}", peterAverageResult);
    }
}