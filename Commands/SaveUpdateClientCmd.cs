using MbanqClients.Menu;
using MbanqClients.Models;
using MbanqClients.ViewModels;
using System;
using System.Linq;
using System.Windows.Input;

namespace MbanqClients.Commands
{
    public class SaveUpdateClientCmd : ICommand
    {
        private readonly NavigationMenu navigationMenu;
        private UpdateClientViewModel updateClientViewModel;
        public MbanqEntities mbanqEntities;

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true; //todo 
        }

        public void Execute(object parameter)
        {
            var UpdatedClient = mbanqEntities.Osobe.FirstOrDefault(x => x.ID == updateClientViewModel.ID);
            UpdatedClient.OIB = updateClientViewModel.OIB; //todo add check here
            UpdatedClient.Ime = updateClientViewModel.Ime;
            UpdatedClient.Prezime = updateClientViewModel.Prezime;
            UpdatedClient.Mjesto = updateClientViewModel.Mjesto;
            UpdatedClient.Adresa = updateClientViewModel.Adresa;
            UpdatedClient.Telefon = updateClientViewModel.Telefon;
            UpdatedClient.Mail = updateClientViewModel.Mail;
            mbanqEntities.SaveChanges();
            navigationMenu.CurrentViewModel = new ClientsViewModel(navigationMenu);
        }

        public SaveUpdateClientCmd(NavigationMenu _navigationMenu, UpdateClientViewModel _updateClientViewModel)
        {
            navigationMenu = _navigationMenu;
            updateClientViewModel = _updateClientViewModel;
            mbanqEntities = new MbanqEntities();
        }
    }
}
