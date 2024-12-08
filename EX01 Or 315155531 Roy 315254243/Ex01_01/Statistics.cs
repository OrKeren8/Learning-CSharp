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
            double sum = 0;
            
            for (int i = 0; i < i_numbersArrr.Length; i++)
            {
                sum += i_numbersArrr[i];
            }

            return sum / i_numbersArrr.Length;
        }

        public static (int binaryNumIndex, int maxStrikeLen) LongestBitStrike(string[] i_binaryNumbers)
        {
            int maxStrikeLen = 0, currStrikeLen, binaryNumIndxWithMaxLen = -1;
            
            for (int i=0; i< i_binaryNumbers.Length; i++)
            {
                currStrikeLen = 1;
                for (int j=1; j< i_binaryNumbers[i].Length; j++)
                {
                    if (i_binaryNumbers[i][j] == i_binaryNumbers[i][j-1])
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

        public static int[] MaxDigitSwaps(string[] i_binaryNumbers)
        {
            int[] bitSwapsAmount = new int[i_binaryNumbers.Length]; //initialized to zeroes with new


            for (int i = 0; i < i_binaryNumbers.Length; i++)
            {
                for (int j = 1; j < i_binaryNumbers[i].Length; j++)
                {
                    if (i_binaryNumbers[i][j] != i_binaryNumbers[i][j - 1])
                    {
                        bitSwapsAmount[i]++;
                    }
                }
            }

            return bitSwapsAmount;
        }

        public static int findNumWithMostZeroes(string[] i_binaryNumbers)
        {
            int maxZeroAmount = 0, currZeroAmount, bestZeroNumIndex = 0;

            for (int i=0; i<i_binaryNumbers.Length; i++)
            {
                currZeroAmount = 0;
                for(int j=0; j < i_binaryNumbers[i].Length; j++)
                {
                    if (i_binaryNumbers[i][j] == '0')
                    {
                        currZeroAmount++;
                    }
                }
                if (currZeroAmount > maxZeroAmount)
                {
                    maxZeroAmount = currZeroAmount;
                    bestZeroNumIndex = i;  
                }
            }

            return bestZeroNumIndex;
        }
    }
}
