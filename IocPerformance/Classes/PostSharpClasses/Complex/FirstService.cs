using System.ComponentModel.Composition;
using IocPerformance.Classes.PostSharpClasses;
using MEF2Attr = System.Composition;

namespace IocPerformance.Classes.Complex
{
    [Export(typeof(IFirstService)), PartCreationPolicy(CreationPolicy.Shared)]
    [MEF2Attr.Export(typeof(IFirstService))]
    public class FirstServicePS : BaseClassPS, IFirstService
    {
        public FirstServicePS()
        {
        }
    }
}
