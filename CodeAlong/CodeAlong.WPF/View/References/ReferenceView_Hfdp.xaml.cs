namespace CodeAlong.WPF.View.References
{
    using CodeAlong.WPF.ViewModel.References;
    using System.Diagnostics;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;

    public partial class ReferenceView_Hfdp : UserControl
    {
        public ViewModelHfdp? ViewModel
        {
            get => DataContext as ViewModelHfdp;
            set => DataContext = value;
        }

        public ReferenceView_Hfdp()
        {
            InitializeComponent();
        }

        void MainItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.S)
            {
                // ViewModel?.SaveSelectedVolume();
                e.Handled = true;
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

        private void AddNewItem_Click(object sender, RoutedEventArgs e)
        {
            if (Title is not null)
            {
                Keyboard.Focus(Title);
                Title.SelectAll();
            }
        }
    }
}
