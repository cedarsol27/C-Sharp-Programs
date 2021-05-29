using System;
using static System.Console;

namespace JaggedArrays
{
    class MainClass
    {
        public static void Main()
        {
            // declare arrays
            int[][] numbers =
            {
                new int[] { 9, 5, -9 },
                new int[] { 0, -3, 12, 51, -3 },
                new int[] { },
                new int[] { 54 }
            };

            // write elements within each index of array0
            // i and j both have indexes [0,0], [0,1], etc
            for (int i = 0; i < numbers.Length; i++)
            {
                Write("Row({0}): ", i);
                for (int j = 0; j < numbers[i].Length; j++)
                {
                    Write("{0} ", numbers[i][j]);
                }
                WriteLine();
            }
        }
    }
}
