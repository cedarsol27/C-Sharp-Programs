using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace herewegoagain
{
    public class Node
    {
        public string data;
        public Node next;
        public Node(string i)
        {
            data = i;
            next = null;
        }
        public void AddToFront(string data)
        {
            if (next == null)
                next = new Node(data);
            else
                next.AddToFront(data);
        }
        public void PrintQueue()
        {
            if (next != null)
            {
                Console.WriteLine(data);
                next.PrintQueue();
            }
            else
                Console.WriteLine(data);
        }
    }
    public class MyList
    {
        public Node HeadNode;
        public MyList()
        {
            HeadNode = null;
        }
        public void AddToFront(string data)
        {
            if (HeadNode) == null)
                    HeadNode = new Node(data);
            else
            {
                Node temp = new Node(data);
                temp.next = HeadNode;
                HeadNode = temp;
            }
        }
        public void PlaceBeginning(string data)
        {
            if (HeadNode == null)
                HeadNode = new Node(data);
            else
                AddToBeginning(data);
        }
    }
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Gouge Bank. We really want your money. Please enter your name for queue:");
            Queue Names = new Queue();
            string UserInput = Console.ReadLine();

            while (!string.Equals(UserInput, "quit", StringComparison.OrdinalIgnoreCase))
            {
                Names.Enqueue(UserInput);
                Console.WriteLine("\nWho is next in line? Quick, give us your money!");
                UserInput = Console.ReadLine();
            }
            Console.WriteLine("\nHave you seen the first guest?");
            string confirm = Console.ReadLine();
            while (string.Equals(confirm, "yes", StringComparison.OrdinalIgnoreCase))
            {
                Names.Dequeue();
                Console.WriteLine("Have you seen the next guest in line?");
                confirm = Console.ReadLine();
            }
            Console.WriteLine("Would you like to search for a customer?");
            if (string.Equals(Console.ReadLine(), "yes", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("\nEnter the name you are searching for:");
                string Search = Console.ReadLine();
                Console.WriteLine(Names.Contains(Search));
            }
            Console.WriteLine("\nWould you like to see the list of people?");
            if (string.Equals(Console.ReadLine(), "yes", StringComparison.OrdinalIgnoreCase))
            {
                foreach (object i in Names)
                    Console.WriteLine(i);
            }
            Console.WriteLine("\nWould you like to count the list of people?");
            if (string.Equals(Console.ReadLine(), "yes", StringComparison.OrdinalIgnoreCase))
                Console.WriteLine("\nThe count of people in line is: " + Names.Count);
        }
    }
}