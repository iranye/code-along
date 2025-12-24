using HeadFirstDesignPatterns.Decorator;

internal class Program
{
    private static void Main(string[] args)
    {
        Beverage espresso = new Espresso();
        espresso.SetSize(Size.Small);

        Console.WriteLine(GetCoffeeInfo(espresso));

        Beverage darkRoast = new DarkRoast();
        darkRoast.SetSize(Size.Large);
        darkRoast = new Mocha(darkRoast);
        darkRoast = new Mocha(darkRoast);
        darkRoast = new Whip(darkRoast);
        Console.WriteLine(GetCoffeeInfo(darkRoast));

        Beverage houseBlend = new HouseBlend();
        houseBlend.SetSize(Size.Medium);
        houseBlend = new Soy(houseBlend);
        houseBlend = new Mocha(houseBlend);
        houseBlend = new Whip(houseBlend);
        Console.WriteLine(GetCoffeeInfo(houseBlend));
    }

    public static string GetCoffeeInfo(Beverage beverage)
    {
        return $"{beverage.Size} {beverage.GetDescription()} ${beverage.Cost():0.00}";
    }
}