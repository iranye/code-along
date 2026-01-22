namespace CodeAlong.WPF.ViewModel
{
    using WpfLibrary;

    public class FactoryPatternViewModel : ViewModelBase
    {
        public FactoryPatternViewModel()
        {
        }

        private string title = "Factor Pattern";

        public string? Title
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
