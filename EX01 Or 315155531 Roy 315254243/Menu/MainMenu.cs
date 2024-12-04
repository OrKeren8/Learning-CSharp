
using System;
using System.Runtime.Remoting.Lifetime;

namespace Menu
{
    internal class MainMenu
    {
        enum eOptionsEx
        {
            Abort = 0,
            BinaryInput = 1,
            StaticTree = 2,
            DynamicTree = 3,
            StringStatistics = 4,
            NumbersStatistics = 5
        }

        public static void MenuInterface()
        {
            Console.WriteLine("Please choose which program you wish to run:");
            Console.WriteLine("===========================================");

            foreach (eOptionsEx option in Enum.GetValues(typeof(eOptionsEx)))
            {
                Console.WriteLine($"{(int)option} :{option}");
            }

            int userExSelection = Console.ReadLine();

        }




        

        /*
1. Binary Input
2. Sand Machine
0. Abort*/
    }
}
