using System;
using System.Collections.Generic;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Autofac.Extras.DynamicProxy;
using IocPerformance.Classes.Complex;
using IocPerformance.Classes.Dummy;
using IocPerformance.Classes.Generics;
using IocPerformance.Classes.Multiple;
using IocPerformance.Classes.PostSharpClasses.Standard;
using IocPerformance.Classes.Standard;
using IocPerformance.Interception;
using Transient1 = IocPerformance.Classes.Standard.Transient1;
using Transient2 = IocPerformance.Classes.Standard.Transient2;
using Transient3 = IocPerformance.Classes.Standard.Transient3;

namespace IocPerformance.Adapters
{
    public class AutofacInterceptorAdapter : ContainerAdapterBase
    {
        private IContainer container;

        public override string PackageName => "Autofac_Interceptor";

        public override string Url => "https://github.com/autofac/Autofac";

        public override bool SupportsInterception => true;

        public override bool SupportGeneric => true;

        public override bool SupportsMultiple => true;

        public override bool SupportsPropertyInjection => true;

        public override bool SupportsConditional => true;

        public override bool SupportsChildContainer => true;

        public override bool SupportAspNetCore => true;

        public override IChildContainerAdapter CreateChildContainerAdapter()
        {
            return new AutofacChildContainerAdapter(container);
        }

        public override object Resolve(Type type)
        {
            return container.Resolve(type);
        }

        public override void Dispose()
        {
            // Allow the container and everything it references to be garbage collected.
            if (container == null)
                return;

            container.Dispose();
            container = null;
        }

        public override void Prepare()
        {
            var autofacContainerBuilder = new ContainerBuilder();

            autofacContainerBuilder.Register(c => new AutofacInterceptionLogger());

            RegisterBasic(autofacContainerBuilder);
            //RegisterOpenGeneric(autofacContainerBuilder);
            //RegisterMultiple(autofacContainerBuilder);
            //RegisterInterceptor(autofacContainerBuilder);
            //RegisterAspNetCore(autofacContainerBuilder);

            container = autofacContainerBuilder.Build();
        }

        private void RegisterAspNetCore(ContainerBuilder autofacContainerBuilder)
        {
            autofacContainerBuilder.Populate(CreateServiceCollection());
        }

        public override void PrepareBasic()
        {
            var autofacContainerBuilder = new ContainerBuilder();
            autofacContainerBuilder.Register(c => new AutofacInterceptionLogger()).SingleInstance();

            RegisterBasic(autofacContainerBuilder);

            container = autofacContainerBuilder.Build();
        }

        private static void RegisterBasic(ContainerBuilder autofacContainerBuilder)
        {
            RegisterDummies(autofacContainerBuilder);
            RegisterStandard(autofacContainerBuilder);
            //RegisterComplexObject(autofacContainerBuilder);
        }

        private static void RegisterDummies(ContainerBuilder autofacContainerBuilder)
        {
            autofacContainerBuilder.Register(c => new DummyOne()).As<IDummyOne>();
            autofacContainerBuilder.Register(c => new DummyTwo()).As<IDummyTwo>();
            autofacContainerBuilder.Register(c => new DummyThree()).As<IDummyThree>();
            autofacContainerBuilder.Register(c => new DummyFour()).As<IDummyFour>();
            autofacContainerBuilder.Register(c => new DummyFive()).As<IDummyFive>();
            autofacContainerBuilder.Register(c => new DummySix()).As<IDummySix>();
            autofacContainerBuilder.Register(c => new DummySeven()).As<IDummySeven>();
            autofacContainerBuilder.Register(c => new DummyEight()).As<IDummyEight>();
            autofacContainerBuilder.Register(c => new DummyNine()).As<IDummyNine>();
            autofacContainerBuilder.Register(c => new DummyTen()).As<IDummyTen>();
        }

        private static void RegisterStandard(ContainerBuilder autofacContainerBuilder)
        {
            autofacContainerBuilder.Register(c => new Singleton1()).As<ISingleton1>().SingleInstance()
                .EnableInterfaceInterceptors().InterceptedBy(typeof(AutofacInterceptionLogger));
            autofacContainerBuilder.Register(c => new Singleton2()).As<ISingleton2>().SingleInstance()
                .EnableInterfaceInterceptors().InterceptedBy(typeof(AutofacInterceptionLogger));
            autofacContainerBuilder.Register(c => new Singleton3()).As<ISingleton3>().SingleInstance()
                .EnableInterfaceInterceptors().InterceptedBy(typeof(AutofacInterceptionLogger));

            autofacContainerBuilder.Register(c => new Transient1()).As<ITransient1>().EnableInterfaceInterceptors()
                .InterceptedBy(typeof(AutofacInterceptionLogger));
            autofacContainerBuilder.Register(c => new Transient2()).As<ITransient2>().EnableInterfaceInterceptors()
                .InterceptedBy(typeof(AutofacInterceptionLogger));
            autofacContainerBuilder.Register(c => new Transient3()).As<ITransient3>().EnableInterfaceInterceptors()
                .InterceptedBy(typeof(AutofacInterceptionLogger));

            autofacContainerBuilder.Register(c => new Combined1(c.Resolve<ISingleton1>(), c.Resolve<ITransient1>()))
                .As<ICombined1>().EnableInterfaceInterceptors().InterceptedBy(typeof(AutofacInterceptionLogger));
            autofacContainerBuilder.Register(c => new Combined2(c.Resolve<ISingleton2>(), c.Resolve<ITransient2>()))
                .As<ICombined2>().EnableInterfaceInterceptors().InterceptedBy(typeof(AutofacInterceptionLogger));
            autofacContainerBuilder.Register(c => new Combined3(c.Resolve<ISingleton3>(), c.Resolve<ITransient3>()))
                .As<ICombined3>().EnableInterfaceInterceptors().InterceptedBy(typeof(AutofacInterceptionLogger));
        }

