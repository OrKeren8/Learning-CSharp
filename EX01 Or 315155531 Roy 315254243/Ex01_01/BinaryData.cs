using System;

namespace Ex01_01
{
    public class BinaryData
    {
        public static int convertBinaryNumberToInt(string i_binaryNumber)
        {
            int convertedNumber = 0;
            int binaryNumLen = i_binaryNumber.Length;

            for (int i=0; i<binaryNumLen; i++)
            {
                convertedNumber += (int)((i_binaryNumber[binaryNumLen - i - 1] - '0') * Math.Pow(2, i));
            }
            return convertedNumber;
        }
    }
}
