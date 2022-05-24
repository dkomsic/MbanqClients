using MbanqClients.Menu;
using MbanqClients.Models;
using MbanqClients.ViewModels;
using System;
using System.Windows.Input;

namespace MbanqClients.Commands
{
    public class SaveNewClientCmd : ICommand
    {
        private readonly NavigationMenu navigationMenu;
        private AddClientViewModel addClientViewModel;
        private string errorMessage;
        public MbanqEntities mbanqEntities;
        public int lastClientId;

        public SaveNewClientCmd(AddClientViewModel _addClientViewModel, NavigationMenu _navigationMenu, int _lastClientId)
        {
            navigationMenu = _navigationMenu;
            addClientViewModel = _addClientViewModel;
            mbanqEntities = new MbanqEntities();
            lastClientId = _lastClientId;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Osobe AddedClient = new Osobe();
            AddedClient.ID = ++lastClientId;
            AddedClient.OIB = addClientViewModel.OIB;
            AddedClient.Ime = addClientViewModel.Ime;
            AddedClient.Prezime = addClientViewModel.Prezime;
            AddedClient.Mjesto = addClientViewModel.Mjesto;
            AddedClient.Adresa = addClientViewModel.Adresa;
            AddedClient.Telefon = addClientViewModel.Telefon;
            AddedClient.Mail = addClientViewModel.Mail;

            mbanqEntities.Osobe.Add(AddedClient);
            try
            {
                mbanqEntities.SaveChanges();
            }
            catch (Exception)
            {
                errorMessage = "Validation error, OIB cannot be duplicated!";
            }
            navigationMenu.CurrentViewModel = new ClientsViewModel(navigationMenu, errorMessage);
        }
    }
}