        private static void RegisterComplexObject(ContainerBuilder autofacContainerBuilder)
        {
            autofacContainerBuilder.Register(c => new FirstService()).As<IFirstService>().SingleInstance();
            autofacContainerBuilder.Register(c => new SecondService()).As<ISecondService>().SingleInstance();
            autofacContainerBuilder.Register(c => new ThirdService()).As<IThirdService>().SingleInstance();
            autofacContainerBuilder.Register(c => new SubObjectOne(c.Resolve<IFirstService>())).As<ISubObjectOne>();
            autofacContainerBuilder.Register(c => new SubObjectTwo(c.Resolve<ISecondService>())).As<ISubObjectTwo>();
            autofacContainerBuilder.Register(c => new SubObjectThree(c.Resolve<IThirdService>())).As<ISubObjectThree>();
            autofacContainerBuilder.Register(c => new Complex1(c.Resolve<IFirstService>(), c.Resolve<ISecondService>(),
                c.Resolve<IThirdService>(), c.Resolve<ISubObjectOne>(), c.Resolve<ISubObjectTwo>(),
                c.Resolve<ISubObjectThree>())).As<IComplex1>().EnableInterfaceInterceptors().InterceptedBy(typeof(AutofacInterceptionLogger));
            autofacContainerBuilder.Register(c => new Complex2(c.Resolve<IFirstService>(), c.Resolve<ISecondService>(),
                c.Resolve<IThirdService>(), c.Resolve<ISubObjectOne>(), c.Resolve<ISubObjectTwo>(),
                c.Resolve<ISubObjectThree>())).As<IComplex2>().EnableInterfaceInterceptors().InterceptedBy(typeof(AutofacInterceptionLogger));
            autofacContainerBuilder.Register(c => new Complex3(c.Resolve<IFirstService>(), c.Resolve<ISecondService>(),
                c.Resolve<IThirdService>(), c.Resolve<ISubObjectOne>(), c.Resolve<ISubObjectTwo>(),
                c.Resolve<ISubObjectThree>())).As<IComplex3>().EnableInterfaceInterceptors().InterceptedBy(typeof(AutofacInterceptionLogger));
        }

        private static void RegisterOpenGeneric(ContainerBuilder autofacContainerBuilder)
        {
            autofacContainerBuilder.RegisterGeneric(typeof(GenericExport<>)).As(typeof(IGenericInterface<>));
            autofacContainerBuilder.RegisterGeneric(typeof(ImportGeneric<>)).As(typeof(ImportGeneric<>));
        }

        private static void RegisterMultiple(ContainerBuilder autofacContainerBuilder)
        {
            autofacContainerBuilder.Register(c => new SimpleAdapterOne()).As<ISimpleAdapter>();
            autofacContainerBuilder.Register(c => new SimpleAdapterTwo()).As<ISimpleAdapter>();
            autofacContainerBuilder.Register(c => new SimpleAdapterThree()).As<ISimpleAdapter>();
            autofacContainerBuilder.Register(c => new SimpleAdapterFour()).As<ISimpleAdapter>();
            autofacContainerBuilder.Register(c => new SimpleAdapterFive()).As<ISimpleAdapter>();

            autofacContainerBuilder.Register(c => new ImportMultiple1(c.Resolve<IEnumerable<ISimpleAdapter>>()))
                .As<ImportMultiple1>();
            autofacContainerBuilder.Register(c => new ImportMultiple2(c.Resolve<IEnumerable<ISimpleAdapter>>()))
                .As<ImportMultiple2>();
            autofacContainerBuilder.Register(c => new ImportMultiple3(c.Resolve<IEnumerable<ISimpleAdapter>>()))
                .As<ImportMultiple3>();
        }

        private static void RegisterInterceptor(ContainerBuilder autofacContainerBuilder)
        {
            autofacContainerBuilder.Register(c => new Calculator1()).As<ICalculator1>().EnableInterfaceInterceptors().InterceptedBy(typeof(AutofacInterceptionLogger));
            autofacContainerBuilder.Register(c => new Calculator2()).As<ICalculator2>().EnableInterfaceInterceptors().InterceptedBy(typeof(AutofacInterceptionLogger));
            autofacContainerBuilder.Register(c => new Calculator3()).As<ICalculator3>().EnableInterfaceInterceptors().InterceptedBy(typeof(AutofacInterceptionLogger));
        }
    }
}