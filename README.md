# code-along

## Decorator pattern — Coffee example

This project contains a small, concrete implementation of the Decorator design pattern (the coffee shop example from *Head First Design Patterns*).

Overview
- The code demonstrates how to add responsibilities to objects at runtime by wrapping them with decorator objects.
- Core abstraction: `Beverage` (component) and `CondimentDecorator` (base decorator).
- Concrete components: `Espresso`, `HouseBlend`, `DarkRoast`.
- Concrete decorators (condiments): `Mocha`, `Whip`, `Soy`.

Key files
- `HeadFirstDesignPatterns/Decorator/Beverage.cs` — defines the abstract `Beverage`, the `Size` enum and the concrete beverages.
- `HeadFirstDesignPatterns/Decorator/CondimentDecorator.cs` — defines `CondimentDecorator` and the concrete condiment classes that wrap a `Beverage`.
- `HeadFirstDesignPatterns/Program.cs` — example usage that composes beverages with decorators and prints description and cost.

Size support
- A `Size` enum (`Small`, `Medium`, `Large`) was added to `Beverage.cs`.
- Each `Beverage` has a `Size` property (default `Medium`). The property currently has a `protected set`, so size is intended to be controlled by subclasses or internal initialization.
- Price rules in the sample implementation:
  - `Espresso`: Small = $1.59, Medium = $1.99, Large = $2.20
  - `House Blend`: Small = $0.69, Medium = $0.89, Large = $1.19
  - `Dark Roast`: Small = $0.69, Medium = $0.89, Large = $1.19

How it works (brief)
- Each `CondimentDecorator` holds a reference to a `Beverage` instance.
- Decorators extend behavior by overriding `GetDescription()` and `Cost()` and delegating to the wrapped `Beverage`.
- Multiple decorators can be stacked to build complex combinations at runtime.

Run
- Requires .NET 10 SDK.
- From repository root:

  `dotnet run --project HeadFirstDesignPatterns/HeadFirstDesignPatterns.csproj`

Example output
- When you run the sample `Program`, it prints lines similar to:

  `Espresso $1.99`
  `Dark Roast, Mocha, Mocha, Whip $1.39`
  `House Blend, Soy, Mocha, Whip $1.34`

Notes
- Prices and descriptions are computed at runtime by the decorated objects.
- The example keeps implementations simple and focused on demonstrating the structure and behavior of the Decorator pattern.
