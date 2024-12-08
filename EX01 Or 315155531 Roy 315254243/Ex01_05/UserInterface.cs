using System;
using Utils;


namespace Ex01_05
{
    internal class UserInterface
    {
        protected const int k_validNumLen = 9;
        protected const int k_mod = 4;
        public static void PrintStatistics()
        {
            string number = getStringOfNumberFromUser();
            int amountOfBigerThanUnit = Statistics.checkBiggerThenUnitDigit(number);
            Console.WriteLine($"number of digits which bigger than the units digit ({number[number.Length - 1]}) is: {amountOfBigerThanUnit}");
            int numOfDeviders = Statistics.checkDvidedBy4(number, k_mod);
            Console.WriteLine($"number of digits which devided by {k_mod} is: {numOfDeviders}");
            try
            {
                float ratio = Statistics.GetRatioMaxMin(number);
                Console.WriteLine($"the ratio between the minimum and maximum digits in the number is: {ratio}");
            }
            catch
            {
                Console.WriteLine("all the numbers are 0");
            }
            Console.WriteLine($"num of pairs with identical digits: {Statistics.numOfPairs(number)}");
        }

        private static string getStringOfNumberFromUser()
        {
            string userInput = "";
            while (!validateNumber(userInput, k_validNumLen)){
                Console.WriteLine("Enter a number with 9 digits");
                userInput = Console.ReadLine();
            }
            return userInput;
        }

        private static bool validateNumber(string i_stringOfNumber, int numLength)
        {
            bool isValidNumber = true;
            
            for(int i=0; i < i_stringOfNumber.Length && isValidNumber; i++)
            {
                if (!IsDigitNumber(i_stringOfNumber[i])){
                    isValidNumber = false;
                }
            }

            return (isValidNumber && i_stringOfNumber.Length == numLength);
        }

        public static bool IsDigitNumber(char i_digit)
        {
            return (i_digit >= '0' && i_digit <= '9');
        }
    }
}
