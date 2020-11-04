using System;

namespace DisplayDigitsRecursion
{
    class MainClass
    {
        static void Main()
        {
            Console.Write("Please enter the digits to perform evaluation: ");
            long userInput = Convert.ToInt64(Console.ReadLine());
            DisplayDigits(userInput);
        }
        static void DisplayDigits(long a)
        {
            if (a < 10)
            {
                Console.Write(" {0} ", a);
                return;
            }
            DisplayDigits(a / 10);
            Console.Write(" {0} ", a % 10);
        }
    }
}
