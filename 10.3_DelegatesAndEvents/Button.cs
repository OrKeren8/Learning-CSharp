using System;
using System.Collections.Generic;
using System.Text;

namespace DelegatesAndEvents
{
    /// <summary>
    /// Declaring a delegate in the same 'zone' as the publishers.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void ClickEventHandler(object sender, ClickEventArgs e);

    /// <summary>
    /// Holds the "click" event arguments
    /// </summary>
    public class ClickEventArgs : EventArgs
    {
        public int X;
        public int Y;
    }

    /// <summary>
    /// This is an example of a class that raises events (a "Publisher");
    /// </summary>
    public class Button
    {
        /// <summary>
        /// I hold a delegate (a wrapper to a method pointer)
        /// so I can execute when I want to notify about being clicked.
        /// </summary>
        public event ClickEventHandler ClickOccured;

        private string m_Text = string.Empty;
        public string Text
        {
            get { return m_Text; }
            set { m_Text = value; }
        }

        /// <summary>
        /// This is a dummy method that windows supposably calls when I am clicked
        /// </summary>
        /// <param name="x">The X location of the mouse when clicked me</param>
        /// <param name="y">The Y location of the mouse when clicked me</param>
        public void Clicked(int x, int y)
        {
            ClickEventArgs e = new ClickEventArgs();
            e.X = x;
            e.Y = y;
            OnClick(e);
        }

        /// <summary>
        /// This is the protected method that acts uppon being clicked.
        /// It is declared as "protected virtual" so that derived classes
        /// will be able to override it.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnClick(ClickEventArgs e)
        {
            Console.WriteLine("Button ({0}): I was clicked", this.Text);

            DrawSinked();
            Pause();
            DrawRaised();

            // call a pointer to function, to let others know that I was clicked:
            if (ClickOccured != null)
            {
                Console.WriteLine("Button ({0}): I am notifying others by executing the delegate", this.Text);
                ClickOccured(this, e);
            }
        }

        private void DrawRaised()
        {
            Console.WriteLine("Button ({0}): I am drawing myself raised", this.Text);
        }

        private void Pause()
        {
            Console.WriteLine("Button ({0}): I am pausing between drawing", this.Text);
        }

        private void DrawSinked()
        {
            Console.WriteLine("Button ({0}): I am drawing myself sinked", this.Text);
        }

        public void Show()
        {
            Console.WriteLine("Button ({0}): === {0} ===", this.Text);
        }
	
    }
}
