using System.Linq;

namespace Ex01_01
{
    internal class UserInterface
    {
        
        public static void BinarySeries()
        {
            const int k_amountOfBinaryNumbers = 3;
            const int k_BinaryNumberLength = 8;

            string[] binaryNumbersArr = new string[k_amountOfBinaryNumbers];


            System.Console.WriteLine($"Please enter {k_amountOfBinaryNumbers} binary numbers with {k_BinaryNumberLength} digits each");
            for (int i = 0; i < k_amountOfBinaryNumbers; i++)
            {
                binaryNumbersArr[i] = getUserBinaryNumInput(k_BinaryNumberLength);
            }
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
    }
}
