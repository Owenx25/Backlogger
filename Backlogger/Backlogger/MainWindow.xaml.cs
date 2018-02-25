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
            List<BacklogTable> BacklogTabs = new List<Backlogger.BacklogTable>();

            List<BacklogRow> entries = new List<BacklogRow>();
            entries.Add(new BacklogRow("Mafia 3", DateTime.Today, PriorityType.Low, "PS4 Title"));
            //BacklogTable Games = new BacklogTable("Games", entries);
            BacklogTabs.Add(new BacklogTable("Games", entries));
            TabCont.ItemsSource = BacklogTabs;


            //TestDG.ItemsSource = Games.Rows;
            //TestDG.DataContext = Games;
            //TableTab.DataContext = Games;
        }
    }
}
