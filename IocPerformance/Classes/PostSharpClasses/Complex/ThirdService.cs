using System.ComponentModel.Composition;
using IocPerformance.Classes.PostSharpClasses;
using MEF2Attr = System.Composition;

namespace IocPerformance.Classes.Complex
{

    [Export(typeof(IThirdService)), PartCreationPolicy(CreationPolicy.Shared)]
    [MEF2Attr.Export(typeof(IThirdService))]
    public class ThirdServicePS : BaseClassPS, IThirdService
    {
        public ThirdServicePS()
        {
        }
    }
}
