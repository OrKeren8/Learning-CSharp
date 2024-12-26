using System;

namespace UI
{
    public class StringCast
    {
        public static bool ToInRange(int i_MinVal, int i_MaxVal, string i_UserSelection, out int o_UserSelection)
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

    }
}
