/*
 * Author: Jeffrey Jason Boekstaaf
 * Date: 10/02/2020
 * Assignment: Letterfrequenties of ITVitae
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace Letterfrequenties
{
    class Program
    {
        // The total amount of existence of each character.
        private static List<int> amountOfChar = new List<int>();
        // the character itself that exists in the text.
        private static List<char> kindOfChar = new List<char>();
        // the name of the file in the root that has to be read for the amount of existence of each character.
        static readonly string textFile = "Test.txt";

        /* Handling the counting of each character exists in the text. */
        private static void IncrementLists(char c)
        {
            // If it isn't a letter then nothing has to happen.
            if (!(Char.IsLetter(c)))
            {
                return;
            }

            int indexOfChar = kindOfChar.IndexOf(c);

            // -1 if it isn't already seen.
            if (indexOfChar != -1)
            {
                amountOfChar[indexOfChar]++;
            }
            else
            {
                amountOfChar.Add(1);
                kindOfChar.Add(c);
            }
        }

        /* Reads every character one by one in the text. */
        private static void ReadFile()
        {
            // putting every character in the string.
            string text = File.ReadAllText(textFile);

            // Go through every character one by one.
            for (int i = 0; i < text.Length; i++)
            {
                IncrementLists((char.Parse(text.Substring(i, 1))));
            }
        }

        /* Shows of every character the amount of appearence in the text. */
        private static void PrintAmountOfAllCharacters()
        {
            // Go through all the distinct elements of the text.
            for (int i = 0; i < amountOfChar.Count; i++)
            {
                Console.WriteLine("Character: " + kindOfChar[i] + " has a frequency of " + amountOfChar[i]);
            }
        }

        /* The calling of all functions need to tackle the problem. */
        static void Main(string[] args)
        {
            ReadFile();
            PrintAmountOfAllCharacters();
        }
    }
}
