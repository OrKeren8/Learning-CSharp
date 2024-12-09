using System;

namespace Ex01_01
{
    internal class UserInterface
    {
        
        public static void BinarySeries()
        {
            const int k_AmountOfBinaryNumbers = 3;
            const int k_BinaryNumberLength = 8;
            string[] binaryNumbersArr = new string[k_AmountOfBinaryNumbers];
            int[] decimalNumbersArr = new int[k_AmountOfBinaryNumbers];

            System.Console.WriteLine($"Please enter {k_AmountOfBinaryNumbers} binary numbers with {k_BinaryNumberLength} digits each");
            for (int i = 0; i < k_AmountOfBinaryNumbers; i++)
            {
                binaryNumbersArr[i] = Utils.UserInterface.GetValidUserInput(Utils.Validator.IsBinaryDataValidator, new object[] { k_BinaryNumberLength });
                decimalNumbersArr[i] = BinaryData.convertBinaryNumberToInt(binaryNumbersArr[i]);
            }

            Array.Sort(decimalNumbersArr);
            Array.Sort(binaryNumbersArr);

            printNumbers(decimalNumbersArr);
            printStatistics(decimalNumbersArr, binaryNumbersArr);
        }

        private static void printNumbers(int[] i_Numbers)
        {
            Console.Write("The numbers are: ");
            foreach (int number in i_Numbers)
            {
                Console.Write(number + " ");
            }
            Console.WriteLine();
        }

        private static void printStatistics(int[] i_Numbers, string[] i_BinaryNumbers)
        {
            Console.WriteLine($"The avarage of the numbres is: {Statistics.NumbersArrAverage(i_Numbers):F2}");
            (int numIndex, int longestStrike) = Statistics.LongestBitStrike(i_BinaryNumbers);
            Console.WriteLine($"The longest strike of bits is: {longestStrike} ({i_BinaryNumbers[numIndex]})");
            int[] swapsAmount = Statistics.MaxDigitSwaps(i_BinaryNumbers);
            Console.Write("Num of swaps: ");
            for (int i = 0; i< i_BinaryNumbers.Length; i++)
            {
                Console.Write($"{swapsAmount[i]}({i_BinaryNumbers[i]}) ");
            }
            Console.WriteLine();
            int numIndexWithMaxZeroes = Statistics.findNumWithMostZeroes(i_BinaryNumbers);
            Console.WriteLine($"The number with most zeroes and the least amount of ones is:");
            Console.WriteLine($"{i_Numbers[numIndexWithMaxZeroes]} (binary: {i_BinaryNumbers[numIndexWithMaxZeroes]})");
        }
    }
}   
