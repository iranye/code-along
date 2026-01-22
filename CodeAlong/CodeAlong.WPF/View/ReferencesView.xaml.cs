namespace CodeAlong.WPF.View
{
    using CodeAlong.WPF.ViewModel;
    using System.Diagnostics;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;

    public partial class ReferencesView : UserControl
    {
        public ReferencesView()
        {
            InitializeComponent();
            Loaded += ReferencesView_Loaded;
        }

        private void ReferencesView_Loaded(object sender, RoutedEventArgs e)
        {
            Keyboard.Focus(SearchInput);
        }

        ReferencesViewModel? ViewModel => DataContext as ReferencesViewModel;

        void SearchInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (ViewModel != null)
                {
                    SearchInput.Text = SearchInput.Text.Trim();
                    if (!String.IsNullOrWhiteSpace(SearchInput.Text))
                    {
                        ViewModel.FilterString = SearchInput.Text;
                    }
                }
            }
        }

        void VolumeItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.S)
            {
                // ViewModel?.SaveSelectedVolume();
                e.Handled = true;
            }
        }

        private void ClearFilter_Click(object sender, RoutedEventArgs e)
        {
            Keyboard.Focus(SearchInput);
        }

        private void AddNewItem_Click(object sender, RoutedEventArgs e)
        {
            if (Title is not null)
            {
                Keyboard.Focus(Title);
                Title.SelectAll();
            }
        }

        private void ViewJson_Click(object sender, RoutedEventArgs e)
        {
            if (ViewModel != null)
            {
                var quotedFilePath = ViewModel.JsonFileFullPath;
                quotedFilePath = $"\"{quotedFilePath}\"";

                try
                {
                    Process.Start($"CMD.exe", "/C %NP% " + quotedFilePath);
                }
                catch (Exception ex)
                {
                    MessageBoxResult messageBoxResult = MessageBox.Show($"Failed to open JSON file: {quotedFilePath}", "Bad File path", MessageBoxButton.OK);
                    return;

                }
            }
        }
    }
}
