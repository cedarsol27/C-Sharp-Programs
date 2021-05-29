using System;
using System.Collections;


namespace CustomerQueue
{
    public class Queue
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Gouge Bank. We really want your money. Please enter your name for queue");
            Queue Names = new Queue();
            string UserInput = Console.ReadLine();

            while (!(string.Equals(UserInput, "quit", StringComparison.OrdinalIgnoreCase)))
            {
                Names.Enqueue(UserInput);
                Console.WriteLine("\nWho is next in line? Quick, give us your money!");
            }

            foreach (object i in Names)
            {
                Console.WriteLine(i);
            }

        }
    }
}
