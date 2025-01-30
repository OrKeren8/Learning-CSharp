using System;
using System.Collections.Generic;
using System.Text;

namespace Orchestra.ConcreteMusicians
{
    public class TrianglePlayer : Musician
    {
        /// <summary>
        /// Overriding the abstract Musician.Play() method
        /// </summary>
        public override void Play()
        {
            Console.WriteLine(this.GetType().Name + " is playing :)");
        }
    }
}
