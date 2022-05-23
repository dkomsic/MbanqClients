using MbanqClients.Menu;
using MbanqClients.Models;
using MbanqClients.ViewModels;
using System;
using System.ComponentModel;
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
            return clientsViewModel.SelectedClient == null ? false : true;
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
            clientsViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(ClientsViewModel.IsSelectedClientChanged))
            {
                CanExecuteChanged?.Invoke(this, new EventArgs());
            }
        }
    }
}
