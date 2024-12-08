using System;

namespace Ex01_05
{
    internal class Statistics
    {
        public static int checkBiggerThenUnitDigit(string i_StringOfNum)
        {
            int len = i_StringOfNum.Length;
            int amountOfBigerThanUnit = 0;
            
            for (int i = 0; i < i_StringOfNum.Length-1; i++)
            {
                if (i_StringOfNum[i] > i_StringOfNum[len-1])
                {
                    amountOfBigerThanUnit++;
                }
            }

            return amountOfBigerThanUnit;
        }

        public static int CheckDvidedByMod(string i_StringOfNum, int i_ChoosenMod)
        {
            int len = i_StringOfNum.Length;
            int amountOfDiveders = 0;
            
            for (int i = 0; i < i_StringOfNum.Length; i++)
            {
                if (i_StringOfNum[i]%i_ChoosenMod == 0)
                {
                    amountOfDiveders++;
                }
            }

            return amountOfDiveders;
        }

        private static int getMinDigit(string i_StringOfNum)
        {
            int minDigit = 10, currDigit;

            for (int i = 0; i<i_StringOfNum.Length; i++)
            {
                currDigit = i_StringOfNum[i] - '0';
                if ((currDigit != 0) && (currDigit < minDigit))
                {
                    minDigit = currDigit;
                }    
            }

            if (minDigit == 10)
            {
                minDigit = 0;
            }

            return minDigit;
        }

        private static int getMaxDigit(string i_StringOfNum)
        {
            int maxDigit = -1, currDigit;

            for (int i = 0; i < i_StringOfNum.Length; i++)
            {
                currDigit = i_StringOfNum[i] - '0';
                if ((currDigit != 0) && (currDigit > maxDigit))
                {
                    maxDigit = currDigit;
                }
            }
            
            return maxDigit;
        }

        private static float getRatio(int i_Divisor, int i_Dividend)
        {
            
            if (i_Dividend == 0)
            {
                throw new Exception("cannot devide by 0");
            }
         
            return (float)i_Divisor / i_Dividend;
        }

        public static float GetRatioMaxMin(string i_StringOfNum)
        {
            int min = getMinDigit(i_StringOfNum);
            int max = getMaxDigit(i_StringOfNum);
            float ratio = getRatio(max, min);
            
            return ratio;
        }

        public static int NumOfPairs(string i_StringOfNum)
        {
            int numOfPairs = 0;
            int[] pairsSpecifierArr  = new int[10];  // num of digits

            for (int i = 0; i < i_StringOfNum.Length; i++)
            {
                pairsSpecifierArr[(i_StringOfNum[i] - '0')]++;
            }

            for (int i = 0; i < 10; i++)
            {
                numOfPairs += numOfPairsToAppear(pairsSpecifierArr[i]);
            }

            return numOfPairs;
        }

        private static int numOfPairsToAppear(int num)
        {
            return (num * (num - 1)) / 2;
        }

     
    }
}
