using MbanqClients.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MbanqClients.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private NavigationMenu navigationMenu;

        public ViewModelBase CurrentViewModel => navigationMenu.currentViewModel ;
        public MainViewModel(NavigationMenu _navigationMenu)
        {
            navigationMenu = _navigationMenu;
            navigationMenu.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
