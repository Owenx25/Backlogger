﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backlogger
{
    public class BacklogTable : INotifyPropertyChanged
    {
        // Name of the table
        String _name;
        public String Name
        {
            get { return _name; }
            set
            {
                _name = value;
                RaisePropertyChanged("Name");
            }
        }

        // List of all rows
        ObservableCollection<BacklogRow> _rows;
        public ObservableCollection<BacklogRow> Rows
        {
            get { return _rows; }
            set
            {
                _rows = value;
            }
        }

        public void PushRow (BacklogRow row)
        {
            if (row != null)
            {
                Rows.Add(row);
                RaisePropertyChanged("Rows");
            }  
        }

        public BacklogTable(String name, ObservableCollection<BacklogRow> rows)
        {
            Name = name;
            Rows = rows;
        }

        void RaisePropertyChanged(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
