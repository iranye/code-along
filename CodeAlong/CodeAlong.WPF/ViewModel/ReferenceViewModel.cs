namespace CodeAlong.WPF.ViewModel
{
    using CodeAlong.Domain.Data;
    using WpfLibrary;

    public class ReferenceViewModel : ViewModelBase
    {
        private readonly IDataProvider dataProvider;

        public ReferenceViewModel(IDataProvider dataProvider)
        {
            this.dataProvider = dataProvider;
        }

    }
}
