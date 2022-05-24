using System;
using System.Windows.Input;

namespace MbanqClients.Commands
{
    public class ExitCmd : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            System.Windows.Application.Current.Shutdown();
        }
        public ExitCmd()
        {
        }
    }
}
