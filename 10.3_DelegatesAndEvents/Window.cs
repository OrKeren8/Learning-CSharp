using System;
using System.Collections.Generic;
using System.Text;

namespace DelegatesAndEvents
{
    /// <summary>
    /// This is an exmaple for a class that holds a "publisher" and wants
    /// to handle some its published events (a "Subscriber")
    /// </summary>
    public class Window
    {
        public Button m_ButtonOK;
        public Button m_ButtonCancel;

        public Window()
        {
            m_ButtonCancel = new Button();
            m_ButtonCancel.Text = "Cancel";
            m_ButtonOK = new Button();
            m_ButtonOK.Text = "OK";

            // setting my methods as the handlers for the click event:
            m_ButtonOK.ClickOccured += new ClickEventHandler(button_Click_EventHandler);
            m_ButtonOK.ClickOccured += new ClickEventHandler(button_Click_EventHandler); // adding the same handler twice
            m_ButtonOK.ClickOccured += new ClickEventHandler(button_Click_EventHandler2); // adding a second handler
            m_ButtonOK.ClickOccured -= new ClickEventHandler(button_Click_EventHandler); // removing a handler
        }

        public void Show()
        {
            Console.WriteLine("Form: === {0} ===", this.Title);
            m_ButtonOK.Show();
            m_ButtonCancel.Show();
        }

        private string m_Title;
        public string Title
        {
            get { return m_Title; }
            set { m_Title = value; }
        }

        /// <summary>
        /// Handles the "click" event of the buttons
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void button_Click_EventHandler(object sender, ClickEventArgs e)
        {
            Console.WriteLine("Form: Button \"{0}\" was clicked at point ({1},{2})",
                ((Button)sender).Text, e.X, e.Y);
        }

        public void button_Click_EventHandler2(object sender, ClickEventArgs e)
        {
            Console.WriteLine("[[[EventHandler2]]] Form: Button \"{0}\" was clicked at point ({1},{2})",
                ((Button)sender).Text, e.X, e.Y);
        }
    }
}
