using System.ComponentModel.Composition;
using MEF2Attr = System.Composition;

namespace IocPerformance.Classes.Complex
{
    public interface IFirstService
    {
        void DoSomething();
    }

    [Export(typeof(IFirstService)), PartCreationPolicy(CreationPolicy.Shared)]
    [MEF2Attr.Export(typeof(IFirstService))]
    public class FirstService : BaseClass, IFirstService
    {
        public FirstService()
        {
        }
    }
}
