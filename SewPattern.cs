//James M.A. Pesta
//BIT 142
//Major Assignment 02

using System;

namespace Pesta_Major_Assignment_02
{
    public class quilt
    {
        static void sewPattern(int n)
        {
            int getSpace1;
            int getSpace2;
            int getSpace3;
            int getSpace4;
            int getDot2;
            int getDot3;
            int getDot4;


            if (n <= 1)
            {
                getSpace1 = 1 * (-2) + 8;
                getSpace2 = 2 * (-2) + 8;
                getSpace3 = 3 * (-2) + 8;
                getSpace4 = 4 * (-2) + 8;
                getDot2 = 4 * 2 - 4;
                getDot3 = 4 * 3 - 4;
                getDot4 = 4 * 4 - 4;
            }
            else
            {
                int first = 0;
                int rest = 0;
                for (int i = 0; i < n - 1; i++)
                {
                    first += 2;
                    rest += 4;
                }
                getSpace1 = n * (1 * (-2) + 8) + first;
                getSpace2 = n * (2 * (-2) + 8) + rest;
                getSpace3 = n * (3 * (-2) + 8) + rest;
                getSpace4 = n * (4 * (-2) + 8) + rest;


                getDot2 = n * (4 * 2 - 4);
                getDot3 = n * (4 * 3 - 4);
                getDot4 = n * (4 * 4 - 4);
            }
            Console.WriteLine("Sure, coming right up...");

            edges(n);

            line1(getSpace1);

            diamonds(n);

            Console.WriteLine("");

            line2(getSpace2, getDot2);

            Console.WriteLine("");

            line3(getSpace3, getDot3);

            Console.WriteLine("");

            line4(getSpace4, getDot4);

            line4(getSpace4, getDot4);

            line3(getSpace3, getDot3);

            Console.WriteLine("");

            line2(getSpace2, getDot2);

            Console.WriteLine("");

            line1(getSpace1);

            diamonds(n);

            Console.WriteLine("");

            edges(n);
        }

        static void edges(int n)
        {
            string edge = "#================# ";

            for (int i = 0; i < n; i++)
            {
                Console.Write(edge);
            }
            Console.WriteLine("");
        }

        static void line1(int getSpace1)
        {
            for (int i = 1; i < getSpace1; i++)
            {
                Console.Write(" ");
            }
        }

        static void line2(int getSpace2, int getDot2)
        {
            for (int i = 1; i < getSpace2; i++)
            {
                Console.Write(" ");
            }
            Console.Write("| <>");
            for (int i = 0; i < getDot2; i++)
            {
                Console.Write(".");
            }
            Console.Write("<> |");
        }

        static void line3(int getSpace3, int getDot3)
        {
            for (int i = 1; i < getSpace3; i++)
            {
                Console.Write(" ");
            }
            Console.Write("| <>");
            for (int i = 0; i < getDot3; i++)
            {
                Console.Write(".");
            }
            Console.Write("<> |");
        }

        static void line4(int getSpace4, int getDot4)
        {
            for (int i = 1; i < getSpace4; i++)
            {
                Console.Write(" ");
            }
            Console.Write("|<>");

            for (int i = 0; i < getDot4; i++)
            {
                Console.Write(".");
            }
            Console.Write("<>|");
            Console.WriteLine("");
        }

        static void diamonds(int n)
        {
            Console.Write("| ");
            for (int i = 0; i < n * 2; i++)
            {
                Console.Write("<>");
            }
            Console.Write(" |");

        }
        public static void Main(string[] args)
        {


            Console.WriteLine("Welcome to Tina's Quilts! I am glad you're here!");
            Console.WriteLine("");
            Console.WriteLine("What size quilt would you like?");

            int userInput = Convert.ToInt32(Console.ReadLine());

            sewPattern(userInput);
        }
    }
}
