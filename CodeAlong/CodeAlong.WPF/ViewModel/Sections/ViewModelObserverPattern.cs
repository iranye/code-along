namespace CodeAlong.WPF.ViewModel.Sections
{
    using CodeAlong.WPF.Services;
    using WpfLibrary;

    public class ViewModelObserverPattern : ViewModelBase
    {
        private readonly WeatherData weatherData;
        private readonly ViewModelWeatherConditions weatherConditions;

        public ViewModelObserverPattern()
        {
            weatherData = new WeatherData();
            weatherConditions = new ViewModelWeatherConditions(weatherData);

            UpdateMeasurementsCommand = new DelegateCommand(UpdateMeasurements);
        }

        public DelegateCommand UpdateMeasurementsCommand { get; }

        public ViewModelWeatherConditions WeatherConditions => weatherConditions;

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
