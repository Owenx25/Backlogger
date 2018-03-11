using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backlogger
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<BacklogTable> _backlogTabs;

        public MainWindowViewModel()
        {
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

        public void AddRow(String tableName, BacklogRow row)
        {
            // Need to verify table is in BacklogTabs
            BacklogTable table = BacklogTabs.Where(tbl => tbl.Name == tableName).First();
            if (table == null)
                throw new ArgumentException("Table does not exist");
            table.PushRow(row);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
