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
        public BacklogTable SelectedTable { get; set; }

        public MainWindowViewModel()
        {
            // Commands
            addRowCommand = new Command(DoAddRowCommand);
            deleteRowCommand = new Command(DoDeleteRowCommand);
            addTableCommand = new Command(DoAddTableCommand);
            deleteTableCommand = new Command(DoDeleteTableCommand);
            exitCommand = new Command(DoExitCommand);

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

        // Command Stuff -------
        /// <summary>
        /// Command when user adds a row
        /// </summary>
        private Command addRowCommand;
        public Command AddRowCommand
        {
            get { return addRowCommand; }
        }
        private void DoAddRowCommand(object tableName)
        {
            //Debug.WriteLine("Add row to table " + tableName.ToString());
            if (SelectedRow != null && SelectedTable != null)
            {
                //Debug.WriteLine("Removing row: " + SelectedRow.Name);
                SelectedTable.Rows.Add(new BacklogRow("", DateTime.Today, PriorityType.Low, ""));
            }
        }
        /// <summary>
        /// Command when user deletes a row
        /// </summary>
        private Command deleteRowCommand;
        public Command DeleteRowCommand
        {
            get { return deleteRowCommand; }
        }
        private void DoDeleteRowCommand(object tableName)
        {
            if (SelectedRow != null && SelectedTable != null) {
                //Debug.WriteLine("Removing row: " + SelectedRow.Name);
                SelectedTable.Rows.Remove(SelectedRow);
            }
        }
        /// <summary>
        /// Command when user adds a Table
        /// </summary>
        private Command addTableCommand;
        public Command AddTableCommand
        {
            get { return addTableCommand; }
        }
        private void DoAddTableCommand(object tableName)
        {
            // This Might be implemented differently because
            // adding a table will have its own window
            if (SelectedTable != null)
            {
                BacklogTabs.Add(new BacklogTable(SelectedTable));
            }
        }
        /// <summary>
        /// Command when user deletes a Table
        /// </summary>
        private Command deleteTableCommand;
        public Command DeleteTableCommand
        {
            get { return deleteTableCommand; }
        }
        private void DoDeleteTableCommand()
        {
            if (SelectedTable != null)
            {
                BacklogTabs.Remove(SelectedTable);
            }
        }
        /// <summary>
        /// Command when user exits app from toolbar
        /// </summary>
        private Command exitCommand;
        public Command ExitCommand
        {
            get { return exitCommand; }
        }
        private void DoExitCommand()
        {
            System.Windows.Application.Current.Shutdown();
        }




        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
