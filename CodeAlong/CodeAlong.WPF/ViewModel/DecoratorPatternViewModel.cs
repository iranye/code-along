namespace CodeAlong.WPF.ViewModel
{
    using WpfLibrary;

    public class DecoratorPatternViewModel : ViewModelBase
    {
        public DecoratorPatternViewModel()
        {
        }

        private string title = "Decorator Pattern";

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
