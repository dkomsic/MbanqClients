using MbanqClients.Menu;
using MbanqClients.ViewModels;
using System.Windows;

namespace MbanqClients
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly NavigationMenu navigationMenu;
        public App()
        {
            navigationMenu = new NavigationMenu();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            navigationMenu.CurrentViewModel = new ClientsViewModel(navigationMenu);
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(navigationMenu)
            };
            MainWindow.Show();
            base.OnStartup(e);
        }
    }
}
