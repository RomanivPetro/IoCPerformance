using System;
using System.ComponentModel.Composition;
using IocPerformance.Aspects;
using MEF2Attr = System.Composition;

namespace IocPerformance.Classes.Complex
{

    [Export(typeof(ISubObjectThree)), PartCreationPolicy(CreationPolicy.NonShared)]
    [MEF2Attr.Export(typeof(ISubObjectThree))]
    public class SubObjectThreePS : ISubObjectThree
    {
        private readonly IThirdService third;

        [ImportingConstructor]
        [System.Composition.ImportingConstructor]
        public SubObjectThreePS(IThirdService thirdService)
        {
            if (thirdService == null)
            {
                throw new ArgumentNullException(nameof(thirdService));
            }
            third = thirdService;
        }

        [LoggingAspect]
        public void DoSomething()
        {
            third.DoSomething();
        }
    }
}
