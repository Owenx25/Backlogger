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

        public void AddRow(BacklogTable table, BacklogRow row)
        {
            table.PushRow(row);
            OnPropertyChanged("BacklogTabs");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
