using System;
using System.Text;

namespace Ex_01_04
{
    internal class Statistics
    {
        public static bool CheckIfPalindrom(string i_string)
        {

            if (i_string.Length < 2)
            {
                return true;
            }
            else
            {
                if (i_string[0] == i_string[i_string.Length - 1])
                {
                    return CheckIfPalindrom(i_string.Substring(1, i_string.Length - 2));
                }
                else
                {
                    return false;
                }
            }
        }

        public static eStringTypes CheckTypeOfString(string i_userInputString)
        {
            bool isAllLetters = true;
            bool isNumber = true;
            
            
            for (int i = 0; i < i_userInputString.Length; i++)
            {
                if (!(IsLowerDigit(i_userInputString[i]) || IsUpperDigit(i_userInputString[i])))
                {
                    isAllLetters = false;
                }
                if (!IsDigitNumber(i_userInputString[i]))
                {
                    isNumber = false;
                }
            }
            if (isAllLetters)
            {
                return eStringTypes.EnglishLetters;
            }
            else if(isNumber)
            {
                return eStringTypes.Number;
            }
            else
            {
                return eStringTypes.Mixed;
            }

        }

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
        public enum eStringTypes
        {
            EnglishLetters = 1,
            Number = 2,
            Mixed = 3
        }
        public static bool IsDecreaseAlphbetOrder(string i_string)
        {
            string lowerCaseString = i_string.ToLower();
            bool isDecreaseOrder = true;
            for(int i=0;i<lowerCaseString.Length-1 && isDecreaseOrder == true; i++)
            {
                if (lowerCaseString[i+1] >= lowerCaseString[i])
                {
                    isDecreaseOrder = false;
                }
            }
            return isDecreaseOrder;

        }

    }
}