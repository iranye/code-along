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
        public virtual string Description { get; protected set; } = "Unknown Beverage";

        public virtual Size Size { get; protected set; } = Size.Medium;

        public void SetSize(Size size)
        {
            Size = size;
        }

        public virtual string GetInfo => $"{Size} {Description} - {Cost():C2}";

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
                Size.Small => 2.00,
                Size.Medium => 3.00,
                Size.Large => 4.00,
                _ => 3.00
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
                Size.Small => 1.00,
                Size.Medium => 2.00,
                Size.Large => 3.00,
                _ => 2.00
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
                Size.Small => 1.00,
                Size.Medium => 2.00,
                Size.Large => 3.00,
                _ => 2.00
            };
        }
    }
}

