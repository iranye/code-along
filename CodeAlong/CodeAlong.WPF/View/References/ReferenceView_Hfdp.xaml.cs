namespace CodeAlong.WPF.View.References
{
    using CodeAlong.WPF.ViewModel.References;
    using System.Diagnostics;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;

    public partial class ReferenceView_Hfdp : UserControl
    {
        private Style styleSelected;
        private Style styleUnSelected;

        public ReferenceView_Hfdp()
        {
            InitializeComponent();
            styleSelected ??= (Style)FindResource("ButtonSelected");
            styleUnSelected ??= (Style)FindResource("ButtonUnSelected");
            Loaded += ReferenceView_Hfdp_Loaded;
        }

        private void ReferenceView_Hfdp_Loaded(object sender, RoutedEventArgs e)
        {
            ButtonSectionStrategy.Style = styleSelected;
        }

        public ViewModelHfdp? ViewModel
        {
            get => DataContext as ViewModelHfdp;
            set => DataContext = value;
        }

        void MainItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.S)
            {
                // ViewModel?.SaveSelectedVolume();
                e.Handled = true;
            }
        }

        private void ButtonSection_Click(object sender, RoutedEventArgs e)
        {
            ResetButtonStyles();
            var btn = sender as Button;
            if (btn != null)
            {
                btn.Style = styleSelected;
            }
        }

        private void ResetButtonStyles()
        {
            ButtonSectionStrategy.Style = styleUnSelected;
            ButtonSectionObserver.Style = styleUnSelected;
            ButtonSectionDecorator.Style = styleUnSelected;
            ButtonSectionFactory.Style = styleUnSelected;
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
