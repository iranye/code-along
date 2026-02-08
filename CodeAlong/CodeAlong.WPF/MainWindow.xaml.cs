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

        private Style styleSelected;
        private Style styleUnSelected;

        public MainWindow(MainViewModel mainViewModel)
        {
            InitializeComponent();
            viewModel = mainViewModel;
            DataContext = viewModel;
            Loaded += MainWindow_Loaded;
            styleSelected ??= (Style)FindResource("ButtonSelected");
            styleUnSelected ??= (Style)FindResource("ButtonUnSelected");
        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            await viewModel.LoadAsync();

            ButtonReferences.Style = StyleSelected;
            ButtonTopics.Style = StyleUnSelected;
        }

        private Style StyleSelected
        {
            get => styleSelected;
        }

        private Style StyleUnSelected
        {
            get => styleUnSelected;
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