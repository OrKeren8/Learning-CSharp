
using System;
using Utils;

namespace Menu
{
    public class MainMenu
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
            eOptionsEx userInput;
            bool loop = true;
            int minChoiceValue, maxChoiceValue;
            var options = Enum.GetValues(typeof(eOptionsEx));

            while (loop)
            {
                Console.WriteLine("Please choose which program you wish to run:");
                Console.WriteLine("===========================================");
                Console.WriteLine();
                foreach (eOptionsEx option in options)
                {
                    Console.WriteLine($"{(int)option} :{option}");
                }
                Console.WriteLine();
                
                minChoiceValue = (int)options.GetValue(0);
                maxChoiceValue = (int)options.GetValue(options.Length - 1);
                userInput = (eOptionsEx)int.Parse(UserInterface.GetValidUserInput(Validator.IsStringInRangeNumbersValidator, new object[] { minChoiceValue, maxChoiceValue }));
            
                switch (userInput)
                {
                    case eOptionsEx.Abort:
                        loop = false;
                        break;
                    case eOptionsEx.BinaryInput:
                        Ex01_01.Program.Run();
                        break;
                }
                Console.WriteLine();
            }
        }
    }
}
