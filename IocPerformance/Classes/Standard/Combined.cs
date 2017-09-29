using System;
using System.ComponentModel.Composition;

namespace IocPerformance.Classes.Standard
{

    public interface ICombined1
    {
        void DoSomething();
    }


    public interface ICombined2 
    {
        void DoSomething();
    }

   
    public interface ICombined3
    {
        void DoSomething();
    }

    [Export(typeof(ICombined1)), PartCreationPolicy(CreationPolicy.NonShared)]
    [System.Composition.Export(typeof(ICombined1))]
    public class Combined1 : ICombined1
    {
        private static int counter;
        private ISingleton1 first;
        private ITransient1 second;

        [ImportingConstructor]
        [System.Composition.ImportingConstructor]
        public Combined1(ISingleton1 first, ITransient1 second)
        {
            this.first = first ?? throw new ArgumentNullException(nameof(first));
            this.second = second ?? throw new ArgumentNullException(nameof(first));

            System.Threading.Interlocked.Increment(ref counter);
        }

        public static int Instances
        {
            get { return counter; }
            set { counter = value; }
        }

        public void DoSomething()
        {
            first.DoSomething();
            second.DoSomething();
        }

    }

    [Export(typeof(ICombined2)), PartCreationPolicy(CreationPolicy.NonShared)]
    [System.Composition.Export(typeof(ICombined2))]
    public class Combined2 : ICombined2
    {
        private static int counter;
        private ISingleton2 first;
        private ITransient2 second;

        [ImportingConstructor]
        [System.Composition.ImportingConstructor]
        public Combined2(ISingleton2 first, ITransient2 second)
        {
            this.first = first ?? throw new ArgumentNullException(nameof(first));
            this.second = second ?? throw new ArgumentNullException(nameof(first));

            System.Threading.Interlocked.Increment(ref counter);
        }

        public static int Instances
        {
            get { return counter; }
            set { counter = value; }
        }

        public void DoSomething()
        {
            first.DoSomething();
            second.DoSomething();
        }
    }

    [Export(typeof(ICombined3)), PartCreationPolicy(CreationPolicy.NonShared)]
    [System.Composition.Export(typeof(ICombined3))]
    public class Combined3 : ICombined3
    {
        private static int counter;
        private ISingleton3 first;
        private ITransient3 second;

        [ImportingConstructor]
        [System.Composition.ImportingConstructor]
        public Combined3(ISingleton3 first, ITransient3 second)
        {
            this.first = first ?? throw new ArgumentNullException(nameof(first));
            this.second = second ?? throw new ArgumentNullException(nameof(first));

            System.Threading.Interlocked.Increment(ref counter);
        }

        public static int Instances
        {
            get { return counter; }
            set { counter = value; }
        }

        public void DoSomething()
        {
            first.DoSomething();
            second.DoSomething();
        }
    }
}
