using System;
using System.Collections.Generic;
using System.Text;

namespace Classes
{
    public class ModifiersExample
    {
        public static int s_StaticMember = 0;

        // const must be initialized inline:
        public const int k_ConstMember = 15;

        // readonly can be initialized inline or in the CTOR:
        public readonly int r_ReadonlytMember1 = 18;
        public readonly int r_ReadonlytMember2;
        public readonly List<int> r_Numbers = new List<int>();

        public ModifiersExample(int i_InitForReadonly)
        {
            // initializing the second readonly field in the CTOR:
            r_ReadonlytMember2 = i_InitForReadonly;
        }

        //CTOR overloading:
        public ModifiersExample()
            : this(0)// calling the other CTOR
        {
            // the fact that r_Numbers is a readonly field, doesn't mean you can not modify the object:
            r_Numbers.Add(500);
            r_Numbers.Add(600);
            r_Numbers.Remove(500);
            r_Numbers.Clear();
        }

        // static readonly can be initialized inline or in a static CTOR:
        public static readonly int sr_InlineStaticReadonlyField = 200;
        public static readonly int sr_StaticReadonlyField;

        // static constructor (alos called "type initializer") is used to initiazlize static readonly data
        // it is called by the CLR's Class Loader before first use of the class
        static ModifiersExample()
        {
            // initializing the second static readonly field in the CTOR:
            sr_StaticReadonlyField = 400;
        }

        public void MethodWiteConstLocalVariable()
        {
            // this is an example of a local const variable
            const int k_NumberOfStudents = 5;
        }

        public static void SomeStaticMethod()
        {
            // static methods can only refer to static fields:
            s_StaticMember++;

            // this line will not compile:
            // r_ReadonlytMember1++;
        }
    }
}
