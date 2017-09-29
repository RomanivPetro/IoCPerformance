using System;
using System.ComponentModel.Composition;
using MEF2Attr = System.Composition;

namespace IocPerformance.Classes.Complex
{
    public interface ISubObjectTwo
    {
        void DoSomething();
    }

    [Export(typeof(ISubObjectTwo)), PartCreationPolicy(CreationPolicy.NonShared)]
    [MEF2Attr.Export(typeof(ISubObjectTwo))]
    public class SubObjectTwo : ISubObjectTwo
    {
        private readonly ISecondService second;
        [ImportingConstructor]
        [System.Composition.ImportingConstructor]
        public SubObjectTwo(ISecondService secondService)
        {
            if (secondService == null)
            {
                throw new ArgumentNullException(nameof(secondService));
            }
            second = secondService;
        }

        public void DoSomething()
        {
            second.DoSomething();
        }
    }
}
