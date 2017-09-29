using System;
using System.ComponentModel.Composition;
using MEF2Attr = System.Composition;

namespace IocPerformance.Classes.Complex
{
    public interface ISubObjectThree
    {
        void DoSomething();
    }

    [Export(typeof(ISubObjectThree)), PartCreationPolicy(CreationPolicy.NonShared)]
    [MEF2Attr.Export(typeof(ISubObjectThree))]
    public class SubObjectThree : ISubObjectThree
    {
        private readonly IThirdService third;

        [ImportingConstructor]
        [System.Composition.ImportingConstructor]
        public SubObjectThree(IThirdService thirdService)
        {
            if (thirdService == null)
            {
                throw new ArgumentNullException(nameof(thirdService));
            }
            third = thirdService;
        }

        public void DoSomething()
        {
            third.DoSomething();
        }
    }
}
