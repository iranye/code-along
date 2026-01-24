namespace CodeAlong.Domain.Data.Models
{
    public enum Size
    {
        Small,
        Medium,
        Large
    }

    // pdf page 135/97
    public abstract class Beverage
    {
        public string Description { get; protected set; } = "Unknown Beverage";

        public virtual Size Size { get; protected set; } = Size.Medium;

        public void SetSize(Size size)
        {
            Size = size;
        }

        public virtual string GetDescription()
        {
            return Description;
        }

        public abstract double Cost();
    }

    public class Espresso : Beverage
    {
        public Espresso()
        {
            Description = "Espresso";
        }
        public override double Cost()
        {
            return Size switch
            {
                Size.Small => 1.59,
                Size.Medium => 1.99,
                Size.Large => 2.20,
                _ => 1.99
            };
        }
    }

    public class HouseBlend : Beverage
    {
        public HouseBlend()
        {
            Description = "House Blend";
        }
        public override double Cost()
        {
            return Size switch
            {
                Size.Small => 0.69,
                Size.Medium => 0.89,
                Size.Large => 1.19,
                _ => 0.89
            };
        }
    }

    public class DarkRoast : Beverage
    {
        public DarkRoast()
        {
            Description = "Dark Roast";
        }
        public override double Cost()
        {
            return Size switch
            {
                Size.Small => 0.69,
                Size.Medium => 0.89,
                Size.Large => 1.19,
                _ => 0.89
            };
        }
    }
}

