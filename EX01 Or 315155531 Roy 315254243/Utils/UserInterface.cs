using System;

namespace Utils
{
    public class UserInterface
    {
        public static int GetDigitInput(int i_minDigit, int i_maxDigit)
        {
            bool isValidInput = false;
            string userInput;
            int digitOutput=-1;

            while (!isValidInput)
            {
                Console.WriteLine($"Enter number between {i_minDigit} to {i_maxDigit}");
                userInput = Console.ReadLine();
                if (userInput.Length != 1)
                {
                    Console.WriteLine("Wrong Input");
                }
                else
                {
                    isValidInput = Validator.IsDigitNumber(userInput[0]);
                    digitOutput = int.Parse(userInput);
                    isValidInput = isValidInput && (digitOutput >= i_minDigit) && (digitOutput <= i_maxDigit);
                }
            }
            Console.WriteLine();
            return digitOutput;
        }
    }
}
