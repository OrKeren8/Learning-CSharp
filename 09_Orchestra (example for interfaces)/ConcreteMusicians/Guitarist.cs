using System;
using System.Collections.Generic;
using System.Text;

namespace Orchestra.ConcreteMusicians
{
    public class Guitarist : Musician, ITuneable, IPlugable
    {
        /// <summary>
        /// Overriding the abstract Musician.Play() method
        /// </summary>
        public override void Play()
        {
            Console.WriteLine(this.GetType().Name + " is playing :)");
        }

        /// <summary>
        /// Explicit implementation of ITuneable.Tune() method
        /// When implementing explicitly, the method is public when referenced by the interfacem and private otherwise
        /// </summary>
        void ITuneable.Tune()
        {
            Console.WriteLine(this.GetType().Name + " is tunning :)");
        }

        private int m_Note;
        /// <summary>
        /// Explicit implementation of ITuneable.Note property
        /// When implementing explicitly, the property is public when referenced by the interfacem and private otherwise
        /// </summary>
        int ITuneable.Note
        {
            get { return m_Note; }
            set { m_Note = value; }
        }

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
            get { return 220; }
        }
    }
}
