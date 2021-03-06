using MbanqClients.Commands;
using MbanqClients.Menu;
using System.Windows.Input;

namespace MbanqClients.ViewModels
{
    public class AddClientViewModel : ViewModelBase
    {
        #region Private properties
        private int iD;
        private int oIB;
        private string ime;
        private string prezime;
        private string mjesto;
        private string adresa;
        private int telefon;
        private string mail;
        #endregion
        #region Public properties
        public int ID
        {
            get => iD;
            set
            {
                iD = value;
                OnPropertyChanged(nameof(ID));
            }
        }
        public int OIB
        {
            get => oIB;
            set
            {
                oIB = value;
                OnPropertyChanged(nameof(OIB));
            }
        }
        public string Ime
        {
            get => ime;
            set
            {
                ime = value;
                OnPropertyChanged(nameof(Ime));
            }
        }
        public string Prezime
        {
            get => prezime;
            set
            {
                prezime = value;
                OnPropertyChanged(nameof(Prezime));
            }
        }
        public string Mjesto
        {
            get => mjesto;
            set
            {
                mjesto = value;
                OnPropertyChanged(nameof(Mjesto));
            }
        }
        public string Adresa
        {
            get => adresa;
            set
            {
                adresa = value;
                OnPropertyChanged(nameof(Adresa));
            }
        }
        public int Telefon
        {
            get => telefon;
            set
            {
                telefon = value;
                OnPropertyChanged(nameof(Telefon));
            }
        }
        public string Mail
        {
            get => mail;
            set
            {
                mail = value;
                OnPropertyChanged(nameof(Mail));
            }
        }
        public ICommand SaveClientCmd { get; }
        public ICommand CancelCmd { get; }
        #endregion
        public AddClientViewModel(NavigationMenu navigation, int LastClientId)
        {
            SaveClientCmd = new SaveNewClientCmd(this, navigation, LastClientId);
            CancelCmd = new CancelCmd(navigation);
        }
    }
}
