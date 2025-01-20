using System;
using System.Collections.Generic;
using System.Text;
using Orchestra.ConcreteMusicians;

namespace Orchestra
{
    public class Program
    {
        static void Main()
        {
            Orchestra orchestra = new Orchestra();

            orchestra.Musicians.Add(new Guitarist());
            orchestra.Musicians.Add(new Keyboardist());
            orchestra.Musicians.Add(new ViolinPlayer());
            orchestra.Musicians.Add(new TrianglePlayer());

            orchestra.PlugInstruments();
            orchestra.TuneInstruments();
            orchestra.Play();
        }
    }
}
