
using System;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Ex01_02
{
    internal class Tree
    {

        public static void PrintTree(int i_lineIndex, int i_maxLines, char i_startingLetter)
        {
            
            int numOfLetters, numberOfSpaces;
            char currLetter = i_startingLetter;

            if (i_lineIndex > (i_maxLines - 2))
            {
                if (i_lineIndex > i_maxLines)
                {
                    return;
                }
                numOfLetters = 2 * (i_lineIndex - 2) + 1;
                numberOfSpaces = (numOfLetters / 2) * 2 + 1;
                Console.WriteLine($"{i_lineIndex}\t" + new string(' ', numberOfSpaces) + $"|{currLetter}|");
                Console.WriteLine($"{i_lineIndex+1}\t" + new string(' ', numberOfSpaces) + $"|{currLetter}|");
            }
            else
            {
                numberOfSpaces = (i_maxLines - 2 - i_lineIndex + 1) * 2;
                Console.Write(i_lineIndex + "\t" + new string(' ', numberOfSpaces));

                numOfLetters = 2 * (i_lineIndex - 1) + 1;
                for (int i = 0; i < numOfLetters; i++)
                {
                    Console.Write($"{currLetter} ");
                    currLetter = getNextLetter(currLetter);
                }
                Console.WriteLine();

                PrintTree(i_lineIndex + 1, i_maxLines, currLetter);
            }

        }
        private static char getNextLetter(char letter)
        {
            return (char)(((letter - 'A' + 1) % 26) + 'A');
        }
    }
}
