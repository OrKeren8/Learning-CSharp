namespace Utils
{
    internal class Validator
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
    }
}
