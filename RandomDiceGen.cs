// James M.A. Pesta
// 04/11/20
// Major Assignment 1
// Dice

using System;

namespace Major_Assignment_01
{
    public class DiceRoll
    {
        public static int count = 0; // Starts a counter
        static void callDie() // a method called and started
        {
            Random r = new Random(); // New Random counter
            count++; // Adds one to the counter listed above

            int die1 = r.Next(1, 7); // First die thrown at random
            int die2 = r.Next(1, 7); // Second Die thrown at random
            int sum = die1 + die2; // Adds the two dice

            Console.WriteLine("Die 1 = " + die1); // Displays the first die
            Console.WriteLine("Die 2 = " + die2); // Displays the second die
            Console.WriteLine(); // An extra lind for spacing
            Console.WriteLine("I got " + die1 + " and " + die2); // Places tbe two die on the same line

            if ((sum % 2) == 0) // If the sum of the two dice divided by two has no remaiders
                Console.WriteLine("Evens are better than odds!"); // Display this "even" text
            else // Otherwise
                Console.WriteLine("Odds are still cool!"); // Display this "odd" text

            Console.WriteLine("Do you want to play again? \"YES\" is case sensitive"); // Ask if you want to play again

            if (Console.ReadLine() == "YES") // If "YES" run the function again
            {
                callDie();
            }
            else // Otherwise display text below with counter of dice thrown
            {
                Console.WriteLine("The number of times the dice was thrown is: " + count);
                Console.WriteLine("Nice game!");
                Console.WriteLine("Thanks for playing. Come again soon!");
            }
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Hey! Welcome to Tina's Dice Game");
            Console.WriteLine("Let's Start!");
            Console.WriteLine();

            callDie(); // Begins the function for dice
        }
    }
}