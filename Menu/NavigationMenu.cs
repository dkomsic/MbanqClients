using MbanqClients.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MbanqClients.Menu
{
    public class NavigationMenu
    {
        public event Action CurrentViewModelChanged;
        public ViewModelBase currentViewModel;
        public ViewModelBase CurrentViewModel
        {
            get => currentViewModel;

            set
            {
                currentViewModel = value;
                OnCurentViewModelChanged();
            }

        }

        private void OnCurentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }
    }
}
