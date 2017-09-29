using System;
using System.ComponentModel.Composition;
using System.Diagnostics;
using MEF2Attr = System.Composition;

namespace IocPerformance.Classes.Standard
{

    public interface ISingleton1
    {
        void DoSomething();
    }


    public interface ISingleton2
    {
        void DoSomething();
    }


    public interface ISingleton3
    {
        void DoSomething();
    }

    [Export(typeof(ISingleton1)), PartCreationPolicy(CreationPolicy.Shared)]
    [MEF2Attr.Export(typeof(ISingleton1)), MEF2Attr.Shared]

    public class Singleton1 : BaseClass, ISingleton1
    {
        private static int counter;

        public Singleton1()
        {
            System.Threading.Interlocked.Increment(ref counter);
        }

        public static int Instances
        {
            get { return counter; }
            set { counter = value; }
        }
    }

    [Export(typeof(ISingleton2)), PartCreationPolicy(CreationPolicy.Shared)]
    [MEF2Attr.Export(typeof(ISingleton2)), MEF2Attr.Shared]

    public class Singleton2 : BaseClass, ISingleton2
    {
        private static int counter;

        public Singleton2()
        {
            System.Threading.Interlocked.Increment(ref counter);
        }

        public static int Instances
        {
            get { return counter; }
            set { counter = value; }
        }
    }

    [Export(typeof(ISingleton3)), PartCreationPolicy(CreationPolicy.Shared)]
    [MEF2Attr.Export(typeof(ISingleton3)), MEF2Attr.Shared]
    public class Singleton3 : BaseClass, ISingleton3
    {
        private static int counter;
        public Singleton3()
        {
            System.Threading.Interlocked.Increment(ref counter);
        }

        public static int Instances
        {
            get { return counter; }
            set { counter = value; }
        }
    }
}
