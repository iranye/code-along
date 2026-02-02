namespace CodeAlong.WPF.Services
{
    public interface IObserver
    {
        void Update(float temp, float humidity, float pressure);
    }

    public interface ISubject
    {
        void Attach(IObserver observer);
        void Detach(IObserver observer);
        void Notify();
    }

    public class WeatherData : ISubject
    {
        private List<IObserver> observers = new List<IObserver>();
        private float temperature;
        private float humidity;
        private float pressure;

        public void Attach(IObserver observer)
        {
            observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (var observer in observers)
            {
                observer.Update(temperature, humidity, pressure);
            }
        }

        public void SetMeasurements(float temperature, float humidity, float pressure)
        {
            this.temperature = temperature;
            this.humidity = humidity;
            this.pressure = pressure;
            Notify();
        }
    }
}
