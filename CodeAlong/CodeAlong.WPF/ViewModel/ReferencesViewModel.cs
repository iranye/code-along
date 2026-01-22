namespace CodeAlong.WPF.ViewModel
{
    using CodeAlong.Domain.Data;
    using CodeAlong.Domain.Data.Models;
    using System;
    using System.Collections.ObjectModel;
    using System.Windows;
    using WpfLibrary;

    public class ReferencesViewModel : ViewModelBase
    {
        private readonly IDataProvider dataProvider;
        private ReferenceItemViewModel? selectedItem;
        private ViewModelBase? selectedViewModel;

        public ReferencesViewModel(IDataProvider dataProvider, DecoratorPatternViewModel decoratorViewModel, FactoryPatternViewModel factoryViewModel)
        {
            this.dataProvider = dataProvider;
            SelectSectionCommand = new DelegateCommand(SelectViewModel);

            DecoratorPattern = decoratorViewModel;
            FactoryPattern = factoryViewModel;
            SelectedViewModel = decoratorViewModel;
            AddCommand = new DelegateCommand(Add);
            DeleteCommand = new DelegateCommand(Delete, CanDelete);
            SaveCommand = new DelegateCommand(Save);
        }

        public ViewModelBase? SelectedViewModel
        {
            get => selectedViewModel;
            set
            {
                selectedViewModel = value;
                RaisePropertyChanged();
            }
        }

        public DelegateCommand SelectSectionCommand { get; }

        public DelegateCommand AddCommand { get; }

        public DelegateCommand DeleteCommand { get; }

        public DelegateCommand SaveCommand { get; set; }

        public DecoratorPatternViewModel DecoratorPattern { get; }

        public FactoryPatternViewModel FactoryPattern { get; }

        private async void SelectViewModel(object? parameter)
        {
            SelectedViewModel = parameter as ViewModelBase;
            await LoadAsync();
        }

        public ObservableCollection<DecoratorPatternViewModel> SectionViewModels { get; } = new();

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

        private void Add(object? parameter)
        {
            var reference = new Reference { Title = "New" };
            var viewModel = new ReferenceItemViewModel(reference);
            ItemViewModels.Add(viewModel);
            ListViewItems.Add(viewModel);
            SelectedItem = viewModel;
        }

        internal bool BeQuiet { get; set; } = false;
        private void Save(object? parameter)
        {
            if (SelectedItem is null)
            {
                MessageBox.Show("Nothing Selected!");
                return;
            }
            if (SelectedItem.IsPlaceholder())
            {
                MessageBox.Show("Cannot save a Placeholder Item!");
                return;
            }

            SaveItem(SelectedItem);
            if (!BeQuiet)
            {
                MessageBox.Show("Saved!");
            }
        }

        private void SaveItem(ReferenceItemViewModel itemViewModel)
        {
            var item = itemViewModel.ReferenceModel;
            dataProvider.Save(item);

            if (item is not null)
            {
                SelectedItem.Id = item.Id;
            }
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
                        dataProvider.Delete(toBeDeletedId);
                    }
                    SelectedItem = null;
                }
            }
        }

        private bool CanDelete(object? parameter) => IsItemSelected;

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
