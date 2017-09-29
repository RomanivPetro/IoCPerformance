using System;
using System.ComponentModel.Composition;
using MEF2Attr = System.Composition;

namespace IocPerformance.Classes.Complex
{
    public interface ISubObjectOne
    {
        void DoSomething();
    }

    [Export(typeof(ISubObjectOne)), PartCreationPolicy(CreationPolicy.NonShared)]
    [MEF2Attr.Export(typeof(ISubObjectOne))]
    public class SubObjectOne : ISubObjectOne
    {
        private readonly IFirstService first;
        [ImportingConstructor]
        [System.Composition.ImportingConstructor]
        public SubObjectOne(IFirstService firstService)
        {
            if (firstService == null)
            {
                throw new ArgumentNullException(nameof(firstService));
            }
            first = firstService;
        }

        public void DoSomething()
        {
            first.DoSomething();
        }
    }
}
