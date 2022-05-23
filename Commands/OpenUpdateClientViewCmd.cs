using MbanqClients.Menu;
using MbanqClients.Models;
using MbanqClients.ViewModels;
using System;
using System.Windows.Input;

namespace MbanqClients.Commands
{
    public class OpenUpdateClientViewCmd : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private readonly NavigationMenu navigationMenu;
        private ClientsViewModel clientsViewModel;

        public bool CanExecute(object parameter)
        {
            return true; // todo return true only if selected layer != null
        }

        public void Execute(object parameter)
        {
            Osobe UpdateClient = clientsViewModel.SelectedClient;
            navigationMenu.CurrentViewModel = new UpdateClientViewModel(navigationMenu, UpdateClient);
        }

        public OpenUpdateClientViewCmd(NavigationMenu _navigationMenu, ClientsViewModel _clientsViewModel)
        {
            navigationMenu = _navigationMenu;
            clientsViewModel = _clientsViewModel;
        }
    }
}
