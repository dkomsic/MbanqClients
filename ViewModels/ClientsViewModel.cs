using MbanqClients.Commands;
using MbanqClients.Menu;
using MbanqClients.Models;
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
            }
        }

        public ICommand AddClientCmd { get; }
        public ICommand DelClientCmd { get; }
        public ICommand UpdateClientCmd { get; }
        #endregion

        public ClientsViewModel(NavigationMenu navigation)
        {
            mbanqEntities = new MbanqEntities();
            LoadData();
            AddClientCmd = new OpenAddClientViewCmd(navigation, mbanqEntities.Osobe.Count());
            DelClientCmd = new DeleteClientCmd(this);
            UpdateClientCmd = new OpenUpdateClientViewCmd(navigation, this);
        }
        private void LoadData()
        {
            ClientList = new ObservableCollection<Osobe>(mbanqEntities.Osobe);
        }

    }
}
