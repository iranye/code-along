namespace CodeAlong.WPF
{
    using CodeAlong.Domain.Data;
    using CodeAlong.WPF.ViewModel;
    using CodeAlong.WPF.ViewModel.References;
    using CodeAlong.WPF.ViewModel.Sections;
    using Microsoft.Extensions.DependencyInjection;
    using System.Windows;

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ServiceProvider serviceProvider;

        public App()
        {
            ServiceCollection services = new();
            ConfigureServices(services);
            serviceProvider = services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var mainWindow = serviceProvider.GetService<MainWindow>();
            mainWindow?.Show();
        }

        private void ConfigureServices(ServiceCollection services)
        {
            services.AddTransient<MainWindow>();
            services.AddTransient<MainViewModel>();

            services.AddTransient<ViewModelHfdp>();
            services.AddTransient<TopicsViewModel>();

            services.AddTransient<ViewModelDecorator>();
            services.AddTransient<ViewModelFactoryPattern>();

            services.AddTransient<IDataProvider, DataProvider>();
            // services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
    }
}
