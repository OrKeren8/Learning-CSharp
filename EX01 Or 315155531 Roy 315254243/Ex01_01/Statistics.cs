namespace Ex01_01
{
    internal class Statistics
    {
        public static double NumbersArrAverage(int[] i_NumbersArrr)
        {
            double sum = 0;
            
            for (int i = 0; i < i_NumbersArrr.Length; i++)
            {
                sum += i_NumbersArrr[i];
            }

            return sum / i_NumbersArrr.Length;
        }

        public static (int binaryNumIndex, int maxStrikeLen) LongestBitStrike(string[] i_BinaryNumbers)
        {
            int maxStrikeLen = 0, currStrikeLen, binaryNumIndxWithMaxLen = -1;
            
            for (int i=0; i< i_BinaryNumbers.Length; i++)
            {
                currStrikeLen = 1;
                for (int j=1; j< i_BinaryNumbers[i].Length; j++)
                {
                    if (i_BinaryNumbers[i][j] == i_BinaryNumbers[i][j-1])
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

        public static int[] MaxDigitSwaps(string[] i_BinaryNumbers)
        {
            int[] bitSwapsAmount = new int[i_BinaryNumbers.Length]; //initialized to zeroes with new

            for (int i = 0; i < i_BinaryNumbers.Length; i++)
            {
                for (int j = 1; j < i_BinaryNumbers[i].Length; j++)
                {
                    if (i_BinaryNumbers[i][j] != i_BinaryNumbers[i][j - 1])
                    {
                        bitSwapsAmount[i]++;
                    }
                }
            }

            return bitSwapsAmount;
        }

        public static int findNumWithMostZeroes(string[] i_BinaryNumbers)
        {
            int maxZeroAmount = 0, currZeroAmount, bestZeroNumIndex = 0;

            for (int i=0; i< i_BinaryNumbers.Length; i++)
            {
                currZeroAmount = 0;
                for(int j=0; j < i_BinaryNumbers[i].Length; j++)
                {
                    if (i_BinaryNumbers[i][j] == '0')
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
