using MbanqClients.Models;
using MbanqClients.ViewModels;
using System;
using System.ComponentModel;
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
            clientsViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public bool CanExecute(object parameter)
        {
            return clientsViewModel.SelectedClient == null ? false : true;
        }

        public void Execute(object parameter)
        {
            Osobe DeletedClient = clientsViewModel.SelectedClient;

            clientsViewModel.mbanqEntities.Osobe.Remove(DeletedClient);
            clientsViewModel.mbanqEntities.SaveChanges();
            clientsViewModel.ClientList.Remove(DeletedClient);
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
