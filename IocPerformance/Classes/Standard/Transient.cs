using System;
using System.ComponentModel.Composition;

namespace IocPerformance.Classes.Standard
{

    public interface ITransient1
    {
        void DoSomething();
    }


    public interface ITransient2
    {
        void DoSomething();
    }


    public interface ITransient3
    {
        void DoSomething();
    }

    [Export(typeof(ITransient1)), PartCreationPolicy(CreationPolicy.NonShared)]
    [System.Composition.Export(typeof(ITransient1))]
    public class Transient1 : BaseClass, ITransient1
    {
        private static int counter;

        public Transient1()
        {
            System.Threading.Interlocked.Increment(ref counter);
        }

        public static int Instances
        {
            get { return counter; }
            set { counter = value; }
        }
    }

    [Export(typeof(ITransient2)), PartCreationPolicy(CreationPolicy.NonShared)]
    [System.Composition.Export(typeof(ITransient2))]
    public class Transient2 : BaseClass, ITransient2
    {
        private static int counter;

        public Transient2()
        {
            System.Threading.Interlocked.Increment(ref counter);
        }

        public static int Instances
        {
            get { return counter; }
            set { counter = value; }
        }
    }

    [Export(typeof(ITransient3)), PartCreationPolicy(CreationPolicy.NonShared)]
    [System.Composition.Export(typeof(ITransient3))]
    public class Transient3 : BaseClass, ITransient3
    {
        private static int counter;

        public Transient3()
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
