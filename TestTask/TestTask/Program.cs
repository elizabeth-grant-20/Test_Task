using System;
using System.IO;

// Bliednykh Yelizaveta Test Task

namespace TestTask
{
    class Program
    {
        public static (int, int) ProcessDataFromUser()
        {
            Console.WriteLine("Please, enter the first (minimum) value of the range: ");
            bool isFirstValueNumber = int.TryParse(Console.ReadLine(), out int firstValue);

            while (!isFirstValueNumber)
            {
                Console.WriteLine("You should enter a number.");
                isFirstValueNumber = int.TryParse(Console.ReadLine(), out firstValue);
            }

            Console.WriteLine("Please, enter the second (maximum) value of the range: ");
            bool isSecondValueNumber = int.TryParse(Console.ReadLine(), out int secondValue);

            while (!isSecondValueNumber)
            {
                Console.WriteLine("You should enter a number.");
                isSecondValueNumber = int.TryParse(Console.ReadLine(), out secondValue);
            }

            if (firstValue > secondValue)
            {
                int tmp = firstValue;
                firstValue = secondValue;
                secondValue = tmp;
            }

            return (firstValue, secondValue);
        }

        public static void WriteResultsInFile(int minValue, int maxValue)
        {
            string filePath = "TestTask.txt";

            using StreamWriter sw = new StreamWriter(filePath, append: true);
            sw.WriteLine($"Minimum value: {minValue}; maximum value: {maxValue}");
        }

        static void Main(string[] args)
        {
            (int first, int second) = ProcessDataFromUser();
            WriteResultsInFile(first, second);

            Console.ReadKey();
        }
    }
}
