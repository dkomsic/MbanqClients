using MbanqClients.Commands;
using MbanqClients.Menu;
using MbanqClients.Models;
using System.Windows.Input;

namespace MbanqClients.ViewModels
{
    public class UpdateClientViewModel : ViewModelBase
    {
        private int iD;
        private int oIB;
        private string ime;
        private string prezime;
        private string mjesto;
        private string adresa;
        private int telefon;
        private string mail;

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

        public ICommand UpdateClientCmd { get; }
        public UpdateClientViewModel(NavigationMenu _navigationMenu, Osobe _selectedClient)
        {
            this.ID = _selectedClient.ID;
            this.OIB = _selectedClient.OIB;
            this.Ime = _selectedClient.Ime;
            this.Prezime = _selectedClient.Prezime;
            this.Mjesto = _selectedClient.Mjesto;
            this.Adresa = _selectedClient.Adresa;
            this.Telefon = _selectedClient.Telefon;
            this.Mail = _selectedClient.Mail;

            UpdateClientCmd = new SaveUpdateClientCmd(_navigationMenu, this);
        }
    }
}
