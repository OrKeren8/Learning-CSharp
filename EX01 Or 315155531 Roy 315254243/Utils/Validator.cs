using System;

namespace Utils
{
    public class Validator
    {
        public delegate bool ValidatorFunc(string i_String, params object[] i_Inputs);

        public static bool IsLowerDigitValidator(char i_Digit)
        {
            return (i_Digit >= 'a' && i_Digit <= 'z');
        }

        public static bool IsDigitNumberValidator(char i_Digit)
        {
            return (i_Digit >= '0' && i_Digit <= '9');
        }

        public static bool IsUpperDigitValidator(char i_Digit)
        {
            return (i_Digit >= 'A' && i_Digit <= 'Z');
        }
        
        public static bool IsStringInRangeNumbersValidator(string i_String, params object[] i_Inputs)
        {
            int start = (int)i_Inputs[0];
            int end = (int)i_Inputs[1];
            try
            {
                int num = int.Parse(i_String);
                if ((num >= start) && (num <= end))
                {
                    return true;
                }
            }
            catch { }
            return false;
        }

        public static bool IsBinaryDataValidator(string i_String, params object[] i_Inputs) 
        {
            int binaryNumLen = (int)i_Inputs[0];
            bool isValidBinaryNumber = true;
            bool isBinaryDigit = true;

            if (i_String.Length != binaryNumLen)
            {
                isValidBinaryNumber = false;
            }
            if (isValidBinaryNumber)
            {
                for (int i = 0; (i < binaryNumLen) && isBinaryDigit; i++)
                {
                    isBinaryDigit = isBinaryDigitValidator(i_String[i]);
                }
            }
            return (isValidBinaryNumber && isBinaryDigit);
        }

        private static bool isBinaryDigitValidator(char i_BinaryDigit)
        {
            return (i_BinaryDigit == '0' || i_BinaryDigit == '1');
        }

        public static bool StringValidator(string i_String, params object[] i_Inputs)
        {
            int stringSize = (int)i_Inputs[0];
            bool isValidString = true;

            if (i_String.Length != stringSize) 
            {
                isValidString = false;
            }

            return isValidString;
        }

        public static bool IsStringOfDigitsValidator(string i_String, params object[] i_Inputs)
        {
            bool isValdstring = true;
            int numLen = (int)i_Inputs[0];

            for (int i = 0; (i < i_String.Length) && isValdstring; i++)
            {
                if (!IsDigitNumberValidator(i_String[i]))
                {
                    isValdstring = false;
                }
            }
            return (isValdstring && i_String.Length == numLen);
        }
    }
}


