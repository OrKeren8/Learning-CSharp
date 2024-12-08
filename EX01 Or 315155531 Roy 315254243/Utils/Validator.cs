using System;

namespace Utils
{
    public class Validator
    {
        public static bool IsLowerDigit(char i_digit)
        {
            return (i_digit >= 'a' && i_digit <= 'z');
        }

        public static bool IsDigitNumber(char i_digit)
        {
            return (i_digit >= '0' && i_digit <= '9');
        }

        public static bool IsUpperDigit(char i_digit)
        {
            return (i_digit >= 'A' && i_digit <= 'Z');
        }

        public delegate bool ValidatorFunc(string i_string);

        /*public static bool ValidateString(ValidatorFunc i_validatorFunc, string i_string)
        {
            while (!validateNumber(userInput, k_validNumLen))
            {
                Console.WriteLine("Enter a number with 9 digits");
                userInput = Console.ReadLine();
            }
            return userInput;
            return i_validatorFunc(i_string);
        }
        */

        public static bool IsStringInRangeNumbers(string i_string, int start, int end)
        {
            try
            {
                int num = int.Parse(i_string);
                if ((num >= start) && (num <= end))
                {
                    return true;
                }
            }
            catch { }
            return false;
        }
    }
}
