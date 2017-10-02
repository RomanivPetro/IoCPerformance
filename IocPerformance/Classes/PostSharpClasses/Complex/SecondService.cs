using System.ComponentModel.Composition;
using IocPerformance.Classes.PostSharpClasses;
using MEF2Attr = System.Composition;

namespace IocPerformance.Classes.Complex
{
    [Export(typeof(ISecondService)), PartCreationPolicy(CreationPolicy.Shared)]
    [MEF2Attr.Export(typeof(ISecondService))]
    public class SecondServicePS : BaseClassPS, ISecondService
    {
        public SecondServicePS()
        {
        }
    }
}
