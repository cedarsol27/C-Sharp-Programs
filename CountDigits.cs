using System;

namespace CountDigitsRecursion
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.Write("Please enter the numbers to separate: ");
            long userInput = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine("The number {0} contains {1} digits.",userInput, NumbersIn(userInput, 0));
        }

        public static int NumbersIn(long userInput, int count)
        {
            if ( userInput == 0)
                return count;
            return NumbersIn(userInput / 10, ++count);
        }
    }
}