using System;
using System.ComponentModel.Composition;
using System.Threading;
using MEF2Attr = System.Composition;

namespace IocPerformance.Classes.Complex
{
    public interface IComplex1
    {
        void DoSomething();
    }

    public interface IComplex2
    {
        void DoSomething();
    }

    public interface IComplex3
    {
        void DoSomething();
    }

    [Export(typeof(IComplex1))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [MEF2Attr.ExportAttribute(typeof(IComplex1))]
    public class Complex1 : IComplex1
    {
        private static int counter;
        private readonly IFirstService firstService;
        private readonly ISecondService secondService;
        private readonly ISubObjectOne subObjectOne;
        private readonly ISubObjectThree subObjectThree;
        private readonly ISubObjectTwo subObjectTwo;
        private readonly IThirdService thirdService;

        [ImportingConstructor]
        [MEF2Attr.ImportingConstructorAttribute]
        public Complex1(
            IFirstService firstService,
            ISecondService secondService,
            IThirdService thirdService,
            ISubObjectOne subObjectOne,
            ISubObjectTwo subObjectTwo,
            ISubObjectThree subObjectThree)
        {
            if (firstService == null)
                throw new ArgumentNullException(nameof(firstService));

            if (secondService == null)
                throw new ArgumentNullException(nameof(secondService));

            if (thirdService == null)
                throw new ArgumentNullException(nameof(thirdService));

            if (subObjectOne == null)
                throw new ArgumentNullException(nameof(subObjectOne));

            if (subObjectTwo == null)
                throw new ArgumentNullException(nameof(subObjectTwo));

            if (subObjectThree == null)
                throw new ArgumentNullException(nameof(subObjectThree));

            Interlocked.Increment(ref counter);

            this.firstService = firstService;
            this.secondService = secondService;
            this.thirdService = thirdService;
            this.subObjectOne = subObjectOne;
            this.subObjectTwo = subObjectTwo;
            this.subObjectThree = subObjectThree;
        }

        public static int Instances
        {
            get => counter;
            set => counter = value;
        }

        public void DoSomething()
        {
            firstService.DoSomething();
            secondService.DoSomething();
            thirdService.DoSomething();
            subObjectOne.DoSomething();
            subObjectTwo.DoSomething();
            subObjectThree.DoSomething();
        }
    }

    [Export(typeof(IComplex2))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [MEF2Attr.ExportAttribute(typeof(IComplex2))]
    public class Complex2 : IComplex2
    {
        private static int counter;
        private readonly IFirstService firstService;
        private readonly ISecondService secondService;
        private readonly ISubObjectOne subObjectOne;
        private readonly ISubObjectThree subObjectThree;
        private readonly ISubObjectTwo subObjectTwo;
        private readonly IThirdService thirdService;

        [ImportingConstructor]
        [MEF2Attr.ImportingConstructorAttribute]
        public Complex2(
            IFirstService firstService,
            ISecondService secondService,
            IThirdService thirdService,
            ISubObjectOne subObjectOne,
            ISubObjectTwo subObjectTwo,
            ISubObjectThree subObjectThree)
        {
            if (firstService == null)
                throw new ArgumentNullException(nameof(firstService));

            if (secondService == null)
                throw new ArgumentNullException(nameof(secondService));

            if (thirdService == null)
                throw new ArgumentNullException(nameof(thirdService));

            if (subObjectOne == null)
                throw new ArgumentNullException(nameof(subObjectOne));

            if (subObjectTwo == null)
                throw new ArgumentNullException(nameof(subObjectTwo));

            if (subObjectThree == null)
                throw new ArgumentNullException(nameof(subObjectThree));

            Interlocked.Increment(ref counter);
            this.firstService = firstService;
            this.secondService = secondService;
            this.thirdService = thirdService;
            this.subObjectOne = subObjectOne;
            this.subObjectTwo = subObjectTwo;
            this.subObjectThree = subObjectThree;
        }

        public static int Instances
        {
            get => counter;
            set => counter = value;
        }

        public void DoSomething()
        {
            firstService.DoSomething();
            secondService.DoSomething();
            thirdService.DoSomething();
            subObjectOne.DoSomething();
            subObjectTwo.DoSomething();
            subObjectThree.DoSomething();
        }
    }

    [Export(typeof(IComplex3))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [MEF2Attr.ExportAttribute(typeof(IComplex3))]
    public class Complex3 : IComplex3
    {
        private static int counter;
        private readonly IFirstService firstService;
        private readonly ISecondService secondService;
        private readonly ISubObjectOne subObjectOne;
        private readonly ISubObjectThree subObjectThree;
        private readonly ISubObjectTwo subObjectTwo;
        private readonly IThirdService thirdService;

        [ImportingConstructor]
        [MEF2Attr.ImportingConstructorAttribute]
        public Complex3(
            IFirstService firstService,
            ISecondService secondService,
            IThirdService thirdService,
            ISubObjectOne subObjectOne,
            ISubObjectTwo subObjectTwo,
            ISubObjectThree subObjectThree)
        {
            if (firstService == null)
                throw new ArgumentNullException(nameof(firstService));

            if (secondService == null)
                throw new ArgumentNullException(nameof(secondService));

            if (thirdService == null)
                throw new ArgumentNullException(nameof(thirdService));

            if (subObjectOne == null)
                throw new ArgumentNullException(nameof(subObjectOne));

            if (subObjectTwo == null)
                throw new ArgumentNullException(nameof(subObjectTwo));

            if (subObjectThree == null)
                throw new ArgumentNullException(nameof(subObjectThree));

            Interlocked.Increment(ref counter);
            this.firstService = firstService;
            this.secondService = secondService;
            this.thirdService = thirdService;
            this.subObjectOne = subObjectOne;
            this.subObjectTwo = subObjectTwo;
            this.subObjectThree = subObjectThree;
            ;
        }

        public static int Instances
        {
            get => counter;
            set => counter = value;
        }

        public void DoSomething()
        {
            firstService.DoSomething();
            secondService.DoSomething();
            thirdService.DoSomething();
            subObjectOne.DoSomething();
            subObjectTwo.DoSomething();
            subObjectThree.DoSomething();
        }
    }
}