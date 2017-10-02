using System;
using System.ComponentModel.Composition;
using IocPerformance.Aspects;
using MEF2Attr = System.Composition;

namespace IocPerformance.Classes.Complex
{
    [Export(typeof(ISubObjectTwo)), PartCreationPolicy(CreationPolicy.NonShared)]
    [MEF2Attr.Export(typeof(ISubObjectTwo))]
    public class SubObjectTwoPS : ISubObjectTwo
    {
        private readonly ISecondService second;
        [ImportingConstructor]
        [System.Composition.ImportingConstructor]
        public SubObjectTwoPS(ISecondService secondService)
        {
            if (secondService == null)
            {
                throw new ArgumentNullException(nameof(secondService));
            }
            second = secondService;
        }

        [LoggingAspect]
        public void DoSomething()
        {
            second.DoSomething();
        }
    }
}
