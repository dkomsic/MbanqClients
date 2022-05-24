using MbanqClients.Menu;
using MbanqClients.ViewModels;
using System;
using System.Windows.Input;

namespace MbanqClients.Commands
{
    class CancelCmd : ICommand
    {
        private NavigationMenu navigationMenu;
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            navigationMenu.CurrentViewModel = new ClientsViewModel(navigationMenu);
        }

        public CancelCmd(NavigationMenu _navigationMenu)
        {
            navigationMenu = _navigationMenu;
        }
    }
}
