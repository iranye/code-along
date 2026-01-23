namespace CodeAlong.WPF.ViewModel.Sections
{
    using WpfLibrary;

    public class DecoratorViewModel : ViewModelBase
    {
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
