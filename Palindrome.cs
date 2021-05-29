using System;
using System.Text.RegularExpressions;

namespace Palindrome
{
    class MainClass
    {
        public static void Main()
        {
            Console.Write("Please enter a word or phrase to check if it's a palindrome: ");
            string Input = Console.ReadLine();
            string Adjust = Regex.Replace(Input, @"\s", "");
            bool Correct;

            Correct = PalindromeCheck(Adjust);
            if (Correct == true)
                Console.WriteLine("The word {0} is a palindrome.", Input);
            else
                Console.WriteLine("The word {0} is NOT a palindrome.", Input);
        }
        public static bool PalindromeCheck(string a)
        {
            if (a.Length == 1 || a.Length == 0)
                return true;
            else
            {
                if (a[0] != a[a.Length - 1])
                    return false;
                else
                    return PalindromeCheck(a.Substring(1, a.Length - 2));
            }
        }
    }
}
