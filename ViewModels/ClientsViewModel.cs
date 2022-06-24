using MbanqClients.Commands;
using MbanqClients.Menu;
using MbanqClients.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace MbanqClients.ViewModels
{
    public class ClientsViewModel : ViewModelBase
    {
        #region Private properties
        private ObservableCollection<Osobe> clientList;
        private Osobe selectedClient;
        private string errorMessage;
        #endregion

        #region Public properties
        public MbanqEntities mbanqEntities;

        public ObservableCollection<Osobe> ClientList
        {
            get { return clientList; }
            set
            {
                clientList = value;
                OnPropertyChanged(nameof(ClientList));
            }
        }

        public Osobe SelectedClient
        {
            get { return selectedClient; }
            set
            {
                selectedClient = value;
                OnPropertyChanged(nameof(SelectedClient));
                OnPropertyChanged(nameof(IsSelectedClientChanged));
            }
        }

        public string ErrorMessage
        {
            get { return errorMessage; }
            set
            {
                errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }

        public ICommand AddClientCmd { get; }
        public ICommand DelClientCmd { get; }
        public ICommand UpdateClientCmd { get; }
        public ICommand ImportClientsCmd { get; }
        public ICommand ExitCmd { get; }
        public static bool IsSelectedClientChanged { get; internal set; }
        #endregion

        public ClientsViewModel(NavigationMenu navigation, string errorMessage = "")
        {
            mbanqEntities = new MbanqEntities();
            LoadData();
            AddClientCmd = new OpenAddClientViewCmd(navigation, mbanqEntities.Osobe.Count());
            DelClientCmd = new DeleteClientCmd(this);
            UpdateClientCmd = new OpenUpdateClientViewCmd(navigation, this);
            ImportClientsCmd = new ImportClientsCmd(this);
            ExitCmd = new ExitCmd();
            ErrorMessage = errorMessage;
        }
        private void LoadData()
        {
            try
            {
                ClientList = new ObservableCollection<Osobe>(mbanqEntities.Osobe);
            }
            catch (Exception)
            {
                throw new Exception("Failed to load data from db!");
            }
        }
    }
}
