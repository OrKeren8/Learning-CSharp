using System;
using System.Text;

namespace Ex_01_04
{
    internal class Statistics
    {
        public static bool CheckIfPalindrom(string i_String)
        {

            if (i_String.Length < 2)
            {
                return true;
            }
            else
            {
                if (i_String[0] == i_String[i_String.Length - 1])
                {
                    return CheckIfPalindrom(i_String.Substring(1, i_String.Length - 2));
                }
                else
                {
                    return false;
                }
            }
        }

        public static eStringTypes CheckTypeOfString(string i_UserInputString)
        {
            bool isAllLetters = true;
            bool isNumber = true;
            
            
            for (int i = 0; i < i_UserInputString.Length; i++)
            {
                if (!(Utils.Validator.IsLowerDigitValidator(i_UserInputString[i]) || Utils.Validator.IsUpperDigitValidator(i_UserInputString[i])))
                {
                    isAllLetters = false;
                }
                if (!(Utils.Validator.IsDigitNumberValidator(i_UserInputString[i])))
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

        public enum eStringTypes
        {
            EnglishLetters = 1,
            Number = 2,
            Mixed = 3
        }
        public static bool IsDecreaseAlphbetOrder(string i_String)
        {
            string lowerCaseString = i_String.ToLower();
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