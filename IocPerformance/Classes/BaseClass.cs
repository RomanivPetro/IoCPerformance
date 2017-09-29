using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IocPerformance.Classes
{
    public abstract class BaseClass
    {
        public virtual void DoSomething()
        {
            Debug.WriteLine("test");
        }
    }
}
