namespace CodeAlong.WPF.ViewModel.Sections
{
    using CodeAlong.Domain.Data.Models;
    using WpfLibrary;

    public class ViewModelStrategyPattern : ViewModelBase
    {
        public ViewModelStrategyPattern()
        {
            DuckOrder = new DuckOrder();
            ClearOrderCommand = new DelegateCommand(ClearOrder);
            AddCommand = new DelegateCommand(AddDuck);
            RemoveCommand = new DelegateCommand(RemoveDuck, CanRemoveDuck);
            UpdateBehaviorsCommand = new DelegateCommand(UpdateBehaviors, CanUpdateBehaviors);

            // populate duck types
            DuckTypes = new List<KeyValuePair<string, Func<Duck>>>
            {
                new KeyValuePair<string, Func<Duck>>("Mallard Duck", () => new MallardDuck()),
                new KeyValuePair<string, Func<Duck>>("Model Duck", () => new ModelDuck()),
            };

            SelectedDuckType = DuckTypes[0];
            
            // Default behaviors
            FlyWithWings = true;
            QuackDefault = true;
        }

        public DelegateCommand AddCommand { get; }

        public DelegateCommand ClearOrderCommand { get; set; }

        public DelegateCommand RemoveCommand { get; set; }

        public DelegateCommand UpdateBehaviorsCommand { get; set; }

        public List<KeyValuePair<string, Func<Duck>>> DuckTypes { get; }

        private KeyValuePair<string, Func<Duck>> selectedDuckType;
        public KeyValuePair<string, Func<Duck>> SelectedDuckType
        {
            get => selectedDuckType;
            set
            {
                selectedDuckType = value;
                RaisePropertyChanged();
            }
        }

        // Fly Behavior Radio Buttons
        private bool flyWithWings;
        public bool FlyWithWings
        {
            get => flyWithWings;
            set
            {
                flyWithWings = value;
                RaisePropertyChanged();
            }
        }

        private bool flyNoWay;
        public bool FlyNoWay
        {
            get => flyNoWay;
            set
            {
                flyNoWay = value;
                RaisePropertyChanged();
            }
        }

        private bool flyRocketPowered;
        public bool FlyRocketPowered
        {
            get => flyRocketPowered;
            set
            {
                flyRocketPowered = value;
                RaisePropertyChanged();
            }
        }

        // Quack Behavior Radio Buttons
        private bool quackDefault;
        public bool QuackDefault
        {
            get => quackDefault;
            set
            {
                quackDefault = value;
                RaisePropertyChanged();
            }
        }

        private bool quackMute;
        public bool QuackMute
        {
            get => quackMute;
            set
            {
                quackMute = value;
                RaisePropertyChanged();
            }
        }

        private bool quackSqueak;
        public bool QuackSqueak
        {
            get => quackSqueak;
            set
            {
                quackSqueak = value;
                RaisePropertyChanged();
            }
        }

        public DuckOrder DuckOrder { get; set; }

        public int DuckCount => DuckOrder.Ducks.Count;

        private DuckOrderItem? selectedDuck;
        public DuckOrderItem? SelectedDuck
        {
            get => selectedDuck;
            set
            {
                selectedDuck = value;
                RaisePropertyChanged();
                RaisePropertyChanged(nameof(EditDuckVisibility));
                RemoveCommand?.RaiseCanExecuteChanged();
                UpdateBehaviorsCommand?.RaiseCanExecuteChanged();
                
                // Initialize edit radio buttons when duck is selected
                if (selectedDuck != null)
                {
                    EditFlyWithWings = selectedDuck.FlyBehavior is FlyWithWings;
                    EditFlyNoWay = selectedDuck.FlyBehavior is FlyNoWay;
                    EditFlyRocketPowered = selectedDuck.FlyBehavior is FlyRocketPowered;
                    
                    EditQuackDefault = selectedDuck.QuackBehavior is QuackDefault;
                    EditQuackMute = selectedDuck.QuackBehavior is QuackMute;
                    EditQuackSqueak = selectedDuck.QuackBehavior is QuackSqueak;
                }
            }
        }

