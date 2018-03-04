using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Backlogger
{
    public class NewCommand : ICommand
    {
        private MainWindowViewModel MainWindowVM;
        public NewCommand(MainWindowViewModel _mainWindowVM)
        {
            MainWindowVM = _mainWindowVM;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            //TabControl tabs = e.Source as TabControl;
            //BacklogTable table = tabs.SelectedContent as BacklogTable;
            //MainWindowVM.AddRow(table, new BacklogRow("Name 6", DateTime.Today, PriorityType.Low, "Example Note"));
        }
    }
}
