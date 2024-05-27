using System;
using System.Net;
using System.Runtime.ExceptionServices;
using System.IO;
using System.Collections.Generic;
using System.Linq;

class Program1
{
    static void Main(string[] args)
    {
        int lowNumber, highNumber;

        Console.Write("Enter the low number: ");
        lowNumber = int.Parse(Console.ReadLine());

        Console.Write("Enter the high number: ");
        highNumber = int.Parse(Console.ReadLine());

        int difference = highNumber - lowNumber;
        Console.WriteLine($"The difference between {highNumber} and {lowNumber} is {difference}.");
    }

}

class Program2
{
    static void Main(string[] args)
    {
        int lowNumber, highNumber;

        do
        {
            Console.Write("Enter a low number: ");
            lowNumber = int.Parse(Console.ReadLine());
        } while (lowNumber <= 0);

        do
        {
            Console.Write("Enter a high number: ");
            highNumber = int.Parse(Console.ReadLine());
        } while (highNumber <= lowNumber);

    }
}


class Program3
{
    static void Main(string[] args)
    {
        int lowNumber;
        do
        {
            Console.Write("Enter a low number: ");
            lowNumber = int.Parse(Console.ReadLine());
        } while (lowNumber <= 0);

        int highNumber;
        do
        {
            Console.Write("Enter a high number: ");
            highNumber = int.Parse(Console.ReadLine());
        } while (highNumber <= lowNumber);

        int difference = highNumber - lowNumber;
        Console.WriteLine($"The difference between {highNumber} and {lowNumber} is {difference}.");

        int[] numbers = new int[highNumber - lowNumber + 1];
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = lowNumber + i;
        }
        string path = @"C:\My_Lab0\Program.cs\numbers.txt";
        if (!File.Exists(path))
        {
            using (StreamWriter sw = File.CreateText(path))
            {
                for (int i = numbers.Length - 1; i >= 0; i--)
                {
                    sw.WriteLine(numbers[i]);
                }
            }
        }
    }

    class Program4
    {
        static void Main(string[] args)
        {
            double lowNumber = GetValidLowNumber();
            double  highNumber = GetValidHighNumber(lowNumber);

            List<double> numbers = new List<double>();
            for (double i = lowNumber; i <= highNumber; i++)
            {
                numbers.Add(i);
            }


            using (StreamWriter writer = new StreamWriter("numbers.txt"))
            {
                for (int i = numbers.Count - 1; i >= 0; i--)
                {
                    writer.WriteLine(numbers[i]);
                }
            }

            double sum = 0;
            using (StreamReader reader = new StreamReader("numbers.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    sum += double.Parse(line);
                }
            }
            Console.WriteLine($"The sum of the numbers is {sum}.");

            Console.WriteLine("Prime numbers between lowNumber and highNumber:");
            for (double i = lowNumber; i <= highNumber; i++)
            {
                if (IsPrime((int)i))
                {
                    Console.WriteLine(i);
                }
            }
        }

        static double GetValidLowNumber()
        {
            double lowNumber;
            do
            {
                Console.Write("Enter a low number: ");
                lowNumber = double.Parse(Console.ReadLine());
            } while (lowNumber <= 0);

            return lowNumber;
        }

        static double GetValidHighNumber(double lowNumber)
        {
            double highNumber;
            do
            {
                Console.Write("Enter a high number: ");
                highNumber = double.Parse(Console.ReadLine());
            } while (highNumber <= lowNumber);

            return highNumber;
        }

        static bool IsPrime(int number)
        {
            if (number <= 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;
            for (int i = 3; i <= Math.Sqrt(number); i += 2)
            {
                if (number % i == 0) return false;
            }
            return true;
        }
    }
}