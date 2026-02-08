namespace CodeAlong.WPF.ViewModel.Sections
{
    using WpfLibrary;

    public class ViewModelFactoryPattern : ViewModelBase
    {
        public ViewModelFactoryPattern()
        {
        }

        private string title = "Factory Pattern - SEE page 160/122";

        public string Title
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
