using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Backlogger
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<BacklogTable> _backlogTabs;

        public BacklogRow SelectedRow { get; set; }

        public MainWindowViewModel()
        {
            addCommand = new Command(DoAddCommand);
            deleteCommand = new Command(DoDeleteCommand);
            BacklogTabs = new ObservableCollection<BacklogTable>();
        }

        public ObservableCollection<BacklogTable> BacklogTabs
        {
            get
            {
                return _backlogTabs;
            }
            set
            {
                _backlogTabs = value;
                OnPropertyChanged("BacklogTabs");
            }
        }

        public void AddRow(string tableName, BacklogRow row)
        {
            // Need to verify table is in BacklogTabs
            BacklogTable table = BacklogTabs.Where(tbl => tbl.Name == tableName).First();
            if (table == null)
                throw new ArgumentException("Table does not exist");
            table.Rows.Add(row);
        }
        public void RemoveRow(string tableName, BacklogRow row)
        {
            // Need to verify table is in BacklogTabs
            BacklogTable table = BacklogTabs.Where(tbl => tbl.Name == tableName).First();
            if (table == null)
                throw new ArgumentException("Table does not exist");
            table.Rows.Remove(row);
        }

        // Command Stuff -------
        /// <summary>
        /// Command when user adds a row
        /// </summary>

        private Command addCommand;
        public Command AddCommand
        {
            get { return addCommand; }
        }
        private void DoAddCommand(object tableName)
        {
            //Debug.WriteLine("Add row to table " + tableName.ToString());
            AddRow(tableName as string, new BacklogRow("", DateTime.Today, PriorityType.Low, ""));
        }
        /// <summary>
        /// Command when user deletes a row
        /// </summary>
        private Command deleteCommand;
        public Command DeleteCommand
        {
            get { return deleteCommand; }
        }
        private void DoDeleteCommand(object tableName)
        {
            if (SelectedRow != null) {
                //Debug.WriteLine("Removing row: " + SelectedRow.Name);
                RemoveRow(tableName as string, SelectedRow);  
            }
        }
    



        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }

    //class NewRowCommand : ICommand
    //{
    //    public event EventHandler CanExecuteChanged;

    //    public bool CanExecute(object parameter)
    //    {
    //        e.CanExecute = true;
    //    }

    //    public void Execute(object parameter)
    //    {
    //        MainWindow window = target as MainWindow;
    //        TabControl tabs = e.Source as TabControl;
    //        BacklogTable table = tabs.SelectedContent as BacklogTable;
    //        MainWindowVM.AddRow(table.Name, new BacklogRow("Name", DateTime.Today, PriorityType.Low, "Description"));
    //    }
    //}

}
