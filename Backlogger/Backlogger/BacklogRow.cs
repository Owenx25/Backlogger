using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backlogger
{
    public enum PriorityType { Low, Medium, High }

    public class BacklogRow
    {
        // Name of the entry
        public String Name { get; set; }
        // Date the entry was created
        public DateTime Date { get; set; }
        // Priority level of the entry
        public PriorityType Priority { get; set; }
        // Any notes about the entry
        public String Notes { get; set; }

        // User-created list of columns
        public List<String> CustomColumns = new List<string>();
    }
}
