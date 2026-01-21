using System.Windows;

namespace CodeAlong.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
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

        private void ButtonPatterns_Click(object sender, RoutedEventArgs e)
        {
            ButtonPatterns.Style = StyleSelected;
            ButtonTopics.Style = StyleUnSelected;
        }

        private void ButtonTopics_Click(object sender, RoutedEventArgs e)
        {
            ButtonPatterns.Style = StyleUnSelected;
            ButtonTopics.Style = StyleSelected;
        }
    }
}