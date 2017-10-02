using System.ComponentModel.Composition;
using IocPerformance.Classes.Standard;

namespace IocPerformance.Classes.PostSharpClasses.Standard
{

    [Export(typeof(ITransient1)), PartCreationPolicy(CreationPolicy.NonShared)]
    [System.Composition.Export(typeof(ITransient1))]
    public class Transient1PS : BaseClassPS, ITransient1
    {
        private static int counter;

        public Transient1PS()
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
    public class Transient2PS : BaseClassPS, ITransient2
    {
        private static int counter;

        public Transient2PS()
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
    public class Transient3PS : BaseClassPS, ITransient3
    {
        private static int counter;

        public Transient3PS()
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
