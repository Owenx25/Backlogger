using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backlogger
{
    public class BacklogTable
    {
        // Name of the table
        String _name;
        public String Name
        {
            get { return _name; }
            set { _name = value; }
        }

        // List of all rows
        List<BacklogRow> _rows;
        public List<BacklogRow> Rows
        {
            get { return _rows; }
            set { _rows = value; }
        }

        public void PushRow (BacklogRow row)
        {
            if (row != null)
                Rows.Add(row);
        }

        public BacklogTable(String name, List<BacklogRow> rows)
        {
            Name = name;
            Rows = rows;
        }
    }
}
