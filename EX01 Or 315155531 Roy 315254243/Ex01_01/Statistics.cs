using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex01_01
{
    internal class Statistics
    {
        public static double NumbersArrAverage(int[] i_numbersArrr)
        {
            int sum = 0;
            
            for (int i = 0; i < i_numbersArrr.Length; i++)
            {
                sum += i_numbersArrr[i];
            }

            return sum / i_numbersArrr.Length;
        }

        public static (int binaryNumIndex, int maxStrikeLen) LongestBitStrike(string[] i_boolNumbers)
        {
            int maxStrikeLen = 0, currStrikeLen, binaryNumIndxWithMaxLen = -1;
            
            for (int i=0; i< i_boolNumbers.Length; i++)
            {
                currStrikeLen = 1;
                for (int j=1; j< i_boolNumbers[i].Length; j++)
                {
                    if (i_boolNumbers[i][j] == i_boolNumbers[i][j-1])
                    {
                        currStrikeLen++;
                        if (maxStrikeLen < currStrikeLen)
                        {
                            maxStrikeLen = currStrikeLen;
                            binaryNumIndxWithMaxLen = i;
                        }
                    }
                    else
                    {
                        currStrikeLen = 1;
                    }
                }
            }

            return (binaryNumIndxWithMaxLen, maxStrikeLen);
        }

        public static int[] MaxDigitSwaps(string[] i_boolNumbers)
        {
            int[] bitSwapsAmount = new int[i_boolNumbers.Length]; //initialized to zeroes with new


            for (int i = 0; i < i_boolNumbers.Length; i++)
            {
                for (int j = 1; j < i_boolNumbers[i].Length; j++)
                {
                    if (i_boolNumbers[i][j] != i_boolNumbers[i][j - 1])
                    {
                        bitSwapsAmount[i]++;
                    }
                }
            }

            return bitSwapsAmount;
        }

    }
}
