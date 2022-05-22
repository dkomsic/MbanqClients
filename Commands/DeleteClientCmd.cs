using MbanqClients.Models;
using MbanqClients.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MbanqClients.Commands
{
    public class DeleteClientCmd : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private ClientsViewModel clientsViewModel;
        public MbanqEntities mbanqEntities;

        public DeleteClientCmd(ClientsViewModel _clientsViewModel)
        {
            clientsViewModel = _clientsViewModel;
            mbanqEntities = new MbanqEntities();
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Osobe DeletedClient = clientsViewModel.SelectedClient;

            clientsViewModel.mbanqEntities.Osobe.Remove(DeletedClient);
            clientsViewModel.mbanqEntities.SaveChanges();
            clientsViewModel.ClientList.Remove(DeletedClient);
        }
    }
}
