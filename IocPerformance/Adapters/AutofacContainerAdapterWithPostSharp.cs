using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Autofac.Extras.DynamicProxy;
using IocPerformance.Classes.Child;
using IocPerformance.Classes.Complex;
using IocPerformance.Classes.Dummy;
using IocPerformance.Classes.Generics;
using IocPerformance.Classes.Multiple;
using IocPerformance.Classes.PostSharpClasses.Standard;
using IocPerformance.Classes.Standard;
using Transient1 = IocPerformance.Classes.Standard.Transient1;
using Transient2 = IocPerformance.Classes.Standard.Transient2;
using Transient3 = IocPerformance.Classes.Standard.Transient3;

namespace IocPerformance.Adapters
{
    public class AutofacContainerAdapterWithPostSharp:ContainerAdapterBase
    {
        private IContainer container;

        public override string PackageName => "Autofac_With PostSharp";

        public override string Url => "https://github.com/autofac/Autofac";

        public override bool SupportsInterception => true;

        public override bool SupportGeneric => true;

        public override bool SupportsMultiple => true;

        public override bool SupportsPropertyInjection => true;

        public override bool SupportsConditional => true;

        public override bool SupportsChildContainer => true;

        public override bool SupportAspNetCore => true;

        public override IChildContainerAdapter CreateChildContainerAdapter() => new AutofacChildContainerAdapter(this.container);

        public override object Resolve(Type type) => this.container.Resolve(type);

        public override void Dispose()
        {
            // Allow the container and everything it references to be garbage collected.
            if (this.container == null)
            {
                return;
            }

            this.container.Dispose();
            this.container = null;
        }

        public override void Prepare()
        {
            var autofacContainerBuilder = new ContainerBuilder();

            RegisterBasic(autofacContainerBuilder);

            //RegisterOpenGeneric(autofacContainerBuilder);
            //RegisterMultiple(autofacContainerBuilder);
            //RegisterInterceptor(autofacContainerBuilder);
            //this.RegisterAspNetCore(autofacContainerBuilder);

            this.container = autofacContainerBuilder.Build();
        }

        private void RegisterAspNetCore(ContainerBuilder autofacContainerBuilder)
        {
            autofacContainerBuilder.Populate(this.CreateServiceCollection());
        }

        public override void PrepareBasic()
        {
            var autofacContainerBuilder = new ContainerBuilder();

            RegisterBasic(autofacContainerBuilder);

            this.container = autofacContainerBuilder.Build();
        }

        private static void RegisterBasic(ContainerBuilder autofacContainerBuilder)
        {
            RegisterDummies(autofacContainerBuilder);
            RegisterStandard(autofacContainerBuilder);
            RegisterComplexObject(autofacContainerBuilder);
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
            autofacContainerBuilder.Register(c => new Singleton1PS()).As<ISingleton1>().SingleInstance();
            autofacContainerBuilder.Register(c => new Singleton2PS()).As<ISingleton2>().SingleInstance();
            autofacContainerBuilder.Register(c => new Singleton3PS()).As<ISingleton3>().SingleInstance();

            autofacContainerBuilder.Register(c => new Transient1PS()).As<ITransient1>();
            autofacContainerBuilder.Register(c => new Transient2PS()).As<ITransient2>();
            autofacContainerBuilder.Register(c => new Transient3PS()).As<ITransient3>();

            autofacContainerBuilder.Register(c => new Combined1PS(c.Resolve<ISingleton1>(), c.Resolve<ITransient1>())).As<ICombined1>();
            autofacContainerBuilder.Register(c => new Combined2PS(c.Resolve<ISingleton2>(), c.Resolve<ITransient2>())).As<ICombined2>();
            autofacContainerBuilder.Register(c => new Combined3PS(c.Resolve<ISingleton3>(), c.Resolve<ITransient3>())).As<ICombined3>();
        }

        private static void RegisterComplexObject(ContainerBuilder autofacContainerBuilder)
        {
            autofacContainerBuilder.Register(c => new FirstServicePS()).As<IFirstService>().SingleInstance();
            autofacContainerBuilder.Register(c => new SecondServicePS()).As<ISecondService>().SingleInstance();
            autofacContainerBuilder.Register(c => new ThirdServicePS()).As<IThirdService>().SingleInstance();
            autofacContainerBuilder.Register(c => new SubObjectOnePS(c.Resolve<IFirstService>())).As<ISubObjectOne>();
            autofacContainerBuilder.Register(c => new SubObjectTwoPS(c.Resolve<ISecondService>())).As<ISubObjectTwo>();
            autofacContainerBuilder.Register(c => new SubObjectThreePS(c.Resolve<IThirdService>())).As<ISubObjectThree>();
            autofacContainerBuilder.Register(c => new Complex1PS(c.Resolve<IFirstService>(), c.Resolve<ISecondService>(), c.Resolve<IThirdService>(), c.Resolve<ISubObjectOne>(), c.Resolve<ISubObjectTwo>(), c.Resolve<ISubObjectThree>())).As<IComplex1>();
            autofacContainerBuilder.Register(c => new Complex2PS(c.Resolve<IFirstService>(), c.Resolve<ISecondService>(), c.Resolve<IThirdService>(), c.Resolve<ISubObjectOne>(), c.Resolve<ISubObjectTwo>(), c.Resolve<ISubObjectThree>())).As<IComplex2>();
            autofacContainerBuilder.Register(c => new Complex3PS(c.Resolve<IFirstService>(), c.Resolve<ISecondService>(), c.Resolve<IThirdService>(), c.Resolve<ISubObjectOne>(), c.Resolve<ISubObjectTwo>(), c.Resolve<ISubObjectThree>())).As<IComplex3>();
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

            autofacContainerBuilder.Register(c => new ImportMultiple1(c.Resolve<IEnumerable<ISimpleAdapter>>())).As<ImportMultiple1>();
            autofacContainerBuilder.Register(c => new ImportMultiple2(c.Resolve<IEnumerable<ISimpleAdapter>>())).As<ImportMultiple2>();
            autofacContainerBuilder.Register(c => new ImportMultiple3(c.Resolve<IEnumerable<ISimpleAdapter>>())).As<ImportMultiple3>();
        }

        private static void RegisterInterceptor(ContainerBuilder autofacContainerBuilder)
        {
            autofacContainerBuilder.Register(c => new Calculator1()).As<ICalculator1>().EnableInterfaceInterceptors();
            autofacContainerBuilder.Register(c => new Calculator2()).As<ICalculator2>().EnableInterfaceInterceptors();
            autofacContainerBuilder.Register(c => new Calculator3()).As<ICalculator3>().EnableInterfaceInterceptors();
        }
    }
}
