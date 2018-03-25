using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backlogger
{
    public enum PriorityType { Low, Medium, High }

    public class BacklogRow : INotifyPropertyChanged
    {
        // Name of the entry
        private String _name;
        public String Name
        {
            get { return _name; }
            set
            {
                _name = value;
                RaisePropertyChanged("Name");
            }
        }

        // Date the entry was created
        private DateTime _date;
        public DateTime Date
        {
            get { return _date; }
            set
            {
                _date = value;
                RaisePropertyChanged("Date");
            }
        }

        // Priority level of the entry
        private PriorityType _priority;
        public PriorityType Priority
        {
            get { return _priority; }
            set
            {
                _priority = value;
                RaisePropertyChanged("Priority");
            }
        }

        // Any notes about the entry
        private string _notes;
        public string Notes
        {
            get { return _notes; }
            set
            {
                _notes = value;
                RaisePropertyChanged("Notes");
            }
        }

        // Status of row
        private Boolean _completed;
        public Boolean Completed
        {
            get { return _completed; }
            set
            {
                _completed = value;
                RaisePropertyChanged("Completed");
            }
        }

        // User-created list of columns
        public ObservableCollection<string> _customColumns;
        public ObservableCollection<string> CustomColumns
        {
            get { return _customColumns; }
            set
            {
                _customColumns = value;
                //RaisePropertyChanged("CustomColumns");
            }
        }

        // Regular Constructor
        public BacklogRow(string name, DateTime date, PriorityType priority, string notes)
        {
            Name = name;
            Date = date;
            Priority = priority;
            Notes = notes;
            CustomColumns = new ObservableCollection<string>();
            Completed = false;
        }

        void RaisePropertyChanged(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
