
using System;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Ex01_02_and_03
{
    internal class Tree
    {
        protected const int k_MinTreeSize = 3;
        protected const int k_MaxTreeSize = 15;

        protected const int k_AmountEnglishLetters = 26;

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
            return (char)(((letter - 'A' + 1) % k_AmountEnglishLetters) + 'A');
        }

        public static int GetTreeSize()
        {
            Console.WriteLine($"Enter tree size from {k_MinTreeSize} to {k_MaxTreeSize}");
            return int.Parse(Utils.UserInterface.GetValidUserInput(Utils.Validator.IsStringInRangeNumbersValidator, new object[] { 3, 15 }));
        }
    }
}
