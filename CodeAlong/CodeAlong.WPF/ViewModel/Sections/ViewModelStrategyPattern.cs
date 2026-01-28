namespace CodeAlong.WPF.ViewModel.Sections
{
    using WpfLibrary;

    public class ViewModelStrategyPattern : ViewModelBase
    {
        private string title = "Strategy Pattern - SEE page 16/54";

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
