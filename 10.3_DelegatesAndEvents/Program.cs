using System;
using System.Collections.Generic;
using System.Text;

namespace DelegatesAndEvents
{
    public class Program
    {
        public static void Main()
        {
            Window form = new Window();
            form.Title = "Form with a button";
            form.Show();

            // simulating a message from the operating system to the button:
            form.m_ButtonOK.Clicked(10, 15);

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