        private void AddDuck(object? parameter)
        {
            // Determine fly behavior
            IFlyBehavior flyBehavior = FlyWithWings ? new FlyWithWings() :
                                       FlyNoWay ? new FlyNoWay() :
                                       new FlyRocketPowered();

            // Determine quack behavior
            IQuackBehavior quackBehavior = QuackDefault ? new QuackDefault() :
                                           QuackMute ? new QuackMute() :
                                           new QuackSqueak();

            var duckOrderItem = new DuckOrderItem(
                SelectedDuckType.Key,
                flyBehavior,
                quackBehavior
            );

            DuckOrder.Ducks.Add(duckOrderItem);
            RaisePropertyChanged(nameof(DuckOrder));
            RaisePropertyChanged(nameof(DuckCount));
        }

        private void ClearOrder(object? parameter)
        {
            DuckOrder.Ducks.Clear();
            SelectedDuck = null;
            RaisePropertyChanged(nameof(DuckOrder));
            RaisePropertyChanged(nameof(DuckCount));
        }

        private void RemoveDuck(object? parameter)
        {
            if (SelectedDuck != null)
            {
                DuckOrder.Ducks.Remove(SelectedDuck);
                SelectedDuck = null;
                RaisePropertyChanged(nameof(DuckOrder));
                RaisePropertyChanged(nameof(DuckCount));
            }
        }

        private bool CanRemoveDuck(object? parameter)
        {
            return SelectedDuck != null;
        }

        private string title = "Strategy Pattern - SEE page 16/54";

        public string Title
        {
            get => title;
            set
            {
                title = value;
                RaisePropertyChanged();
            }
        }

        // Edit Duck Visibility
        public System.Windows.Visibility EditDuckVisibility => 
            SelectedDuck != null ? System.Windows.Visibility.Visible : System.Windows.Visibility.Collapsed;

        // Edit Fly Behavior Radio Buttons
        private bool editFlyWithWings;
        public bool EditFlyWithWings
        {
            get => editFlyWithWings;
            set
            {
                editFlyWithWings = value;
                RaisePropertyChanged();
            }
        }

        private bool editFlyNoWay;
        public bool EditFlyNoWay
        {
            get => editFlyNoWay;
            set
            {
                editFlyNoWay = value;
                RaisePropertyChanged();
            }
        }

        private bool editFlyRocketPowered;
        public bool EditFlyRocketPowered
        {
            get => editFlyRocketPowered;
            set
            {
                editFlyRocketPowered = value;
                RaisePropertyChanged();
            }
        }

        // Edit Quack Behavior Radio Buttons
        private bool editQuackDefault;
        public bool EditQuackDefault
        {
            get => editQuackDefault;
            set
            {
                editQuackDefault = value;
                RaisePropertyChanged();
            }
        }

        private bool editQuackMute;
        public bool EditQuackMute
        {
            get => editQuackMute;
            set
            {
                editQuackMute = value;
                RaisePropertyChanged();
            }
        }

        private bool editQuackSqueak;
        public bool EditQuackSqueak
        {
            get => editQuackSqueak;
            set
            {
                editQuackSqueak = value;
                RaisePropertyChanged();
            }
        }

        private void UpdateBehaviors(object? parameter)
        {
            if (SelectedDuck != null)
            {
                // TODO: Add logic to determine whether a behavior is actually changing
                // Determine new fly behavior
                IFlyBehavior newFlyBehavior = EditFlyWithWings ? new FlyWithWings() :
                                              EditFlyNoWay ? new FlyNoWay() :
                                              new FlyRocketPowered();

                // Determine new quack behavior
                IQuackBehavior newQuackBehavior = EditQuackDefault ? new QuackDefault() :
                                                  EditQuackMute ? new QuackMute() :
                                                  new QuackSqueak();

                // Update the behaviors
                SelectedDuck.FlyBehavior = newFlyBehavior;
                SelectedDuck.QuackBehavior = newQuackBehavior;
                
                // Notify property changes to update the display
                SelectedDuck.OnPropertyChanged(nameof(SelectedDuck.FlyInfo));
                SelectedDuck.OnPropertyChanged(nameof(SelectedDuck.QuackInfo));
            }
        }

        private bool CanUpdateBehaviors(object? parameter)
        {
            return SelectedDuck != null;
        }
    }
}
