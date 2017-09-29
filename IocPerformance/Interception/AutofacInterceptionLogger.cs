using System;
using System.Diagnostics;
using System.Linq;
using Castle.DynamicProxy;

namespace IocPerformance.Interception
{
    public class AutofacInterceptionLogger : IInterceptor
    {
        private static int counter;

        public AutofacInterceptionLogger()
        {
            System.Threading.Interlocked.Increment(ref counter);
        }
        public void Intercept(IInvocation invocation)
        {
            var args = string.Join(", ", invocation.Arguments.Select(x => (x ?? string.Empty).ToString()));
            Debug.WriteLine($"*** Autofac: -- Method {invocation.TargetType}-{invocation.Method.Name}({args}) invoked");

            invocation.Proceed();

            Debug.WriteLine($"*** Autofac: -- Method {invocation.TargetType}-{invocation.Method.Name}({args}) finished");
        }

        public static int Instances
        {
            get { return counter; }
            set { counter = value; }
        }
    }
}
