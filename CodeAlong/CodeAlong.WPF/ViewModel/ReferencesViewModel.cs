namespace CodeAlong.WPF.ViewModel
{
    using CodeAlong.Domain.Data;
    using System.Collections.ObjectModel;
    using System.Windows;
    using WpfLibrary;

    public class ReferencesViewModel : ViewModelBase
    {
        private readonly IDataProvider dataProvider;
        private ReferenceItemViewModel? selectedItem;

        public ReferencesViewModel(IDataProvider dataProvider, SectionViewModel sectionViewModel)
        {
            this.dataProvider = dataProvider;
            SelectSectionCommand = new DelegateCommand(SelectSection);
            SelectedSection = sectionViewModel;
        }

        public DelegateCommand SelectSectionCommand { get; }

        private SectionViewModel? selectedSection;

        public SectionViewModel? SelectedSection
        {
            get => selectedSection;
            set
            {
                selectedSection = value;
                RaisePropertyChanged();
            }
        }

        private void SelectSection(object? parameter)
        {
            var selectedSection = (SectionViewModel)parameter;
            if (selectedSection != null)
            {
                SelectedSection = selectedSection;
            }
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
                    //DeleteCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public override async Task LoadAsync()
        {
            if (ItemViewModels.Any())
            {
                return;
            }

            var result = await RefetchItems();
            ToggleListViewItemsActive();
        }

        private async Task<int> RefetchItems()
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

        public bool IsItemSelected => SelectedItem is not null;

        private string _filterString = String.Empty;

        public string FilterString
        {
            get { return _filterString; }
            set
            {
                _filterString = value;
                ApplyFilter(FilterString);
                RaisePropertyChanged("ListViewItems");
                RaisePropertyChanged();
            }
        }

        internal void ApplyFilter(string? filter = null)
        {
            if (!String.IsNullOrWhiteSpace(filter))
            {
                // Clear the current "presentation" list to get ready to add only those that match the filter
                ToggleListViewItemsActive(false);
            }
            else
            {
                // For empty filter, present all items
                ToggleListViewItemsActive();
                return;
            }

            foreach (var reference in ItemViewModels)
            {
                if (!String.IsNullOrWhiteSpace(filter))
                {
                    if (reference.HasFilterString(FilterString.ToLower()))
                    {
                        ListViewItems.Add(reference);
                    }
                }
                else
                {
                    if (!String.IsNullOrWhiteSpace(filter) && reference.HasFilterString(FilterString.ToLower()))
                    {
                        ListViewItems.Add(reference);
                    }
                }
            }
            if (ListViewItems.Count > 0)
            {
                ListViewItems.Sort((x, y) => x.Title.CompareTo(y.Title));
                SelectedItem = ListViewItems[0];
            }
        }

        public string JsonFileFullPath => dataProvider.JsonFileFullPath;

        internal void ApplyFilter(string? filter = null, int daysFilter = 0)
        {
            if (!String.IsNullOrWhiteSpace(filter) || daysFilter > 0)
            {
                ToggleListViewItemsActive(false);
            }
            else
            {
                ToggleListViewItemsActive();
                return;
            }
            if (ListViewItems.Count > 0)
            {
                ListViewItems.Sort((x, y) => x.Title.CompareTo(y.Title));
                SelectedItem = ListViewItems[0];
            }
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
                foreach (var reference in ItemViewModels)
                {
                    ListViewItems.Add(reference);
                }
                ListViewItems.Sort((x, y) => x.Title.CompareTo(y.Title));
            }
        }
    }
}
