namespace CodeAlong.WPF.ViewModel.Sections
{
    using CodeAlong.Domain.Data.Models;
    using WpfLibrary;

    public class DecoratorViewModel : ViewModelBase
    {
        public DecoratorViewModel()
        {
            CoffeeOrder = new CoffeeOrder();
            ClearOrderCommand = new DelegateCommand(ClearOrder);

            AddCommand = new DelegateCommand(AddBeverage);

            // populate beverage types
            BeverageTypes = new System.Collections.Generic.List<System.Collections.Generic.KeyValuePair<string, System.Func<Beverage>>>
            {
                new System.Collections.Generic.KeyValuePair<string, System.Func<Beverage>>("Espresso", () => new Espresso()),
                new System.Collections.Generic.KeyValuePair<string, System.Func<Beverage>>("House Blend", () => new HouseBlend()),
                new System.Collections.Generic.KeyValuePair<string, System.Func<Beverage>>("Dark Roast", () => new DarkRoast()),
            };

            Sizes = new System.Collections.Generic.List<Size> { Size.Small, Size.Medium, Size.Large };
            SelectedSize = Size.Medium;
            SelectedBeverageType = BeverageTypes[0];
        }

        public DelegateCommand AddCommand { get; }

        public DelegateCommand DeleteCommand { get; }

        public DelegateCommand SaveCommand { get; set; }

        public DelegateCommand ClearOrderCommand { get; set; }

        public System.Collections.Generic.List<System.Collections.Generic.KeyValuePair<string, System.Func<Beverage>>> BeverageTypes { get; }

        private System.Collections.Generic.KeyValuePair<string, System.Func<Beverage>> selectedBeverageType;
        public System.Collections.Generic.KeyValuePair<string, System.Func<Beverage>> SelectedBeverageType
        {
            get => selectedBeverageType;
            set { selectedBeverageType = value; RaisePropertyChanged(); }
        }

        public System.Collections.Generic.List<Size> Sizes { get; }

        private Size selectedSize;
        public Size SelectedSize
        {
            get => selectedSize;
            set { selectedSize = value; RaisePropertyChanged(); }
        }

        public bool CondimentMocha { get; set; }

        public bool CondimentWhip { get; set; }

        public bool CondimentSoy { get; set; }

        private string title = "Decorator Pattern";

        public string? Title
        {
            get => title;
            set
            {
                title = value;
                RaisePropertyChanged();
            }
        }

        public CoffeeOrder CoffeeOrder { get; set; }


        private async void ClearOrder(object? parameter)
        {
            CoffeeOrder.Beverages.Clear();
            RaisePropertyChanged(nameof(CoffeeOrder));
        }

        private void AddBeverage(object? parameter)
        {
            // create base beverage
            var beverage = SelectedBeverageType.Value();
            beverage.SetSize(SelectedSize);

            // apply condiments as decorators
            if (CondimentMocha)
            {
                beverage = new Mocha(beverage);
            }
            if (CondimentWhip)
            {
                beverage = new Whip(beverage);
            }
            if (CondimentSoy)
            {
                beverage = new Soy(beverage);
            }

            CoffeeOrder.Beverages.Add(beverage);
            RaisePropertyChanged(nameof(CoffeeOrder));
        }
    }
}
