using System;
using System.Collections.Generic;
using System.Text;

namespace Orchestra.ConcreteMusicians
{
    public class ViolinPlayer : Musician, ITuneable
    {
        /// <summary>
        /// Overriding the abstract Musician.Play() method
        /// </summary>
        public override void Play()
        {
            Console.WriteLine(this.GetType().Name + " is playing :)");
        }

        #region ITuneable Members
        /// <summary>
        /// Explicit implementation of ITuneable.Tune() method
        /// </summary>
        public void Tune()
        {
            Console.WriteLine(this.GetType().Name + " is tunning :)");
        }

        /// <summary>
        /// Explicit implementation of ITuneable.Note property
        /// </summary>
        public int Note
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }
        #endregion ITuneable Members
    }
}
