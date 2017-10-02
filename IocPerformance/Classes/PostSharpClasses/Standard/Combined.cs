using System;
using System.ComponentModel.Composition;
using IocPerformance.Aspects;
using IocPerformance.Classes.PostSharpClasses.Standard;

namespace IocPerformance.Classes.Standard
{
    [Export(typeof(ICombined1)), PartCreationPolicy(CreationPolicy.NonShared)]
    [System.Composition.Export(typeof(ICombined1))]
    public class Combined1PS : ICombined1
    {
        private static int counter;
        private ISingleton1 first;
        private ITransient1 second;

        [ImportingConstructor]
        [System.Composition.ImportingConstructor]
        public Combined1PS(ISingleton1 first, ITransient1 second)
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

        [LoggingAspect]
        public void DoSomething()
        {
            first.DoSomething();
            second.DoSomething();
        }

    }

    [Export(typeof(ICombined2)), PartCreationPolicy(CreationPolicy.NonShared)]
    [System.Composition.Export(typeof(ICombined2))]
    public class Combined2PS : ICombined2
    {
        private static int counter;
        private ISingleton2 first;
        private ITransient2 second;

        [ImportingConstructor]
        [System.Composition.ImportingConstructor]
        public Combined2PS(ISingleton2 first, ITransient2 second)
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

        [LoggingAspect]
        public void DoSomething()
        {
            first.DoSomething();
            second.DoSomething();
        }
    }

    [Export(typeof(ICombined3)), PartCreationPolicy(CreationPolicy.NonShared)]
    [System.Composition.Export(typeof(ICombined3))]
    public class Combined3PS : ICombined3
    {
        private static int counter;
        private ISingleton3 first;
        private ITransient3 second;

        [ImportingConstructor]
        [System.Composition.ImportingConstructor]
        public Combined3PS(ISingleton3 first, ITransient3 second)
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

        [LoggingAspect]
        public void DoSomething()
        {
            first.DoSomething();
            second.DoSomething();
        }
    }
}
