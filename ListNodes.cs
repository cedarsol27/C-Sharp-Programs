// James Pesta
// BIT143
// Major Assignment 2 - Celebrity seating

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebritySeating
{
    public class Node
    {
        public string data; // This is a string called data. Whatever is in the parenthesis of the method, call it data.
        public Node next;   // This calls on the class Node and create a operation called next.
        public Node(string i) // This a constructor. Look to the attributes on the node method.
        {
            data = i;
            next = null; // Next is an empty node
        }


        public void AddToEnd(string data) // This will add a new data and node to the end of another node
        {
            if (next == null)
                next = new Node(data); // if the next node is empty/non-existing, create a new data type at the end
            else
                next.AddToEnd(data); // This will pass over the nodes until next node is null in order to construct a new node
        }                            // This is a recurrsion call


        public void Print()
        {
            if (next != null) // If the next node is not null, print next node
            {
                Console.Write(data + ", ");
                next.Print(); // This is a recursion because print is inside of print
            }
            else
                Console.WriteLine(data); // This is to prevent a comma at the end
        }

        public void PlaceBeginning(string data) // this places the data at the beginning, useful for moving nodes
        {
            if (next == null)
                next = new Node(data); // if the first node of a data is null, create a new node
            else
            {
                Node temp = new Node(data)
                {
                    next = this.next // Whatever the next node of temp, now null, becomes the value of the HeadNode
                }; // if there is data, create a new node called temp
                this.next = temp; // whatever the data is in temp is now transferred into the headNode
            }

        }


    }
    public class MyList // This creates the first node
    {
        public Node headNode; // This refers to the Node class above
        public MyList()
        {
            headNode = null;
        }
        public void AddToEnd(string data)
        {
            if (headNode == null)
                headNode = new Node(data);
            else
                headNode.AddToEnd(data);
        }

        public void AddToBeginning(string data)
        {
            if (headNode == null)
                headNode = new Node(data); // if the first node of a data is null, create a new node
            else
            {
                Node temp = new Node(data); // if there is data, create a new node called temp
                temp.next = headNode; // Whatever the next node of temp, now null, becomes the value of the HeadNode
                headNode = temp; // whatever the data is in temo is now transferred into the headNode
            }

        }

        public void PlaceBeginning(string data)
        {
            if (headNode == null)
                headNode = new Node(data);
            else
                AddToBeginning(data);
        }

        public void DeleteData(string data) // Deletes the data from the celebrity that needs to be moved. like a copy really
        {
            if (headNode != null)
            {
                Node curr = headNode;
                if (curr.data == data)     // put the data in the method into the current node
                    headNode = headNode.next;
                else
                {
                    while (curr.next != null) // this bumps up the nodes until the next node appears to be null
                    {
                        if (curr.next.data == data)
                        {
                            curr.next = curr.next.next;
                            return;
                        }
                        curr = curr.next;
                    }
                }
            }
        }


        public void Print()
        {
            if (headNode != null) // If this is a valid node, then print
                headNode.Print();
        }

        public void CheckForMatch(string userInput)
        {
            if (headNode != null) // If the node is not null, check to see if String is compared
            {
                Node curr = headNode;
                while (curr != null)
                {
                    if (curr.data == userInput)
                    {
                        DeleteData(curr.data); // delete the current data
                        PlaceBeginning(userInput); // use the userInput to insert because they will match
                    }
                    curr = curr.next;
                }
            }
        }
    }
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Hi, Welcome to Tinas Planning! Here are a few options for the seating arrangement for your event!\n");

            MyList celebrity = new MyList(); // Call upon the class MyList, make a new MyList object and call it celebrity

            celebrity.AddToEnd("Hasan Minhaj"); // Call upon the object celebrity and perform the method AddToEnd which creates a new string
            celebrity.AddToEnd("Nick Jonas");   // These strings are the celebrity names, placed inside the element of a node
            celebrity.AddToEnd("Priyanka Chopra");
            celebrity.AddToEnd("Angelina Jolie");
            celebrity.AddToEnd("Varun Dhawan");
            celebrity.AddToEnd("Zayn Malik");
            celebrity.AddToEnd("Taylor Swift");
            celebrity.AddToEnd("Shahrukh Khan");
            celebrity.AddToEnd("Selena Gomez");
            celebrity.AddToEnd("Kim Kardashian");
            celebrity.AddToEnd("Salman Khan");
            celebrity.AddToEnd("Sonam Kapoor");
            celebrity.AddToEnd("Kevin Hart");
            celebrity.AddToEnd("Amitabh Bachchan");
            celebrity.AddToEnd("Kanye West");

            celebrity.Print();
            Console.WriteLine("\n\nWho Would you like to seat first?");

            string userInput = Console.ReadLine();
            while (!string.Equals(userInput, "finish", StringComparison.OrdinalIgnoreCase))
            {
                celebrity.CheckForMatch(userInput);
                Console.WriteLine("\nOkay, here's the new arrangement:");
                celebrity.Print();
                Console.WriteLine();
                Console.WriteLine("\nWho would you like to seat next?");
                userInput = Console.ReadLine();
            }
            Console.WriteLine("\nGreat! Here's the final seating arrangement:");
            celebrity.Print();

        }
    }
}
