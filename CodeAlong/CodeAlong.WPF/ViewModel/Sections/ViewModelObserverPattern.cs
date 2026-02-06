namespace CodeAlong.WPF.ViewModel.Sections
{
    using CodeAlong.WPF.Services;
    using System.Collections.ObjectModel;
    using WpfLibrary;

    public class ViewModelObserverPattern : ViewModelBase
    {
        private readonly WeatherData weatherData;
        private int observerCounter = 1;

        public ViewModelObserverPattern()
        {
            weatherData = new WeatherData();
            
            // Initialize with one default observer
            var defaultObserver = new ViewModelWeatherConditions(weatherData, "Weather Display 1");
            Observers.Add(defaultObserver);

            UpdateMeasurementsCommand = new DelegateCommand(UpdateMeasurements);
            AddObserverCommand = new DelegateCommand(AddObserver, CanAddObserver);
            ToggleObserverCommand = new DelegateCommand(ToggleObserverAttached, CanToggleObserverAttached);
        }

        public DelegateCommand UpdateMeasurementsCommand { get; }
        public DelegateCommand AddObserverCommand { get; }
        public DelegateCommand ToggleObserverCommand { get; }

        private ObservableCollection<ViewModelWeatherConditions> observers = new ObservableCollection<ViewModelWeatherConditions>();
        public ObservableCollection<ViewModelWeatherConditions> Observers
        {
            get => observers;
            set
            {
                observers = value;
                RaisePropertyChanged();
            }
        }

        private ViewModelWeatherConditions? selectedObserver;
        public ViewModelWeatherConditions? SelectedObserver
        {
            get => selectedObserver;
            set
            {
                selectedObserver = value;
                RaisePropertyChanged();
                ToggleObserverCommand.RaiseCanExecuteChanged();
            }
        }

        private string newObserverName = string.Empty;
        public string NewObserverName
        {
            get => newObserverName;
            set
            {
                newObserverName = value;
                RaisePropertyChanged();
                AddObserverCommand.RaiseCanExecuteChanged();
            }
        }

        public ViewModelWeatherConditions WeatherConditions => throw new NotSupportedException("Use Observers collection instead");

        private float temperature = 25.0f;
        public float Temperature
        {
            get => temperature;
            set
            {
                temperature = value;
                RaisePropertyChanged();
            }
        }

        private float humidity = 65.0f;
        public float Humidity
        {
            get => humidity;
            set
            {
                humidity = value;
                RaisePropertyChanged();
            }
        }

        private float pressure = 30.4f;
        public float Pressure
        {
            get => pressure;
            set
            {
                pressure = value;
                RaisePropertyChanged();
            }
        }

        private void UpdateMeasurements(object? parameter)
        {
            weatherData.SetMeasurements(Temperature, Humidity, Pressure);
        }

        private void AddObserver(object? parameter)
        {
            observerCounter++;
            string name = string.IsNullOrWhiteSpace(NewObserverName) 
                ? $"Weather Display {observerCounter}" 
                : NewObserverName;

            var observer = Observers.FirstOrDefault(x => x.DisplayName == name);
            if (observer == null)
            {
                var newObserver = new ViewModelWeatherConditions(weatherData, name);
                Observers.Add(newObserver);
                NewObserverName = string.Empty;
            }
            else
            {
                weatherData.Attach(observer);
            }
                NewObserverName = string.Empty;
        }

        private bool CanAddObserver(object? parameter)
        {
            return true; // Can always add observers
        }

        private void ToggleObserverAttached(object? parameter)
        {
            if (SelectedObserver != null)
            {
                if (SelectedObserver.IsAttached)
                {
                    weatherData.Detach(SelectedObserver);
                    SelectedObserver.IsAttached = false;
                }
                else
                {
                    weatherData.Attach(SelectedObserver);
                    SelectedObserver.IsAttached = true;
                }
                SelectedObserver = null;
            }
        }

        private bool CanToggleObserverAttached(object? parameter)
        {
            return SelectedObserver != null;
        }

        private string title = "Observer Pattern - SEE page 96/58";

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
