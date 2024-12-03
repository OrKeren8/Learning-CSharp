using System;

namespace Ex_01_04
{
    internal class UserInterface
    {
        protected const int k_valid_string_name = 10;
        
        public static void StringStatisticsChecker()
        {
            string userInputString;
            getValidString(out userInputString);
            Console.WriteLine();
            isPalindrom(userInputString);

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
            if(isPalindrom)
            {
                Console.WriteLine("The String Is Palindrom");
            }
            else
            {
                Console.WriteLine("The String Isn't Palindrom");
            }
        }
        
    }
}
