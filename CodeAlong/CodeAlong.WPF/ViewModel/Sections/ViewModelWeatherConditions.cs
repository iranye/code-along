using CodeAlong.WPF.Services;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CodeAlong.WPF.ViewModel.Sections
{
    public interface IDisplay
    {
        // void Display();
        string Display { get; }
    }

    public class ViewModelWeatherConditions : IObserver, INotifyPropertyChanged, IDisplay
    {
        private float temperature;
        private float humidity;
        private readonly ISubject weatherData;

        public ViewModelWeatherConditions(ISubject subject)
        {
            this.weatherData = weatherData;
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

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void RaisePropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
