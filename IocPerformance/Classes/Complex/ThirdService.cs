﻿using System.ComponentModel.Composition;
using MEF2Attr = System.Composition;

namespace IocPerformance.Classes.Complex
{
    public interface IThirdService
    {
        void DoSomething();
    }

    [Export(typeof(IThirdService)), PartCreationPolicy(CreationPolicy.Shared)]
    [MEF2Attr.Export(typeof(IThirdService))]
    public class ThirdService :BaseClass, IThirdService
    {
        public ThirdService()
        {
        }
    }
}
