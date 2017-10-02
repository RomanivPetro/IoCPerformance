using IocPerformance.Classes.Standard;
using IocPerformance.Interception;

namespace IocPerformance.Classes.Standard
{ 
    public class Calculator1PS : ICalculator1
    {
        private static int counter;

        public Calculator1PS()
        {
            System.Threading.Interlocked.Increment(ref counter);
        }

        public static int Instances
        {
            get { return counter; }
            set { counter = value; }
        }

        public virtual int Add(int first, int second) => first + second;
    }

    public class Calculator2PS : ICalculator2
    {
        private static int counter;

        public Calculator2PS()
        {
            System.Threading.Interlocked.Increment(ref counter);
        }

        public static int Instances
        {
            get { return counter; }
            set { counter = value; }
        }

        public virtual int Add(int first, int second) => first + second;
    }

    public class Calculator3PS : ICalculator3
    {
        private static int counter;

        public Calculator3PS()
        {
            System.Threading.Interlocked.Increment(ref counter);
        }

        public static int Instances
        {
            get { return counter; }
            set { counter = value; }
        }

        public virtual int Add(int first, int second) => first + second;
    }
}
