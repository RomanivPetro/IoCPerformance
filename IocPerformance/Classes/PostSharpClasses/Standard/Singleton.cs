using System.ComponentModel.Composition;
using IocPerformance.Classes.Standard;
using MEF2Attr = System.Composition;

namespace IocPerformance.Classes.PostSharpClasses.Standard
{
    [System.ComponentModel.Composition.Export(typeof(ISingleton1)), PartCreationPolicy(CreationPolicy.Shared)]
    [MEF2Attr.Export(typeof(ISingleton1)), MEF2Attr.Shared]

    public class Singleton1PS : BaseClassPS, ISingleton1
    {
        private static int counter;

        public Singleton1PS()
        {
            System.Threading.Interlocked.Increment(ref counter);
        }

        public static int Instances
        {
            get { return counter; }
            set { counter = value; }
        }
    }

    [System.ComponentModel.Composition.Export(typeof(ISingleton2)), PartCreationPolicy(CreationPolicy.Shared)]
    [MEF2Attr.Export(typeof(ISingleton2)), MEF2Attr.Shared]

    public class Singleton2PS : BaseClassPS, ISingleton2
    {
        private static int counter;

        public Singleton2PS()
        {
            System.Threading.Interlocked.Increment(ref counter);
        }

        public static int Instances
        {
            get { return counter; }
            set { counter = value; }
        }
    }

    [System.ComponentModel.Composition.Export(typeof(ISingleton3)), PartCreationPolicy(CreationPolicy.Shared)]
    [MEF2Attr.Export(typeof(ISingleton3)), MEF2Attr.Shared]
    public class Singleton3PS : BaseClassPS, ISingleton3
    {
        private static int counter;
        public Singleton3PS()
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
