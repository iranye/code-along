namespace CodeAlong.WPF.ViewModel.Sections
{
    using WpfLibrary;

    public class ViewModelFactoryPattern : ViewModelBase
    {
        public ViewModelFactoryPattern()
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
