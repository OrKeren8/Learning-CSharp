using System;
using Utils;


namespace Ex01_05
{
    internal class UserInterface
    {
        protected const int k_ValidNumLen = 9;
        protected const int k_Mod = 4;
        public static void PrintStatistics()
        {
            string number = getStringOfNumberFromUser();
            int amountOfBigerThanUnit = Statistics.checkBiggerThenUnitDigit(number);
            Console.WriteLine($"number of digits which bigger than the units digit ({number[number.Length - 1]}) is: {amountOfBigerThanUnit}");
            int numOfDeviders = Statistics.CheckDvidedByMod(number, k_Mod);
            Console.WriteLine($"number of digits which devided by {k_Mod} is: {numOfDeviders}");
            try
            {
                float ratio = Statistics.GetRatioMaxMin(number);
                Console.WriteLine($"the ratio between the minimum and maximum digits in the number is: {ratio}");
            }
            catch
            {
                Console.WriteLine("all the numbers are 0");
            }
            Console.WriteLine($"num of pairs with identical digits: {Statistics.NumOfPairs(number)}");
        }
        private static string getStringOfNumberFromUser()
        {
            string userInput;

            Console.WriteLine($"Please enter number with {k_ValidNumLen} digits:");
            userInput = Utils.UserInterface.GetValidUserInput(Utils.Validator.IsStringOfDigitsValidator, new object[] { k_ValidNumLen });
           
            return userInput;
        }
    }
}
