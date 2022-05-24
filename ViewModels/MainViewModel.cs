using MbanqClients.Menu;

namespace MbanqClients.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private NavigationMenu navigationMenu;
        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }

        public ViewModelBase CurrentViewModel => navigationMenu.currentViewModel;
        public MainViewModel(NavigationMenu _navigationMenu)
        {
            navigationMenu = _navigationMenu;
            navigationMenu.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }

    }
}
