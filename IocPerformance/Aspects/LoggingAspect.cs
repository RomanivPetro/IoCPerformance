using System;
using System.Diagnostics;
using PostSharp.Aspects;

namespace IocPerformance.Aspects
{
    [Serializable]
    public class LoggingAspect:OnMethodBoundaryAspect
    {
        public override void OnEntry(PostSharp.Aspects.MethodExecutionArgs args)
        {
            Debug.WriteLine($"*** PostSharp: -- Method-{args.Instance}-{args.Method.Name} invoked");
            base.OnEntry(args);
        }

        public override void OnExit(PostSharp.Aspects.MethodExecutionArgs args)
        {
            Debug.WriteLine($"*** PostSharp: -- Method-{args.Instance}-{args.Method.Name} finished");
            base.OnExit(args);
        }
    }
}