// James Pesta
// BIT 142
// Major Assignment 04


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MajorAssignment4
{
    class MainClass
    {

        public static void BinarySearch(int[] arr, int Low, int High)
        {
            Console.WriteLine("What number are you looking for?");
            int Search = Convert.ToInt32(Console.ReadLine());    // Creates a search function 

            while (Low <= High)                                  // This function start to compare the number in question with the
            {                                                    // index of the array starting at index 0. If index 0 is the match,
                if (arr[Low] == Search)                          // end the program. If not, then create an integer called 'Mid' and 
                {                                                // move the index up to where half of the array length is and compare
                    Console.WriteLine("The element you are " +   // if that is the match. If so, exit program. If not, check to see if
                    "looking for was found at index " + Low);    // the element in that index is greater than the number being sought. 
                    return;                                      // If that index is greater than the search, move down one index, if
                }                                                // it is less than the search, move up one index. Repeat the while loop
                int Mid = (High + Low) / 2;                      // Until the number either matches, or end program with cannot find.
                if (arr[Mid] == Search)
                {
                    Console.WriteLine("The element you are looking for was found at index " + Mid);
                    return;
                }
                if (arr[Mid] > Search)
                {
                    High = Mid - 1;
                }
                else
                {
                    Low = Mid + 1;
                }
            }
            Console.WriteLine("The element you entered does not exist");
            return;
        }



        public static void LinearSearch(int[] arr)
        {
            Console.WriteLine("What number are you looking for?"); // Creates a search function
            int Search = Convert.ToInt32(Console.ReadLine());


            for (int i = 0; i < arr.Length; i++)         // This one is simple. This just checks whether the value of index 0
            {                                            // matches the search number and returns the index if so. If not, move
                if (arr[i] == Search)                    // up one index and check again. Repeat until either a match, or end
                {                                        // ahd return does not exist.
                    Console.WriteLine("The element you are looking for is at index " + i);
                    return;
                }

            }

            Console.WriteLine("The element you entered does not exist");
            return;
        }




        public static void BubbleSort(int[] arr, int temp)
        {
            for (int i = 0; i < arr.Length; i++)         // This sets up the array and values.
            {
                for (int j = 0; j < arr.Length - 1; j++) // Because we need to compare two numbers, there is going to be one less
                {                                        // than the length of the array, otherwise we would compare an non-exsting 
                    if (arr[j] > arr[j + 1])             // number outside the array and it will crash. Next it compares the two numbers
                    {                                    // next to each other. If the number on the left is greater than the one on 
                        temp = arr[j + 1];               // the right, store the number on the right into a temp area, rewrite the 
                        arr[j + 1] = arr[j];             // number on the left over one slot in the array, and then set the number in
                        arr[j] = temp;                   // temp into the previous index of the array. Now move one up the index.
                    }                                    // Sometimes it will go back an index, but only to re-write the indexes 
                }                                        // in order to properly sort the numbers.
            }
            Console.WriteLine("Sorted:");
            foreach (int k in arr)
                Console.WriteLine(k);
        }



        public static void MergeSort(int[] arr, int Low, int High) // Break down the array into singles of nodes 
        {

            if (Low < High)
            {
                int Mid = (Low + High) / 2;
                MergeSort(arr, Low, Mid); // Sort the left half
                MergeSort(arr, Mid + 1, High); // Sort the right half
                MainMerge(arr, Low, Mid, High);

            }

        }

        public static void MainMerge(int[] arr, int Low, int Mid, int High)
        {
            int oldPosition = Low;
            int size = High - Low + 1;
            int[] temp = new int[size];
            int Mid1 = Mid + 1;
            int i = 0;

            while (Low <= Mid && Mid1 <= High) // This will cause an out of bounds error, so there is a copy below to rectify this.
            {
                if (arr[Low] <= arr[High])
                {
                    temp[i] = arr[Low];
                    i++;
                    Low++;
                }
                else // copy over right element
                {
                    temp[i] = arr[Mid1];
                    i++;
                    Mid1++;
                }
            }


            if (Low > Mid)
                for (int j = Mid1; j <= High; j++)
                    temp[i++] = arr[Mid1++];
            else
                for (int j = Low; j <= Mid; j++)
                    temp[i++] = arr[Low++];
            Array.Copy(temp, 0, arr, oldPosition, size);

            foreach (var item in arr)
                Console.Write(item.ToString() + " "); // This always returns the length of the array - 1, but the last sort is correct.
        }



        public static void Interpolation(int[] arr, int Low, int High)
        {
            Array.Sort(arr);// Helps for max effectiveness (and it breaks if they are out of place anyway)
            Console.WriteLine("What number are you looking for?");
            int Search = Convert.ToInt32(Console.ReadLine());
            int Mid;

            while (arr[Low] < Search && arr[High] >= Search) // This is checking to see if the element in index 0 (the lowest) is 
            {                                                // less than the Search AND the element in the last index is greater than
                                                             // the Search 
                Mid = Low + ((Search - arr[Low]) * (High - Low)) / (arr[High] - arr[Low]);
                // this formula starts to search for the number quite immediately, but being to narrow down to see if the element
                // of the index matches the Search target. It begins to whittle away at the Search at a faster rate than the Binary search

                if (arr[Mid] < Search)      // the element of what Mid index (formula above) check to see if it is less than
                    Low = Mid + 1;          // Add 1 to the index if true
                else if (arr[Mid] > Search) // if not, check to see if the element of Mid is greater than Search
                    High = Mid - 1;         // Minus 1 to index
                else
                    Console.WriteLine("The element is at index " + Mid); // if a match
            }                               // Repeat until targeted Search is found

            if (arr[Low] == Search)
                Console.WriteLine("The element is at index " + Low); // if the element is equal to search index Low
            else
            {
                Console.WriteLine("There is no match!"); // Must not be a match
            }
        }





        public static void Main(string[] args)
        {
            Console.WriteLine("This is a search and sort algorithm.\n How many numbers do you have?"); // This creates the size of the array from the user input
            int size = Convert.ToInt32(Console.ReadLine()); // creates teh sie of the array
            int[] arr = new int[size];                      // creates the array

            for (int i = 0; i < size; i++)                  // This stores entered numbers into the array
            {
                Console.WriteLine("Please enter a number into index " + i);
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }

            Console.WriteLine("\nPlease choose from the following options:\n1. Binary Search\n2. Linear Search"
            + "\n3. Bubble Sort \n4. Merge Sort \n5. Interpolation");

            var begin = Convert.ToInt32(Console.ReadLine()); // Choose a number
            if (begin == 1)
                BinarySearch(arr, 0, size - 1);
            if (begin == 2)
                LinearSearch(arr);
            if (begin == 3)
                BubbleSort(arr, 0);
            if (begin == 4)
                MergeSort(arr, 0, size - 1);
            if (begin == 5)
                Interpolation(arr, 0, size - 1);
        }
    }
}