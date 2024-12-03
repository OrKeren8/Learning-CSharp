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
    }
}
