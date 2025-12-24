using HeadFirstDesignPatterns.Decorator;

internal class Program
{
    private static void Main(string[] args)
    {
        Beverage espresso = new Espresso();

        Console.WriteLine(GetCoffeeInfo(espresso));

        Beverage darkRoast = new DarkRoast();
        darkRoast = new Mocha(darkRoast);
        darkRoast = new Mocha(darkRoast);
        darkRoast = new Whip(darkRoast);
        Console.WriteLine(GetCoffeeInfo(darkRoast));

        Beverage houseBlend = new HouseBlend();
        houseBlend = new Soy(houseBlend);
        houseBlend = new Mocha(houseBlend);
        houseBlend = new Whip(houseBlend);
        Console.WriteLine(GetCoffeeInfo(houseBlend));
    }

    public static string GetCoffeeInfo(Beverage beverage)
    {
        return $"{beverage.GetDescription()} ${beverage.Cost():0.00}";
    }
}