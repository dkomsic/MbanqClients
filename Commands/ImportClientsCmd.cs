using MbanqClients.Helpers;
using MbanqClients.Models;
using MbanqClients.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MbanqClients.Commands
{
    public class ImportClientsCmd : ICommand
    {
        private ClientsViewModel clientsViewModel;
        private string errorMessage;
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.DefaultExt = ".csv";
            dialog.Filter = "Text documents (.csv)|*.csv";

            bool? result = dialog.ShowDialog();
            List<Osobe> importedClients = new List<Osobe>();
            if (result == true)
            {
                string filename = dialog.FileName;
                importedClients = new ImportFileParser().Parse(filename);
            }

            if (importedClients.Count != 0)
            {
                foreach (var item in importedClients)
                {
                    clientsViewModel.mbanqEntities.Osobe.Add(item);
                }

                try
                {
                    clientsViewModel.mbanqEntities.SaveChanges();
                }
                catch (Exception e)
                {
                    errorMessage = e.Message;
                }
                
            }
            clientsViewModel.ClientList = new ObservableCollection<Osobe>(clientsViewModel.mbanqEntities.Osobe);
            clientsViewModel.ErrorMessage = errorMessage;
        }

        public ImportClientsCmd(ClientsViewModel _clientsViewModel)
        {
            clientsViewModel = _clientsViewModel;
        }
    }
}
