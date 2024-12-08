using System;
using System.Diagnostics.Contracts;
using static Utils.Validator;

namespace Utils
{
    public class UserInterface
    {

        public static string GetValidUserInput(ValidatorFunc i_ValidatorFunc, params object[] i_Inputs)
        {
            string userInput = Console.ReadLine();

            while (!i_ValidatorFunc(userInput, i_Inputs))
            {
                Console.WriteLine("The input you entered is invalid. Please try again.");
                userInput = Console.ReadLine();
            }
            Console.WriteLine();
            return userInput;
        }
    }
}
