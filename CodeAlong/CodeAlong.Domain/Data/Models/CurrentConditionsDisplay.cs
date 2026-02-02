namespace CodeAlong.Domain.Data.Models
{
    public interface IObserver
    {
        void Update(float temp, float humidity, float pressure);
    }

    public interface IDisplay
    {
        // void Display();
        string Display { get; }
    }

    public class CurrentConditionsDisplay : IObserver, IDisplay
    {
        private float temperature;
        private float humidity;
        private readonly ISubject weatherData;

        public CurrentConditionsDisplay(ISubject weatherData)
        {
            this.weatherData = weatherData;
            this.weatherData.Attach(this);
        }

        public void Update(float temp, float humidity, float pressure)
        {
            this.temperature = temp;
            this.humidity = humidity;
            display = $"Current conditions: {temperature}°C and {humidity}% humidity";
        }

        private string display = string.Empty;
        public string Display => display;
    }
}
