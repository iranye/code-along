namespace CodeAlong.WPF.ViewModel
{
    using CodeAlong.Domain.Data;
    using WpfLibrary;

    public class PatternsViewModel : ViewModelBase
    {
        private readonly IDataProvider dataProvider;

        public PatternsViewModel(IDataProvider dataProvider)
        {
            this.dataProvider = dataProvider;
        }

    }
}
