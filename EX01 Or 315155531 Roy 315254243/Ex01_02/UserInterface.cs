using System;

namespace Ex01_02
{
    internal class UserInterface
    {
        public static int getTreeSize()
        {
            int numOfLines = 0;
            
            while(!(numOfLines > 3 && numOfLines <= 15)) 
            {
                Console.WriteLine("enter tree size under 15");
                try
                {
                    numOfLines = int.Parse(Console.ReadLine());
                }
                catch { }
            }
            
            return numOfLines;
        }
    }
}
