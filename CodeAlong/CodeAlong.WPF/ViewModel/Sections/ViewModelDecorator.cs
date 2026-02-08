namespace CodeAlong.WPF.ViewModel.Sections
{
    using CodeAlong.Domain.Data.Models;
    using WpfLibrary;

    public class ViewModelDecorator : ViewModelBase
    {
        public ViewModelDecorator()
        {
            CoffeeOrder = new CoffeeOrder();
            ClearOrderCommand = new DelegateCommand(ClearOrder);
            AddCommand = new DelegateCommand(AddBeverage);
            RemoveCommand = new DelegateCommand(RemoveBeverage, CanRemoveBeverage);

            // populate beverage types
            BeverageTypes = new List<KeyValuePair<string, Func<Beverage>>>
            {
                new KeyValuePair<string, Func<Beverage>>("Espresso", () => new Espresso()),
                new KeyValuePair<string, Func<Beverage>>("House Blend", () => new HouseBlend()),
                new KeyValuePair<string, Func<Beverage>>("Dark Roast", () => new DarkRoast()),
                new KeyValuePair<string, Func<Beverage>>("Latte", () => new Latte()),
            };

            Sizes = new List<Size> { Size.Small, Size.Medium, Size.Large };
            SelectedSize = Size.Medium;
            SelectedBeverageType = BeverageTypes[0];
        }

        public DelegateCommand AddCommand { get; }

        public DelegateCommand ClearOrderCommand { get; set; }

        public DelegateCommand RemoveCommand { get; set; }

        public List<KeyValuePair<string, Func<Beverage>>> BeverageTypes { get; }

        private KeyValuePair<string, Func<Beverage>> selectedBeverageType;
        public KeyValuePair<string, Func<Beverage>> SelectedBeverageType
        {
            get => selectedBeverageType;
            set
            {
                selectedBeverageType = value;
                RaisePropertyChanged();
            }
        }

        public List<Size> Sizes { get; }

        private Size selectedSize;
        public Size SelectedSize
        {
            get => selectedSize;
            set
            {
                selectedSize = value;
                RaisePropertyChanged();
            }
        }

        public bool CondimentMocha { get; set; }

        public bool CondimentWhip { get; set; }

        public bool CondimentSoy { get; set; }

        public CoffeeOrder CoffeeOrder { get; set; }

        public double OrderTotal => CoffeeOrder.Beverages.Sum(b => b.Cost());

        private Beverage? selectedBeverage;
        public Beverage? SelectedBeverage
        {
            get => selectedBeverage;
            set
            {
                selectedBeverage = value;
                RaisePropertyChanged();
                RemoveCommand?.RaiseCanExecuteChanged();
            }
        }

        private void AddBeverage(object? parameter)
        {
            // create base beverage
            var beverage = SelectedBeverageType.Value();

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

            beverage.SetSize(SelectedSize);
            CoffeeOrder.Beverages.Add(beverage);
            RaisePropertyChanged(nameof(CoffeeOrder));
            RaisePropertyChanged(nameof(OrderTotal));
        }

        private async void ClearOrder(object? parameter)
        {
            CoffeeOrder.Beverages.Clear();
            SelectedBeverage = null;
            RaisePropertyChanged(nameof(CoffeeOrder));
            RaisePropertyChanged(nameof(OrderTotal));
        }

        private void RemoveBeverage(object? parameter)
        {
            if (SelectedBeverage != null)
            {
                CoffeeOrder.Beverages.Remove(SelectedBeverage);
                SelectedBeverage = null;
                RaisePropertyChanged(nameof(CoffeeOrder));
                RaisePropertyChanged(nameof(OrderTotal));
            }
        }

        private bool CanRemoveBeverage(object? parameter)
        {
            return SelectedBeverage != null;
        }

        private string title = "Decorator Pattern - SEE page 135/97";

        public string Title
        {
            get => title;
            set
            {
                title = value;
                RaisePropertyChanged();
            }
        }
    }
}
