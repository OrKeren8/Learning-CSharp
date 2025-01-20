using System;
using System.Collections.Generic;
using System.Text;

namespace Orchestra.ConcreteMusicians
{
    public class Keyboardist : Musician, IPlugable
    {
        /// <summary>
        /// Overriding the abstract Musician.Play() method
        /// </summary>
        public override void Play()
        {
            Console.WriteLine(this.GetType().Name + " is playing :)");
        }

        #region IPlugable Members
        /// <summary>
        /// Implicit implementation of IPlugable.Plug() method
        /// </summary>
        public void Plug()
        {
            Console.WriteLine(this.GetType().Name + " is plugging :)");
        }

        /// <summary>
        /// Implicit implementation of IPlugable.Voltage() property
        /// </summary>
        public float Voltage
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }
        #endregion IPlugable Members
    }
}
