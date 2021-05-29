using System;
using System.Collections.Generic;

namespace jasonro
{
    class Program
    {
        //LinkedListNode<int> g_FirstList;
        //LinkedListNode<int> g_SecondList

        static void Main(string[] args)
        {
            // create the first list
            LinkedList<int> my_FirstList = new LinkedList<int>();
            my_FirstList.AddLast(1);
            my_FirstList.AddLast(2);
            my_FirstList.AddLast(3);

            // create the second list
            LinkedList<int> my_SecondList = new LinkedList<int>();
            my_SecondList.AddLast(4);
            my_SecondList.AddLast(5);
            my_SecondList.AddLast(6);

            PrintList(my_FirstList, "My First List");
            PrintList(my_SecondList, "My Second List");

            // reverse the second list, remove the first element and print it
            LinkedList<int> my_ReversedSecondList = ReverseList(my_SecondList);
            my_ReversedSecondList.RemoveFirst();
            PrintList(my_ReversedSecondList, "2nd List Reversed");

            // reverse the first list, remove the last element and print it
            LinkedList<int> my_ReversedFirstList = ReverseList(my_FirstList);
            my_ReversedFirstList.RemoveLast();
            PrintList(my_ReversedFirstList, "1st List Reversed");

            //interleave the two lists
            LinkedList<int> my_FinalInterleavedList = InterleaveLists(my_ReversedSecondList, my_ReversedFirstList);
            PrintList(my_FinalInterleavedList, "Final List");
        }

        static LinkedList<int> ReverseList(LinkedList<int> listToReverse)
        {
            // reverse the list
            LinkedList<int> tempList = new LinkedList<int>();

            foreach (int value in listToReverse)
            {
                tempList.AddFirst(value);
            }

            return tempList;
        }

        static LinkedList<int> InterleaveLists(LinkedList<int> listOne, LinkedList<int> listTwo)
        {
            LinkedList<int> tempList = new LinkedList<int>();
            LinkedListNode<int> tempNode = listTwo.First;

            foreach (int value in listOne)
            {
                // add the value from the first list
                tempList.AddLast(value);

                if (tempNode != null)
                {
                    tempList.AddLast(tempNode.Value);
                    tempNode = tempNode.Next;
                }
            }

            return tempList;
        }

        static void PrintList(LinkedList<int> listToPrint, string listName)
        {
            int i = 0;
            Console.WriteLine(listName + " . . .");

            foreach (int value in listToPrint)
            {
                Console.WriteLine("Index " + i.ToString() + ": " + value.ToString());
                i++;
            }
        }


    }


}