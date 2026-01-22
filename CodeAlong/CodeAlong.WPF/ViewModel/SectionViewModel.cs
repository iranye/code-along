namespace CodeAlong.WPF.ViewModel
{
    using WpfLibrary;

    public class SectionViewModel : ViewModelBase
    {
        public SectionViewModel()
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
