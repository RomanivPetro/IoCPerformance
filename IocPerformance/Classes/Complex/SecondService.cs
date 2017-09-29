using System.ComponentModel.Composition;
using MEF2Attr = System.Composition;

namespace IocPerformance.Classes.Complex
{
    public interface ISecondService
    {
        void DoSomething();
    }

    [Export(typeof(ISecondService)), PartCreationPolicy(CreationPolicy.Shared)]
    [MEF2Attr.Export(typeof(ISecondService))]
    public class SecondService :BaseClass, ISecondService
    {
        public SecondService()
        {
        }
    }
}
