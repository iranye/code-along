namespace CodeAlong.WPF.ViewModel.Sections
{
    using WpfLibrary;

    public class FactoryPatternViewModel : ViewModelBase
    {
        public FactoryPatternViewModel()
        {
        }

        private string title = "Factory Pattern";

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
