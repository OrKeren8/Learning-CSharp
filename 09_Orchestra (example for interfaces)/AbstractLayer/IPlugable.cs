using System;
using System.Collections.Generic;
using System.Text;

namespace Orchestra
{
    /// <summary>
    /// An interface may declare only public abstract operations (methods/propeties)
    /// An interface can not hold fields, static methods, consts, or any kind of implementation
    /// </summary>
    public interface IPlugable
    {
        void Plug();

        float Voltage
        {
            get;
        }
    }
}
