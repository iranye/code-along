using CodeAlong.Domain.Data.Models;
using WpfLibrary;

namespace CodeAlong.WPF.ViewModel.Sections
{
    public class ViewModelWeatherConditions : ViewModelBase
    {
        private readonly CurrentConditionsDisplay currentConditionsDisplay;

        public ViewModelWeatherConditions(ISubject subject)
        {
            this.currentConditionsDisplay = new CurrentConditionsDisplay(subject);
        }

        private float temperature;
        public float Temperature
        {
            get => temperature;
            set
            {
                temperature = value;
                RaisePropertyChanged();
            }
        }
    }
}
