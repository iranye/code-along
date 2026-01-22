using CodeAlong.WPF.ViewModel;
using System.Windows;

namespace CodeAlong.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MainViewModel viewModel;

        public MainWindow(MainViewModel mainViewModel)
        {
            InitializeComponent();
            viewModel = mainViewModel;
            DataContext = viewModel;
            Loaded += MainWindow_Loaded;
        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            await viewModel.LoadAsync();

            ButtonReferences.Style = StyleSelected;
            ButtonTopics.Style = StyleUnSelected;
        }

        private Style styleSelected;
        private Style styleUnSelected;

        private Style StyleSelected
        {
            get => styleSelected ??= FindResource("ButtonSelected") as Style;
        }

        private Style StyleUnSelected
        {
            get => styleUnSelected ??= FindResource("ButtonUnSelected") as Style;
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonReferences_Click(object sender, RoutedEventArgs e)
        {
            ButtonReferences.Style = StyleSelected;
            ButtonTopics.Style = StyleUnSelected;
        }

        private void ButtonTopics_Click(object sender, RoutedEventArgs e)
        {
            ButtonReferences.Style = StyleUnSelected;
            ButtonTopics.Style = StyleSelected;
        }
    }
}