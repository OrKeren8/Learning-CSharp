using System;
using System.Security.AccessControl;

namespace Ex_01_04
{
    internal class UserInterface
    {
        protected const int k_ValidStringLen = 10;
        protected const int k_Mod = 4;

        public static void StringStatisticsChecker()
        {
            string userInputString;

            getValidString(out userInputString);
            isPalindrom(userInputString);
            Statistics.eStringTypes stringType = Statistics.CheckTypeOfString(userInputString);
            switch (stringType)
            {
                case Statistics.eStringTypes.EnglishLetters:
                    printingLowerCaseAmount(userInputString);
                    printIfDecreaseOrder(userInputString);
                    break;
                case Statistics.eStringTypes.Number:
                    printIsMod(userInputString, k_Mod);
                    break;
                case Statistics.eStringTypes.Mixed:
                    break;
            }

        }
        private static void getValidString(out string o_UserInputString)
        {
            string userInput;
            Console.WriteLine($"Please enter {k_ValidStringLen} charecters string");
            userInput = Utils.UserInterface.GetValidUserInput(Utils.Validator.StringValidator, new object[] { k_ValidStringLen });
            o_UserInputString = userInput;
        }

        private static void isPalindrom(string i_UserInputString)
        {
            bool isPalindrom = false;
            isPalindrom = Statistics.CheckIfPalindrom(i_UserInputString);
            if (isPalindrom)
            {
                Console.WriteLine("The String Is Palindrom");
            }
            else
            {
                Console.WriteLine("The String Isn't Palindrom");
            }
        }
     
        private static void printingLowerCaseAmount(string i_String)
        {
            int lowerCaseCounter = 0;
            for (int i = 0; i < i_String.Length; i++)
            {
                if (Utils.Validator.IsLowerDigitValidator(i_String[i]))
                {
                    lowerCaseCounter++;
                }
            }
            Console.WriteLine($"number of lower case letters in the string is: {lowerCaseCounter}");
        }
        private static void printIsMod(string i_String, int i_Mod)
        {
            if (long.Parse(i_String) % i_Mod == 0)
            {
                Console.WriteLine($"The number is divided by {i_Mod}");
            }
            else
            {
                Console.WriteLine($"The number isn't divided by {i_Mod}");

            }
        }
        private static void printIfDecreaseOrder(string i_String)
        {
            if (Statistics.IsDecreaseAlphbetOrder(i_String))
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
