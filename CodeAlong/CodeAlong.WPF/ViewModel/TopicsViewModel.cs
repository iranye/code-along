namespace CodeAlong.WPF.ViewModel
{
    using CodeAlong.Domain.Data;
    using WpfLibrary;

    public class TopicsViewModel : ViewModelBase
    {
        private string filterString = String.Empty;
        private readonly IDataProvider dataProvider;

        public TopicsViewModel(IDataProvider dataProvider)
        {
            this.dataProvider = dataProvider;
        }

        public string FilterString
        {
            get { return filterString; }
            set
            {
                if (filterString.ToLower() != value.ToLower())
                {
                    filterString = value;
                    // ApplyFilter(filterString);
                }
            }
        }
    }
}
