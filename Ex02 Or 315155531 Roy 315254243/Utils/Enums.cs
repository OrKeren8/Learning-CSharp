using System;
using System.Linq;

namespace Utils
{
    public class Enums
    {

        public static int GetMinValue<T>() where T : Enum
        {
            return Enum.GetValues(typeof(T)).Cast<int>().Min();
        }

        public static int GetMaxValue<T>() where T : Enum
        {
            return Enum.GetValues(typeof(T)).Cast<int>().Max();
        }

    }
}
