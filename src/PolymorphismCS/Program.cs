using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolymorphismCS
{
    class Program
    {
        public class A
        {
            public virtual int Price()
            {
                return 0;
            }
        }

        public class A2
            : A
        {
        }

        public class A3
            : A
        {
            public override int Price()
            {
                return 1;
            }
        }

        public class A4
            : A
        {
            // warning CS0114: 'Program.A3.Price()' hides inherited member 'Program.A.Price()'. To make the current member override that implementation, add the override keyword. Otherwise add the new keyword.
            public int Price()
            {
                return 1;
            }
        }

        public class A5
            : A4
        {
        }

        public abstract class B
        {
            public abstract int Price();
        }

        public class B2
            : B
        {
            public override int Price()
            {
                return 1;
            }
        }

        public interface interfaceC
        {
            //Interfaces cannot contain instance fields
            //int A;
            int Price();
        }

        public class classC
            : interfaceC
        {
            public int Price()
            {
                return 1;
            }
        }

        public class ClassD
        {
            public virtual string Name()
            {
                return "D";
            }
        }

        public interface InterfaceD
        {
             string Name();
        }

        public class D
        // Class 'Program.D' cannot have multiple base classes: 'Program.ClassD' and 'Program.classC'
        //: ClassD, classC
        : interfaceC, InterfaceD
        {
            public string Name()
            {
                return "D";
            }

            public int Price()
            {
                return 1;
            }
        }


        static void Main(string[] args)
        {
            A a = new A();
            Console.WriteLine("A:{0}", a.Price());
            A2 a2 = new A2();
            Console.WriteLine("A2:{0}", a2.Price());
            Console.WriteLine("(A)A2:{0}", ((A)a2).Price());
            A3 a3 = new A3();
            Console.WriteLine("A3:{0}", a3.Price());
            Console.WriteLine("(A)A3:{0}", ((A)a3).Price());
            A4 a4 = new A4();
            Console.WriteLine("A4:{0}", a4.Price());
            Console.WriteLine("(A)A4:{0}", ((A)a4).Price());
            A5 a5 = new A5();
            Console.WriteLine("A5:{0}", a5.Price());
            Console.WriteLine("(A)A5:{0}", ((A)a5).Price());
            Console.WriteLine("(A4)A5:{0}", ((A4)a5).Price());

            //Cannot create an instance of the abstract type or interface 'Program.B'
            //B b = new B();
            B2 b2 = new B2();
            Console.WriteLine("B2:{0}", b2.Price());
            Console.WriteLine("(B)B2:{0}", ((B)b2).Price());

            //Cannot create an instance of the abstract type or interface 'Program.C'
            //interfaceC c = new interfaceC();
            classC c2 = new classC();
            Console.WriteLine("classC:{0}", c2.Price());
            Console.WriteLine("(interfaceC)C2:{0}", ((interfaceC)c2).Price());

        }
    }
}
