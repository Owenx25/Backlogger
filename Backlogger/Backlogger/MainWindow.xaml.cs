using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Backlogger
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            List<BacklogRow> entries = new List<BacklogRow>();
            entries.Add(new BacklogRow()
            {
                Name = "Mafia 3",
                Date = DateTime.Today,
                Priority = PriorityType.Low,
                Notes = "PS4 Title"
            });

            TestDG.ItemsSource = entries;
            TestDG.DataContext = entries;
        }
    }
}
