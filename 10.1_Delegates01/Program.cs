using System;
using System.Collections.Generic;
using System.Text;

namespace Delegates01
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("1. Displaying a form:\n");
            Window form = new Window();
            form.Show();

            Console.WriteLine("\n2. Clicking the button:\n");
            form.m_ButtonOK.MethodForWindowsToTellMeIwasClicked();
            
            Console.ReadLine();
        }
    }
}

