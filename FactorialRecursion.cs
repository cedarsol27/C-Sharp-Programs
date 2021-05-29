using System;

namespace Factorial
{
    class Recursion
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter a value for a factorial function: ");
            int userInput = Convert.ToInt32(Console.ReadLine());
            int display = Factorial(userInput);
            Console.WriteLine("The value is: " + display);
        }
        public static int Factorial(int i)
        {
            int j;
            if (i == 1)
                return 1;
            else
            {
                j = Factorial(i - 1) * i;
                return j;
            }
        }
    }
}
