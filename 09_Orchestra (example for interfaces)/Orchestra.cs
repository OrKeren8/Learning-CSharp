using System;
using System.Collections.Generic;
using System.Text;
using Orchestra.ConcreteMusicians;

namespace Orchestra
{
    public class Orchestra
    {
        private readonly List<Musician> r_Musicians = new List<Musician>();

        public List<Musician> Musicians
        {
            get { return r_Musicians; }
        }

        public void Play()
        {
            foreach (Musician musician in r_Musicians)
            {
                musician.Play();
            }
        }

        public void TuneInstruments()
        {
            foreach (Musician musician in r_Musicians)
            {
                if (musician is ITuneable)
                {
                    (musician as ITuneable).Tune();
                }
            }
        }

        public void PlugInstruments()
        {
            foreach (Musician musician in r_Musicians)
            {
                if (musician is IPlugable)
                {
                    (musician as IPlugable).Plug();
                }
            }
        }
    }
}
