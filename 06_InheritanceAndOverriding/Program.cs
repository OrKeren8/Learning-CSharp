using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace InheritanceAndOverriding
{
    class Program
    {
        static void Main()
        {
            A a = new A();
            a.Method();             // A::Method
            a.VirtMethod();         // A::VirtMethod

            a = new B();
            a.Method();             // A::Method
            a.VirtMethod();         // B::VirtMethod
            ((B)a).Method();        // B::Method
            ((B)a).VirtMethod();    // B::VirtMethod

            a = new C();            
            a.Method();             // A::Method
            a.VirtMethod();         // C::VirtMethod
            ((C)a).Method();        // C::new virtual Method
            ((C)a).VirtMethod();    // C::VirtMethod

            a = new D();
            a.Method();             // A::Method
            a.VirtMethod();         // C::VirtMethod
            ((D)a).Method();        // D::new virtual Method
            ((D)a).VirtMethod();    // C::VirtMethod (was sealed by C and thus can't be overriden!)
        }
    }

    class A
    {
        // A virtual (overridable) method:
        public virtual void VirtMethod()
        {
            Console.WriteLine("A::VirtMethod");
        }

        // A non-overridable method:
        public void Method()
        {
            Console.WriteLine("A::Method");
        }
    }

    class B : A
    {
        // overriding A's method:
        // Will be executed when working with this object.
        public override void VirtMethod()
        {
            Console.WriteLine("B::VirtMethod");
        }

        // overloading A's method.
        // Will be executed only when working with this object as a B object.
        public void Method()
        {
            Console.WriteLine("B::Method");
        }
    }

    class C : B
    {
        // overriding B's method, which is implicitly virtual (thus overridable)
        // Will be executed when working with this object.
        public sealed override void VirtMethod()
        {
            Console.WriteLine("C::VirtMethod (was sealed by C and thus can't be overriden!)");
        }

        // overloading B's method, and declaring it as virtual!
        // Will be executed only when working with this object as a C object.
        public new virtual void Method()
        {
            Console.WriteLine("C::new virtual Method");
        }
    }

    class D : C
    {
        // can't overriding C's VirtMethod, because it was sealed by C
        //public override void VirtMethod()
        //{
        //    Console.WriteLine("D::VirtMethod");
        //}

        // OVERLOADING C's virtual method, and declaring it as virtual!
        // Will be executed only when working with this object as a D object.
        public new virtual void Method()
        {
            Console.WriteLine("D::new virtual Method");
        }
    }
}
