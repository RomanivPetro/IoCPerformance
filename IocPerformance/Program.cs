﻿using System;
using System.Collections.Generic;
using System.Linq;
using IocPerformance.Benchmarks;
using IocPerformance.Output;

namespace IocPerformance
{
    internal class Program
    {
        public static List<string> benchmarksToUpdate = new List<string>(){"01","02","03","04"};

        public static void Main(string[] args)
        {
            var containers = ContainerAdapterFactory.CreateAdapters().ToArray();
            var benchmarks = BenchmarkFactory.CreateBenchmarks().ToArray();

            var benchmarkResults = new List<BenchmarkResult>();
            var existingBenchmarkResults = new List<BenchmarkResult>();

            foreach (var container in containers)
            {
                AppDomain childDomain = null;

                try
                {
                    AppDomainSetup domainSetup = new AppDomainSetup()
                    {
                        ApplicationBase = AppDomain.CurrentDomain.SetupInformation.ApplicationBase,
                        ConfigurationFile = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile,
                        ApplicationName = AppDomain.CurrentDomain.SetupInformation.ApplicationName,
                        LoaderOptimization = LoaderOptimization.MultiDomainHost
                    };

                    childDomain = AppDomain.CreateDomain("AppDomain for " + container.Name, null, domainSetup);

                    ContainerAdapterRuntime runtime = (ContainerAdapterRuntime)childDomain.CreateInstanceAndUnwrap(
                        typeof(ContainerAdapterRuntime).Assembly.FullName,
                        typeof(ContainerAdapterRuntime).FullName);

                    var containerBenchmarkResults = runtime.Run(container.GetType(), existingBenchmarkResults);
                    benchmarkResults.AddRange(containerBenchmarkResults);
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(
                        " Container '{0}' failed: {1}",
                        container.Name,
                        ex.Message);
                    Console.ResetColor();
                }
                finally
                {
                    if (childDomain != null)
                    {
                        AppDomain.Unload(childDomain);
                    }

                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    GC.Collect();
                }

                Console.WriteLine();
            }

            IOutput output = new MultiOutput(
                new XmlOutput(),
                new ChartOutput(),
                new JsonOutput()
                );

            output.Create(benchmarks, benchmarkResults);

            Console.WriteLine("Done");
            Console.ReadKey();
        }
    }
}