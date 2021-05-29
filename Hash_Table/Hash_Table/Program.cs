using System;
using System.Collections;
using static System.Console;

namespace HashTable
{
    class Hash_Table
    {
        static Hashtable ht;
        static public void Main()
        {
            // Create a hashtable
            // Using Hashtable class
            ht = new Hashtable();
            int keyVal = 0;

            WriteLine("Hello, and welcome to my program. This program is designed for you to enter receipt information, ");
            Write("sort it, delete it, and view.\nPress return to continue. (Type Exit to quit)\n");
            string userInput = ReadLine();

            while (!string.Equals(userInput, "Exit", StringComparison.OrdinalIgnoreCase))
            {

                WriteLine("\nPlease select from the following options:\n1: Add entry\n2. Search entry\n3. Edit value\n4. Delete entry" +
                "\n5. View entries\nType 'Exit' to exit.\n");
                userInput = ReadLine();

                switch (userInput)
                {

                    case "1": // new entry
                        try
                        {
                            WriteLine("\nPlease enter a date (format yyyyMMdd): ");
                            object date = int.Parse(ReadLine());

                            WriteLine("\nPlease enter the payee: ");
                            object payee = ReadLine();

                            WriteLine("\nPlease enter the amount: ");
                            object debit = ReadLine();

                            object data = date + " " + payee + " " + debit;
                            
                            ht.Add(keyVal, data); // where data is added
                            keyVal++;
                        }

                        catch
                        {
                            WriteLine("Your format is invalid. Press a key to continue.");
                            ReadKey();
                        }

                        break;

                    case "2": // search

                        WriteLine("Enter a key ID: ");
                        try
                        {
                            int convert = int.Parse(ReadLine());
                            WriteLine(ht.Contains(convert)); // find key value
                            WriteLine();


                        }
                        catch
                        {
                            WriteLine("Your format is invalid or it does not exist. Press a key to continue.");
                            ReadKey();
                        }
                        break;

                    case "3": // edit
                        WriteLine("\nPlease enter a key ID to edit: ");
                        int edit = int.Parse(ReadLine());

                        if (ht.ContainsKey(edit))
                        {
                            WriteLine("\nPlease enter a date (format yyyyMMdd): ");
                            object date = int.Parse(ReadLine());

                            WriteLine("\nPlease enter the payee: ");
                            object payee = ReadLine();

                            WriteLine("\nPlease enter the amount: ");
                            object debit = ReadLine();

                            object data = date + " " + payee + " " + debit;
                            ht[edit] = data;
                        }
                        break;

                    case "4": // delete
                        WriteLine("Please chose from the following options: \n1. Delete specific entry"
                        + "\n2. Delete all entries");
                        userInput = ReadLine();

                        switch (userInput)
                        {
                            case "1": // deletes specific entry
                                WriteLine("\nIn order to delete, please identify the date (format YYYYMMDD): ");
                                int del = int.Parse(ReadLine());
                                if (ht.ContainsKey(del))
                                {
                                    ht.Remove(del);
                                }
                                break;

                            case "2": // clears all data
                                WriteLine("Are you sure you want to delete all history? (yes/no)");
                                userInput = ReadLine();

                                if (string.Equals(userInput, "yes", StringComparison.OrdinalIgnoreCase))
                                {
                                    ht.Clear();
                                    return;
                                }

                                else if (string.Equals(userInput, "no", StringComparison.OrdinalIgnoreCase))
                                    return;

                                else
                                {
                                    WriteLine("Your format is invalid. Press a key to continue.");
                                    ReadKey();
                                }
                                break;
                            default:
                                WriteLine("Your format is invalid. Press a key to continue.");
                                ReadKey();
                                break;
                        }
                        break;

                    case "5": // view all entries

                        WriteLine("Key and Value pairs from the hash table:");
                        WriteLine();
                        WriteLine("Total number of elements present" +
                         " in the hash table:{0}", ht.Count); // counts the amount of values
                        WriteLine();

                        WriteLine();
                        WriteLine(
                            format: "{0,-8} {1,5:N0} {2,15}",
                            arg0: "Entry ID",
                            arg1: "Date",
                            arg2: "Payee             Amount"
                        );


                        foreach (DictionaryEntry entry in ht) // prints each entry
                        {
                            WriteLine("{0, -8} {1,5} ", entry.Key, entry.Value);
                        }


                        break;

                    default:
                        WriteLine("Please enter a valid selection.");
                        break;

                }
            }
        }
    }
}

