using CodeAlong.WPF.Services;
using WpfLibrary;

namespace CodeAlong.WPF.ViewModel.Sections
{
    public interface IDisplay
    {
        // void Display();
        string Display { get; }
    }

    public class ViewModelWeatherConditions : ViewModelBase, IObserver, IDisplay
    {
        private float temperature;
        private float humidity;
        private readonly ISubject weatherData;
        private readonly string displayName;

        public ViewModelWeatherConditions(ISubject subject, string name = "Weather Display")
        {
            this.weatherData = subject;
            this.displayName = name;
            this.weatherData.Attach(this);
            IsAttached = true;
        }

        public string DisplayName => displayName;

        public string DisplayInfo
        {
            get
            {
                var attachedStatus = IsAttached ? "Attached" : "Not Attached";
                return $"{displayName} - {attachedStatus}";                
            }
        }

        public void Update(float temp, float humidity, float pressure)
        {
            this.temperature = temp;
            this.humidity = humidity;
            Display = $"Current conditions: {temperature}°C and {humidity}% humidity";
        }

        private string display = string.Empty;
        public string Display
        {
            get => display;
            set
            {
                display = value;
                RaisePropertyChanged();
            }
        }

        private bool isAttached;
        public bool IsAttached
        {
            get => isAttached;
            set
            {
                isAttached = value;
                RaisePropertyChanged();
                RaisePropertyChanged("DisplayInfo");
            }
        }
    }
}
