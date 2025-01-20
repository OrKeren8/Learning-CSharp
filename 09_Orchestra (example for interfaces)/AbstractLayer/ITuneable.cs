using System;
using System.Collections.Generic;
using System.Text;

namespace Orchestra
{
    public interface ITuneable
    {
        void Tune();

        int Note
        {
            get;
            set;
        }
    }
}
