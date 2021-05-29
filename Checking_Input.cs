using System;

namespace Lecture8Examples
{
    class MainClass
    {
        public static void Intro()
        {
            Console.WriteLine("Welcome to my function app. Please choose from the following apps:");
            Console.WriteLine("1. Sum of an integer");
            Console.WriteLine("2. Sum of the integer is 30 or the integer is 30");
            //if (Convert.ToInt32(Console.ReadLine()) == 1)
            //{
            //    IntegerSum();
            //}

            //if (Convert.ToInt32(Console.ReadLine()) == 2)
            //{
            //    Sum30();
            //}

            if (Convert.ToInt32(Console.ReadLine()) == 3)
            {
                StringCheck();
            }

            else
            {
                Console.WriteLine("Please try again");
            }
        }


        public static void IntegerSum()
        {
            Console.WriteLine("Enter an integer to determine the sum of said integer");
            int num = Convert.ToInt32(Console.ReadLine());
            int sum = 0;
            while (num > 0)
            {
                sum = sum + num % 10;
                num = num / 10;
            }
            Console.WriteLine(sum);
        }

        public static void Sum30()
        {
            Console.WriteLine("Enter an integer to determine the sum of said integer is 30 or if the number is 30");
            int num = Convert.ToInt32(Console.ReadLine());
            int sum = 0;

            if (num == 30)
            {
                Console.WriteLine("True");
            }
            else
            {
                while (num > 0)
                {
                    sum = sum + num % 10;
                    num = num / 10;
                }
                if (sum == 30)
                {
                    Console.WriteLine("True");
                }
                else
                {
                    Console.WriteLine("False");

                }
            }
        }


        public static void StringCheck()
        {
            Console.WriteLine("Please enter a word, phrase, or sentence which will check to see if \'Hello\' is the starting word:");
            string str = Console.ReadLine();
            string[] words = str.Split(' ');
            if ((words.Length == 0 && str == "Hello") || (words[0] == "Hello"))
            {
                Console.WriteLine("The Sentence does begin with \'Hello\'!");
            }
            else
            {
                Console.WriteLine("The sentence does not begin with \'Hello\'.");
            }
        }

        public static void Main(string[] args)
        {
            Intro();
        }
    }
}