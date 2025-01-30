using System;
using System.Collections.Generic;
using System.Text;

namespace Delegates01
{


    public delegate void ClickInvoker(Button i_Button);

    public class Button
    {
        // m_ButtonOK.m_ClickInvoker has a "public event" access modifier
        // therefor you can only access its '+=' / '-=' operations. 
        // Note that the first time a '+=' operation is made on this field,
        // its 'null' state changes to a live delegate object
        public event ClickInvoker m_ClickInvoker;

        protected bool m_Visible;
        public bool Visible
        {
            get { return m_Visible; }
            set { m_Visible = value; }
        }

        protected string m_Text;
        public string Text
        {
            get { return m_Text; }
            set { m_Text = value; }
        }

        public void Draw()
        {
            Console.WriteLine("Button::Draw() [{0}]", this.Text);
        }

        public void MethodForWindowsToTellMeIwasClicked()
        {
            // lets do something:
            Console.WriteLine("Button: [{0}] -- click --", this.Text);

            OnClicked();
        }

        protected virtual void OnClicked()
        {
            // lets tell the form that I was clicked:
            if (m_ClickInvoker != null)
            {
                m_ClickInvoker.Invoke(this);
            }
        }
    }
}
