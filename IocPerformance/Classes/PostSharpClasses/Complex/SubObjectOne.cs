using System;
using System.ComponentModel.Composition;
using IocPerformance.Aspects;
using MEF2Attr = System.Composition;

namespace IocPerformance.Classes.Complex
{

    [Export(typeof(ISubObjectOne)), PartCreationPolicy(CreationPolicy.NonShared)]
    [MEF2Attr.Export(typeof(ISubObjectOne))]
    public class SubObjectOnePS : ISubObjectOne
    {
        private readonly IFirstService first;
        [ImportingConstructor]
        [System.Composition.ImportingConstructor]
        public SubObjectOnePS(IFirstService firstService)
        {
            if (firstService == null)
            {
                throw new ArgumentNullException(nameof(firstService));
            }
            first = firstService;
        }

        [LoggingAspect]
        public void DoSomething()
        {
            first.DoSomething();
        }
    }
}
