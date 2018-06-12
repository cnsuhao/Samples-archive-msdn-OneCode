/****************************** Module Header ******************************\
* Module Name:    Program.cs
* Project:        CSTextWordCount
* Copyright (c) Microsoft Corporation
*
* The sample demonstrates the following features:
*
* 1. How to calculate how many words in txt file using regular expression.
*
* 2. How to calculate the occurrence count of a word.
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/en-us/openness/resources/licenses.aspx#MPL.
* All other rights reserved.
*
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\*****************************************************************************/

using System;
using System.IO;
using System.Text.RegularExpressions;

namespace CSTextWordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            int choice = 0;

            // Input the text file Location
            Console.Write("Input File Location : ");

            string filename = Console.ReadLine();

            while (choice != 3)
            {
                printMenu();
                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1: Console.WriteLine("Total word count = " + totalWords(filename));
                            break;
                        case 2: Console.WriteLine("Enter the specific word : ");
                            string word = Console.ReadLine();
                            Console.WriteLine("Total word occurence = " + wordCount(filename, word));
                            break;
                        case 3: break;
                    }
                }
                catch (System.FormatException e)
                {
                    Console.WriteLine("Please enter valid choice!");
                }
            }
        }
        // <summary>
        // This function prints the main menu.
        // </summary>

        static void printMenu()
        {
            Console.WriteLine("\n1. Calculate Total Number of words in the Input file");
            Console.WriteLine("2. Calculate occurence count of a word");
            Console.WriteLine("3. Exit");
        }

        // <summary>
        // This function counts the total number of words in the input text file.
        // </summary>
        // <param name="filename">File Name</param>
        // <returns>Return the total word count</returns>

        static int totalWords(string filename)
        {
            int count = 0;
            StreamReader sr = new StreamReader(filename);
            string input;
            string pattern = @"\b\w+\b";

            while (sr.Peek() >= 0)
            {
                input = sr.ReadLine();
                Regex rgx = new Regex(pattern, RegexOptions.IgnoreCase);
                MatchCollection matches = rgx.Matches(input);
                count += matches.Count;
            }
            sr.Close();
            return count;
        }

        // <summary>
        // This function counts the number of times a specific word is present in the input text file.
        // </summary>
        // <param name="filename">File Name</param>
        // <returns>Return the word count for a specific word</returns>

        static int wordCount(string filename, string word)
        {
            int count = 0;
            StreamReader sr = new StreamReader(filename);
            string input;
            
            string pattern = word;
            while (sr.Peek() >= 0)
            {
                input = sr.ReadLine();
                Regex rgx = new Regex(pattern, RegexOptions.IgnoreCase);
                MatchCollection matches = rgx.Matches(input);
                count += matches.Count;
            }
            sr.Close();
            return count;    
        }
    }
}
