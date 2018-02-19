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
        String Name { get; set; }
        // List of all rows
        List<BacklogRow> Columns { get; set; }
    }
}
