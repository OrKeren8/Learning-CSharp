using System;
using System.Security.AccessControl;

namespace Ex_01_04
{
    internal class UserInterface
    {
        protected const int k_valid_string_name = 10;
        protected const int k_mod = 4;

        public static void StringStatisticsChecker()
        {
            string userInputString;
            getValidString(out userInputString);
            Console.WriteLine();
            isPalindrom(userInputString);
            Statistics.eStringTypes stringType = Statistics.CheckTypeOfString(userInputString);
            switch (stringType)
            {
                case Statistics.eStringTypes.EnglishLetters:
                    printingLowerCaseAmount(userInputString);
                    printIfDecreaseOrder(userInputString);
                    break;
                case Statistics.eStringTypes.Number:
                    printIsMod(userInputString, k_mod);
                    break;
                case Statistics.eStringTypes.Mixed:
                    break;
            }

        }
        private static void getValidString(out string o_userInputString)
        {
            bool isValidString = false;
            string tmpString = "";
            while (isValidString == false)
            {
                Console.WriteLine("Please enter 10 charecters string");
                tmpString = Console.ReadLine();

                isValidString = validateString(tmpString);
            }
            o_userInputString = tmpString;
        }

        private static bool validateString(string i_userInputString) {
            bool isValidString = true;
            if (i_userInputString.Length != 10)
            {
                isValidString = false;
            }

            return isValidString;
        }
        private static void isPalindrom(string i_userInputString)
        {
            bool isPalindrom = false;
            isPalindrom = Statistics.CheckIfPalindrom(i_userInputString);
            if (isPalindrom)
            {
                Console.WriteLine("The String Is Palindrom");
            }
            else
            {
                Console.WriteLine("The String Isn't Palindrom");
            }
        }
     
        private static void printingLowerCaseAmount(string i_string)
        {
            int lowerCaseCounter = 0;
            for (int i = 0; i < i_string.Length; i++)
            {
                if (Statistics.IsLowerDigit(i_string[i]))
                {
                    lowerCaseCounter++;
                }
            }
            Console.WriteLine($"number of lower case letters in the string is: {lowerCaseCounter}");
        }
        private static void printIsMod(string i_string, int i_mod)
        {
            if (long.Parse(i_string) % i_mod == 0)
            {
                Console.WriteLine($"The number is divided by {i_mod}");
            }
            else
            {
                Console.WriteLine($"The number isn't divided by {i_mod}");

            }
        }
        private static void printIfDecreaseOrder(string i_string)
        {
            if (Statistics.IsDecreaseAlphbetOrder(i_string))
            {
                Console.WriteLine("The string is decrease alphabethic order");
            }
            else
            {
                Console.WriteLine("The string isn't decrease alphabethic order");
            }
        }


    }
}
