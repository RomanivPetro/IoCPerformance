using System.Diagnostics;
using IocPerformance.Aspects;

namespace IocPerformance.Classes.PostSharpClasses
{
    public abstract class BaseClassPS
    {
        [LoggingAspect]
        public virtual void DoSomething()
        {
            Debug.WriteLine("Method for test");
        }
    }
}
