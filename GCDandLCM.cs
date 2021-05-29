using System;

namespace GCDandLCM
{
    class MainClass
    {
        public static void Main()
        {
            int one, two, gcd, lcm;
            Console.WriteLine("Enter two numbers: ");
            Console.Write("Number one: ");

            one = Convert.ToInt32(Console.ReadLine());

            Console.Write("Number two: ");
            two = Convert.ToInt32(Console.ReadLine());

            gcd = GCD(one, two);
            Console.WriteLine("{0} is the greatest common divisor.", gcd);
            lcm = one * two / gcd;
            Console.WriteLine("The lowest common multiple is {0}.", lcm);

        }
        static int GCD(int one, int two)
        {            
            if (two == 0)
                return one;
            else
            {
                return GCD(two, one % two);
            }
        }
    }
}
