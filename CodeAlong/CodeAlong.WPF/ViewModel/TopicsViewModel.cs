namespace CodeAlong.WPF.ViewModel
{
    using CodeAlong.Domain.Data;
    using CodeAlong.Domain.Data.Models;
    using System.Collections.ObjectModel;
    using System.Windows;
    using WpfLibrary;

    public class TopicsViewModel : ViewModelBase
    {
        private string filterString = String.Empty;
        private readonly IDataProvider dataProvider;
        private ReferenceItemViewModel? selectedItem;

        public TopicsViewModel(IDataProvider dataProvider)
        {
            ClearFilterCommand = new DelegateCommand(ClearFilter);
            this.dataProvider = dataProvider;
        }

        public ObservableCollection<ReferenceItemViewModel> ItemViewModels { get; } = new();

        public ObservableCollection<ReferenceItemViewModel> ListViewItems { get; } = new();

        public ReferenceItemViewModel? SelectedItem
        {
            get => selectedItem;
            set
            {
                if (selectedItem != value)
                {
                    selectedItem = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged(nameof(IsItemSelected));
                    DeleteCommand.RaiseCanExecuteChanged();
                }
            }
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

        public string JsonFileFullPath => dataProvider.JsonFileFullPath;

        public override async Task LoadAsync()
        {
            if (ItemViewModels.Any())
            {
                return;
            }

            var result = await RefetchMedias();
            ToggleListViewItemsActive();
        }

        private async Task<int> RefetchMedias()
        {
            int ret = 0;
            try
            {
                var itemModels = await dataProvider.GetAllAsync();
                if (itemModels is not null)
                {
                    ItemViewModels.Clear();
                    foreach (var itemModel in itemModels)
                    {
                        ItemViewModels.Add(new ReferenceItemViewModel(itemModel));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show($"Error: {ex.Message}", "Failed to read data", System.Windows.MessageBoxButton.OK);
            }

            return ret;
        }

        public DelegateCommand AddCommand { get; }

        public DelegateCommand DeleteCommand { get; }

        public DelegateCommand SaveCommand { get; set; }

        public DelegateCommand ClearFilterCommand { get; set; }

        public bool IsItemSelected => SelectedItem is not null;

        private void Add(object? parameter)
        {
            var volume = new Reference { Title = "New" };
            var viewModel = new ReferenceItemViewModel(volume);
            ItemViewModels.Add(viewModel);
            ListViewItems.Add(viewModel);
            SelectedItem = viewModel;
        }

        private void Delete(object? parameter)
        {
            if (SelectedItem is not null)
            {
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    var toBeDeletedId = SelectedItem.Id;
                    ItemViewModels.Remove(SelectedItem);
                    ListViewItems.Remove(SelectedItem);
                    if (toBeDeletedId > 0)
                    {
                        // dataProvider.Delete(toBeDeletedId);
                    }
                    SelectedItem = null;
                }
            }
        }

        private bool CanDelete(object? parameter) => IsItemSelected;

        private async void ClearFilter(object? parameter)
        {
            if (SelectedItem is not null)
            {
                var param = parameter;
            }

            var result = await RefetchMedias();

            FilterString = String.Empty;
            RaisePropertyChanged("Medias");
        }

        private void ToggleListViewItemsActive(bool isActive = true)
        {
            ListViewItems.Clear();
            if (!isActive)
            {
                return;
            }
            else
            {
                foreach (var volume in ItemViewModels)
                {
                    ListViewItems.Add(volume);
                }
                ListViewItems.Sort((x, y) => x.Title.CompareTo(y.Title));
            }
        }

        // TODO: Disable if any validation errors
        private bool CanSave(object? parameter) => IsItemSelected;
    }
}
