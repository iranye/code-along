namespace CodeAlong.WPF.ViewModel
{
    using WpfLibrary;

    public class MainViewModel : ViewModelBase
    {
        private ViewModelBase? selectedViewModel;

        public MainViewModel(ReferenceViewModel patternsViewModel, TopicsViewModel topicsViewModel)
        {
            PatternsViewModel = patternsViewModel;
            TopicsViewModel = topicsViewModel;
            SelectedViewModel = patternsViewModel;
            SelectViewModelCommand = new DelegateCommand(SelectViewModel);
        }

        public DelegateCommand SelectViewModelCommand { get; }

        public ReferenceViewModel PatternsViewModel { get; }
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
