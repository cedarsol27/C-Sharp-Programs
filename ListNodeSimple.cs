using System;
using System.Collections.Generic;

class LinkedListNode
{

    static public void Main()
    {


        LinkedList<int> list = new LinkedList<int>();


        list.AddLast(1);
        list.AddLast(2);
        list.AddLast(3);
        list.AddLast(4);

        list.Clear();

        LinkedList<int> list2 = new LinkedList<int>();
        list.AddLast(4);
        list.AddLast(2);
        list2.AddLast(3);
        list2.AddLast(1);



        foreach (int j in list)
        {
            Console.Write("[" + j + "]-> ");
        }
        Console.WriteLine();
        foreach (int j in list2)
        {
            Console.Write("[" + j + "]-> ");
        }

    }
}
