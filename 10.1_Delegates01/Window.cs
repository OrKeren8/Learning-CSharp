using System;
using System.Collections.Generic;
using System.Text;

namespace Delegates01
{
    public class Window
    {
        public Button m_ButtonOK = new Button();

        public Window()
        {
            m_ButtonOK.Visible = true;
            m_ButtonOK.Text = "OK";

            // m_ButtonOK.m_ClickInvoker has a "public event" access modifier
            // therefor you can only access its '+=' / '-=' operations.            
            m_ButtonOK.m_ClickInvoker +=
                new ClickInvoker(MethodToExecuteWhenButtonWasClicked);
        }

        public void Show()
        {
            Console.WriteLine("Form::Show() -- Hi, I am a form --");
            m_ButtonOK.Draw();
        }

        public void MethodToExecuteWhenButtonWasClicked(Button i_Button)
        {
            Console.WriteLine("Form: Button [{0}] was clicked", i_Button.Text);
        }
    }
}
