using System;

namespace Ex01_01
{
    internal class UserInterface
    {
        
        public static void BinarySeries()
        {
            const int k_amountOfBinaryNumbers = 3;
            const int k_BinaryNumberLength = 8;
            string[] binaryNumbersArr = new string[k_amountOfBinaryNumbers];
            int[] decimalNumbersArr = new int[k_amountOfBinaryNumbers];

            System.Console.WriteLine($"Please enter {k_amountOfBinaryNumbers} binary numbers with {k_BinaryNumberLength} digits each");
            for (int i = 0; i < k_amountOfBinaryNumbers; i++)
            {
                binaryNumbersArr[i] = getUserBinaryNumInput(k_BinaryNumberLength);
                decimalNumbersArr[i] = BinaryData.convertBinaryNumberToInt(binaryNumbersArr[i]);
            }

            Array.Sort(decimalNumbersArr);
            Array.Sort(binaryNumbersArr);

            printNumbers(decimalNumbersArr);
            printStatistics(decimalNumbersArr, binaryNumbersArr);
        }

        private static string getUserBinaryNumInput(int i_BinaryNumberLength)
        {
            string line;
            line = System.Console.ReadLine();
            while (!BinaryData.ValidateBinaryNumber(line, i_BinaryNumberLength))
            {
                System.Console.WriteLine("The input you entered is invalid. Please try again.");
                line = System.Console.ReadLine();
            }

            return line;
        }

        private static void printNumbers(int[] i_numbers)
        {
            Console.Write("The numbers are: ");
            foreach (int number in i_numbers)
            {
                Console.Write(number + " ");
            }
            Console.WriteLine();
        }

        private static void printStatistics(int[] i_numbers, string[] i_binaryNumbers)
        {
            Console.WriteLine($"The avarage of the numbres is: {Statistics.NumbersArrAverage(i_numbers):F2}");
            (int numIndex, int longestStrike) = Statistics.LongestBitStrike(i_binaryNumbers);
            Console.WriteLine($"The longest strike of bits is: {longestStrike} ({i_binaryNumbers[numIndex]})");
            int[] swapsAmount = Statistics.MaxDigitSwaps(i_binaryNumbers);
            Console.Write("Num of swaps: ");
            for (int i = 0; i< i_binaryNumbers.Length; i++)
            {
                Console.Write($"{swapsAmount[i]}({i_binaryNumbers[i]}) ");
            }
            Console.WriteLine();
            int numIndexWithMaxZeroes = Statistics.findNumWithMostZeroes(i_binaryNumbers);
            Console.WriteLine($"The number with most zeroes and the least amount of ones is:");
            Console.WriteLine($"{i_numbers[numIndexWithMaxZeroes]} (binary: {i_binaryNumbers[numIndexWithMaxZeroes]})");
        }
    }
}   
