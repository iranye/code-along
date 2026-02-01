namespace CodeAlong.WPF.ViewModel.Sections
{
    using WpfLibrary;

    public class ViewModelObserverPattern : ViewModelBase
    {
        public ViewModelObserverPattern()
        {
        }

        private string title = "Observer Pattern - SEE page 96/58";

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
