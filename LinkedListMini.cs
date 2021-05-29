using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListMiniAssignment
{
    public class Node
    {
        public int data;
        public Node next;
        public Node(int i) // This a constructor. Look to the attribute on the node method (in this case 1.)
        {
            data = i;
            next = null; // Next is a node
        }
        public void Print()
        {
            Console.Write("|" + data + "|->");
            if (next != null) // If the next node is not null, print next node
                next.Print(); // This is a recursion because print is inside of print
        }
        public void AddToEnd(int data) // This will add a new data and node to the end of another node
        {
            if (next == null)
                next = new Node(data); // if the next node is null, create a new data type at the end
            else
                next.AddToEnd(data); // This will pass over the nodes until next node is null in order to construct a new node
        }


    }
    public class MyList // This creates the first node
    {
        public Node headNode;
        public MyList()
        {
            headNode = null;
        }
        public void AddToEnd(int data)
        {
            if (headNode == null)
                headNode = new Node(data);
            else
                headNode.AddToEnd(data);
        }

        public void AddToBeginning(int data)
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

        public void DeleteData(int data)
        {
            if (headNode != null)
            {
                Node curr = headNode;
                if (curr.data == data)
                    headNode = headNode.next;
                else
                {
                    while (curr.next != null)
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
    }
    class Program
    {
        static void Main()
        {
            MyList list = new MyList(); // this creates the initial head node
            list.AddToEnd(1);
            list.AddToEnd(2); // This creates a new node after the initial
            list.AddToEnd(3); // Notice the AddToEnd refers to the method above to add a new node
            MyList temp = new MyList();
            temp.AddToEnd(4);
            temp.AddToEnd(5);
            temp.AddToEnd(6);
            list.Print();
            Console.WriteLine();
            temp.Print();
            temp.DeleteData(6);
            list.DeleteData(1);

        }
    }
}
