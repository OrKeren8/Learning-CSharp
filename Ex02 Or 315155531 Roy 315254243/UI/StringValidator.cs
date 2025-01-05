using System;
using System.Runtime.InteropServices;

namespace UI
{
    public class StringValidator
    {
        public static bool ToIntRange(int i_MinVal, int i_MaxVal, string i_UserSelection, out int o_UserSelection)
        {
            bool isValid = int.TryParse(i_UserSelection, out o_UserSelection);

            if (isValid && !((o_UserSelection >= i_MinVal) && (o_UserSelection <= i_MaxVal)))
            {
                isValid = false;
            }

            return isValid;
        }

        public static bool IsValidName(string i_Name)
        {
            bool isValid = true;
            
            if (i_Name.Contains(" ") || i_Name.Length > 20 || i_Name.Length < 1)
            {
                isValid = false;
            }

            return isValid;
        }

        public static bool IsValidBoardSize(string i_BoardSize)
        {
            bool isValid = true;

            if(i_BoardSize != "6" &&  i_BoardSize != "8" && i_BoardSize != "10") 
            {
                isValid = false;
            }

            return isValid;
        }

        public static bool CheckValidMove(String i_Move)
        {
            bool isValid = true;

            if (i_Move.Length != 5 || i_Move[2] != '>' || !validateMoveLetters(i_Move))
            {
                isValid = false;
            }

            return isValid;
        }

        private static bool validateMoveLetters(String i_Move)
        {
            bool IsValidLetters = true;

            if ((!checkUpperChar(i_Move[0])|| !checkUpperChar(i_Move[3])) || (!checkLowerChar(i_Move[1]) || !checkLowerChar(i_Move[4])))
            {
                IsValidLetters = false;
            }

            return IsValidLetters;
        }

        private static bool checkLowerChar(char i_LowerChar)
        {
            bool isValid = true;

            if (i_LowerChar < 'a' || i_LowerChar > 'z')
            {
                isValid = false;
            }

            return isValid;
        }

        private static bool checkUpperChar(char i_UpperChar)
        {
            bool isValid = true;

            if (i_UpperChar < 'A' || i_UpperChar > 'Z')
            {
                isValid = false;
            }

            return isValid;
        }

        public static bool IsQuitRequest(String i_Request)
        {
            return (i_Request == "Q" || i_Request == "q");
        }
            

    }
}
