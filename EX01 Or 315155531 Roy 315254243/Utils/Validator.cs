using System;
using Ex01_01;

namespace Utils
{
    public class Validator
    {
        public delegate bool ValidatorFunc(string i_string, params object[] i_Inputs);

        public static bool IsLowerDigitValidator(char i_digit)
        {
            return (i_digit >= 'a' && i_digit <= 'z');
        }

        public static bool IsDigitNumberValidator(char i_digit)
        {
            return (i_digit >= '0' && i_digit <= '9');
        }

        public static bool IsUpperDigitValidator(char i_digit)
        {
            return (i_digit >= 'A' && i_digit <= 'Z');
        }
        
        public static bool IsStringInRangeNumbersValidator(string i_string, params object[] i_Inputs)
        {
            int start = (int)i_Inputs[0];
            int end = (int)i_Inputs[1];
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

        public static bool IsBinaryDataValidator(string i_string, params object[] i_Inputs) 
        {
            int binaryNumLen = (int)i_Inputs[0];
            return BinaryData.ValidateBinaryNumber(i_string ,binaryNumLen);
        }
    }
}
