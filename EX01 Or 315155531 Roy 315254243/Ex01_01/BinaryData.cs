namespace Ex01_01
{
    internal class BinaryData
    {

        public static bool ValidateBinaryNumber(string i_binaryNumber, int i_BinaryNumberLength)
        {
            bool isValidBinaryNumber = true;
            bool isBinaryDigit = true;

            if (i_binaryNumber.Length != i_BinaryNumberLength)
            {
                isValidBinaryNumber = false;
            }
            if (isValidBinaryNumber)
            {
                for (int i = 0; i < i_BinaryNumberLength && isBinaryDigit; i++)
                {
                    isBinaryDigit = checkBinaryDigit(i_binaryNumber[i]);
                }
            }
            return (isValidBinaryNumber && isBinaryDigit);
        }

        private static bool checkBinaryDigit(char i_binaryDigit)
        {
            return (i_binaryDigit == '0' || i_binaryDigit == '1');
        }
    }
}
