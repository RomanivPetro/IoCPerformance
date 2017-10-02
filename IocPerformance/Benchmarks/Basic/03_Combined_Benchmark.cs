﻿using System;
using IocPerformance.Adapters;
using IocPerformance.Classes.PostSharpClasses.Standard;
using IocPerformance.Classes.Standard;
using IocPerformance.Interception;

namespace IocPerformance.Benchmarks.Basic
{
    public class Combined_03_Benchmark : Benchmark
    {
        public override BenchmarkCategory Category => BenchmarkCategory.Basic;

        public override void MethodToBenchmark(IContainerAdapter container)
        {
            var combined1 = (ICombined1)container.Resolve(typeof(ICombined1));
            var combined2 = (ICombined2)container.Resolve(typeof(ICombined2));
            var combined3 = (ICombined3)container.Resolve(typeof(ICombined3));

            combined1.DoSomething();
            combined2.DoSomething();
            combined3.DoSomething();
        }

        public override void Verify(Adapters.IContainerAdapter container)
        {
            if (container.Name == "Autofac_With PostSharp")
            {
                if (Combined1PS.Instances != this.LoopCount
                    || Combined2PS.Instances != this.LoopCount
                    || Combined3PS.Instances != this.LoopCount)
                {
                    throw new Exception(string.Format("Combined count must be {0}", this.LoopCount));
                }

                if (Transient1PS.Instances != this.LoopCount
                    || Transient2PS.Instances != this.LoopCount
                    || Transient3PS.Instances != this.LoopCount)
                {
                    throw new Exception(string.Format("Transient count must be {0}", this.LoopCount));
                }

                if (Singleton1PS.Instances > 1 || Singleton2PS.Instances > 1 || Singleton2PS.Instances > 1)
                {
                    throw new Exception("Singleton instance count must be 1. Container: " + container.Name);
                }
                return;
            }

            if (Combined1.Instances != this.LoopCount
                || Combined2.Instances != this.LoopCount
                || Combined3.Instances != this.LoopCount)
            {
                throw new Exception(string.Format("Combined count must be {0}", this.LoopCount));
            }

            if (Transient1.Instances != this.LoopCount
                || Transient2.Instances != this.LoopCount
                || Transient3.Instances != this.LoopCount)
            {
                throw new Exception(string.Format("Transient count must be {0}", this.LoopCount));
            }

            if (Singleton1.Instances > 1 || Singleton2.Instances > 1 || Singleton2.Instances > 1)
            {
                throw new Exception("Singleton instance count must be 1. Container: " + container.Name);
            }
        }
    }
}