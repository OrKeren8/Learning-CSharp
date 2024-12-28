using System;

namespace UI
{
    public class StringValidator
    {
        public static bool ToIntRange(int i_MinVal, int i_MaxVal, string i_UserSelection, out int o_UserSelection)
        {
            bool isValid = int.TryParse(i_UserSelection, out o_UserSelection);

            if (isValid)
            {
                if (!((o_UserSelection >= i_MinVal) && (o_UserSelection <= i_MaxVal)))
                {
                    isValid = false;
                }
            }
            return isValid;
        }

        public static bool IsValidName(string i_Name)
        {
            bool isValid = true;
            
            if (i_Name.Contains(" ") || i_Name.Length > 20)
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
            

    }
}
