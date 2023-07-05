using C12_CompoundPattern.Properties;

namespace C12_CompoundPattern
{
    public abstract class AbstractGooseFactory
    {
        public abstract IHonkable CreateNormalGoose();
    }

    public class GooseFactory : AbstractGooseFactory
    {
        public override IHonkable CreateNormalGoose() => new Goose();
    }
    
}