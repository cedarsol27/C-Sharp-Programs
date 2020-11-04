using System;
using System.Collections.Generic;
using static System.Console;

namespace FinalLinkedList
{
    class MainClass
    {
        static void Main()
        {
            Random r = new Random();
            LinkedList<int> ListOne = new LinkedList<int>();
            LinkedList<int> ListTwo = new LinkedList<int>();

            for (byte i = 0; i < 10; i++)
            {
                int generated = r.Next(0, 100);

                if (generated % 2 == 0)
                {
                    ListTwo.AddLast(generated);
                }
                else
                {
                    ListOne.AddLast(generated);
                }
            }

            Print(ListOne, "The first generated list is");
            WriteLine();
            Print(ListTwo, "The second generated list is");

            LinkedList<int> combinedLists = Combine(ListOne, ListTwo);
            WriteLine();
            Print(combinedLists, "The combined lists are");
            ListOne.Clear();
            ListTwo.Clear();

            int[] arr = new int[combinedLists.Count];
            combinedLists.CopyTo(arr, 0);
            Array.Sort(arr);
            LinkedList<int> final = Convert(arr);
            combinedLists.Clear();
            WriteLine();
            Print(final, "Final Sort");
        }

        static void Print(LinkedList<int> listToPrint, string listName)
        {
            byte i = 0;
            WriteLine($"{listName} . . . ");

            foreach (byte j in listToPrint)
            {
                WriteLine($"Index {i} : {j}");
                i++;
            }
        }

        static LinkedList<int> Combine(LinkedList<int> listOne, LinkedList<int> listTwo)
        {
            LinkedList<int> tempList = new LinkedList<int>();
            LinkedListNode<int> tempNode = listTwo.First;

            foreach (byte i in listOne)
            {
                tempList.AddLast(i);

                if (tempNode != null)
                {
                    tempList.AddLast(tempNode.Value);
                    tempNode = tempNode.Next;
                }
            }
            return tempList;
        }
        static LinkedList <int> Convert(int[] list)
        {
            LinkedList<int> tempList = new LinkedList<int>();

            for(int i = 0; i < list.Length; i++)
            {
                tempList.AddLast(list[i]);
            }
            return tempList;
        }
    }
}
