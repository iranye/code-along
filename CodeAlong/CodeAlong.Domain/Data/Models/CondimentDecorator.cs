namespace CodeAlong.Domain.Data.Models
{
    public abstract class CondimentDecorator : Beverage
    {
        public override string GetDescription()
        {
            return Description;
        }
    }

    public class Mocha : CondimentDecorator
    {
        private readonly Beverage beverage;

        public Mocha(Beverage beverage)
        {
            this.beverage = beverage;
        }

        public override string GetDescription()
        {
            return beverage.GetDescription() + ", Mocha";
        }

        public override double Cost()
        {
            return 0.20 + beverage.Cost();
        }
    }

    public class Whip : CondimentDecorator
    {
        private readonly Beverage beverage;
        public Whip(Beverage beverage)
        {
            this.beverage = beverage;
        }
        public override string GetDescription()
        {
            return beverage.GetDescription() + ", Whip";
        }
        public override double Cost()
        {
            return 0.10 + beverage.Cost();
        }
    }

    public class Soy : CondimentDecorator
    {
        private readonly Beverage beverage;
        public Soy(Beverage beverage)
        {
            this.beverage = beverage;
        }
        public override string GetDescription()
        {
            return beverage.GetDescription() + ", Soy";
        }
        public override double Cost()
        {
            return 0.15 + beverage.Cost();
        }
    }
}

