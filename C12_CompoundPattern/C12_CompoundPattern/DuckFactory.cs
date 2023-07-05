using System.Runtime.Remoting.Messaging;

namespace C12_CompoundPattern.Properties
{
    public abstract class AbstractDuckFactory
    {
        public abstract IQuackable CreateMallardDuck();
        public abstract IQuackable CreateRedheadDuck();
        public abstract IQuackable CreateDuckCall();
        public abstract IQuackable CreateRubberDuck();
        public abstract IQuackable CreateGooseAdapter(AbstractGooseFactory gooseFactory);
    }

    public class DuckFactory:AbstractDuckFactory
    {
        public override IQuackable CreateMallardDuck() => new MallardDuck();
        public override IQuackable CreateRedheadDuck() => new RedHeadDuck();
        public override IQuackable CreateDuckCall() => new DuckCall();
        public override IQuackable CreateRubberDuck() => new RubberDuck();
        public override IQuackable CreateGooseAdapter(AbstractGooseFactory gooseFactory) 
            => new GooseAdapter(gooseFactory.CreateNormalGoose());
    }

    public class CountingDuckFactory : AbstractDuckFactory
    {
        public override IQuackable CreateMallardDuck() => new QuackCounter(new MallardDuck());
        public override IQuackable CreateRedheadDuck() => new QuackCounter(new RedHeadDuck());
        public override IQuackable CreateDuckCall() => new QuackCounter(new DuckCall());
        public override IQuackable CreateRubberDuck() => new QuackCounter(new RubberDuck());
        public override IQuackable CreateGooseAdapter(AbstractGooseFactory gooseFactory) 
            => new GooseAdapter(gooseFactory.CreateNormalGoose());
    }
}