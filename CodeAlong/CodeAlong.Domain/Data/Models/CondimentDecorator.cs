namespace CodeAlong.Domain.Data.Models
{
    public abstract class CondimentDecorator : Beverage
    {
        public override string Description { get; protected set; } = "Unknown Beverage";
    }

    public class Mocha : CondimentDecorator
    {
        private readonly Beverage beverage;

        public Mocha(Beverage beverage)
        {
            this.beverage = beverage;
        }

        public override string Description => beverage.Description + ", Mocha";

        public override double Cost()
        {
            return 0.20 + beverage.Cost();
        }

        public override string GetInfo => $"{Size} {Description} - {Cost():C2}";
    }

    public class Whip : CondimentDecorator
    {
        private readonly Beverage beverage;

        public Whip(Beverage beverage)
        {
            this.beverage = beverage;
        }

        public override string Description => beverage.Description + ", Whip";

        public override double Cost()
        {
            return 0.10 + beverage.Cost();
        }

        public override string GetInfo => $"{Size} {Description} - {Cost():C2}";
    }

    public class Soy : CondimentDecorator
    {
        private readonly Beverage beverage;

        public Soy(Beverage beverage)
        {
            this.beverage = beverage;
        }

        public override string Description => beverage.Description + ", Soy";

        public override double Cost()
        {
            return 0.15 + beverage.Cost();
        }

        public override string GetInfo => $"{Size} {Description} - {Cost():C2}";
    }
}

