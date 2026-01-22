namespace CodeAlong.WPF.ViewModel
{
    using WpfLibrary;

    public class MainViewModel : ViewModelBase
    {
        private ViewModelBase? selectedViewModel;

        public MainViewModel(ReferencesViewModel referencesViewModel, TopicsViewModel topicsViewModel)
        {
            ReferencesViewModel = referencesViewModel;
            TopicsViewModel = topicsViewModel;
            SelectedViewModel = referencesViewModel;
            SelectViewModelCommand = new DelegateCommand(SelectViewModel);
        }

        public DelegateCommand SelectViewModelCommand { get; }

        public ReferencesViewModel ReferencesViewModel { get; }
        public TopicsViewModel TopicsViewModel { get; }

        public ViewModelBase? SelectedViewModel
        {
            get => selectedViewModel;
            set
            {
                selectedViewModel = value;
                RaisePropertyChanged();
            }
        }

        public async override Task LoadAsync()
        {
            if (SelectedViewModel is not null)
            {
                await SelectedViewModel.LoadAsync();
            }
        }

        private async void SelectViewModel(object? parameter)
        {
            SelectedViewModel = parameter as ViewModelBase;
            await LoadAsync();
        }
    }
}
