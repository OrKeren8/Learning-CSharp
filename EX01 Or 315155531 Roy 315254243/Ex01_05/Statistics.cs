using System;

namespace Ex01_05
{
    internal class Statistics
    {
        public static int checkBiggerThenUnitDigit(string i_stringOfNum)
        {
            int len = i_stringOfNum.Length;
            int amountOfBigerThanUnit = 0;
            for (int i = 0; i < i_stringOfNum.Length-1; i++)
            {
                if (i_stringOfNum[i] > i_stringOfNum[len-1])
                {
                    amountOfBigerThanUnit++;
                }
            }
            return amountOfBigerThanUnit;
        }

        public static int checkDvidedBy4(string i_stringOfNum, int i_choosenMod)
        {
            int len = i_stringOfNum.Length;
            int amountOfDiveders = 0;
            for (int i = 0; i < i_stringOfNum.Length; i++)
            {
                if (i_stringOfNum[i]%i_choosenMod == 0)
                {
                    amountOfDiveders++;
                }
            }
            return amountOfDiveders;
        }

        private static int getMinDigit(string i_stringOfNum)
        {
            int minDigit = 10, currDigit;

            for (int i = 0; i<i_stringOfNum.Length; i++)
            {
                currDigit = i_stringOfNum[i] - '0';
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

        private static int getMaxDigit(string i_stringOfNum)
        {
            int maxDigit = -1, currDigit;

            for (int i = 0; i < i_stringOfNum.Length; i++)
            {
                currDigit = i_stringOfNum[i] - '0';
                if ((currDigit != 0) && (currDigit > maxDigit))
                {
                    maxDigit = currDigit;
                }
            }
            
            return maxDigit;
        }

        private static float getRatio(int i_divisor, int i_dividend)
        {
            
            if (i_dividend == 0)
            {
                throw new Exception("cannot devide by 0");
            }
            return (float)i_divisor / i_dividend;
        }

        public static float GetRatioMaxMin(string i_stringOfNum)
        {
            int min = getMinDigit(i_stringOfNum);
            int max = getMaxDigit(i_stringOfNum);
            float ratio = getRatio(max, min);
            return ratio;
        }

        public static int numOfPairs(string i_stringOfNum)
        {
            int numOfPairs = 0;
            int[] pairsSpecifierArr  = new int[10];  // num of digits

            for (int i = 0; i < i_stringOfNum.Length; i++)
            {
                pairsSpecifierArr[(i_stringOfNum[i] - '0')]++;
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
