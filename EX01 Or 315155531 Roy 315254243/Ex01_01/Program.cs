using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;


namespace Ex01_01
{
    class Program
    {
        private const int k_BinaryNumberLength = 8;
        
        static void main()
        {

        }

        private bool validateBinaryNumber(string i_binaryNumber)
        {
            bool isValidBinaryNumber = true;
            bool isBinaryDigit = true;

            if (i_binaryNumber.Length != k_BinaryNumberLength)
            {
                isValidBinaryNumber = false;
            }
            if (isValidBinaryNumber)
            {
                for (int i=0; i < k_BinaryNumberLength && isBinaryDigit; i++)
                {
                    isBinaryDigit = checkBinaryDigit(i_binaryNumber[i]); 
                }             
            }
            return (isValidBinaryNumber && isBinaryDigit);
        }

        private bool checkBinaryDigit(char i_binaryDigit)
        {
            return (i_binaryDigit == '0' || i_binaryDigit == '1');
        }
    }
}