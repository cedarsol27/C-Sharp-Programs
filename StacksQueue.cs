// James Pesta
// BIT143
// Major Assignment 1

using System;
using System.Collections;

namespace Stacks&Queues
{
    public class MainClass
{
    public static void Main()
    {
        Console.WriteLine("Welcome to Tina's Palace! Please place your order here:\n");

        Stack MenuS = new Stack();
        // Create a stack to store input
        Queue MenuQ = new Queue();
        // Create a queue to store input

        Console.WriteLine("\nWhat would you like to order?");
        string ReadInput = Console.ReadLine();
        // Use a string variable to store input

        while (!(string.Equals(ReadInput, "quit", StringComparison.OrdinalIgnoreCase)))
        // Have a while loop to determine if an entry is not quit, case insensitive
        {
            MenuS.Push(ReadInput);
            MenuQ.Enqueue(ReadInput);
            // Add input from entry into Menu stack and queue. The Stack is First in last out
            // The queue is First in FIrst Out

            Console.WriteLine("\nNext! What would you like?");
            ReadInput = Console.ReadLine();
            // Reads the next line, start loop over to determine if the string variable is not Quit
        }

        Console.WriteLine("\nOrder summary for the day:\n\nList of Orders:\n");
        if (MenuQ.Count == 0)
            // If the count of the MenuQ is 0 display NONE
            Console.WriteLine("NONE");
        else
            foreach (var i in MenuQ)
                Console.WriteLine(i);
        // For each element in menu, print the stored information, First in First out

        Console.WriteLine("\nOrder Tracker:\n");
        if (MenuS.Count == 0)
            Console.WriteLine("NONE");

        else
            while (MenuS.Count > 0)
                Console.WriteLine(MenuS.Pop());
        // This removes each element in the Stack item and displays each element, first in Last out
    }
}
}