using MbanqClients.Menu;
using MbanqClients.ViewModels;
using System;
using System.Windows.Input;

namespace MbanqClients.Commands
{
    public class OpenAddClientViewCmd : ICommand
    {
        private readonly NavigationMenu navigationMenu;
        private int LastClientId;

        public OpenAddClientViewCmd(NavigationMenu _navigationMenu, int ID)
        {
            navigationMenu = _navigationMenu;
            LastClientId = ID;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            navigationMenu.CurrentViewModel = new AddClientViewModel(navigationMenu, LastClientId);
        }
    }
}
