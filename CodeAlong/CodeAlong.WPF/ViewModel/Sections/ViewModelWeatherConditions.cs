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

        public ViewModelWeatherConditions(ISubject subject)
        {
            this.weatherData = subject;
            this.weatherData.Attach(this);
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
    }
}
