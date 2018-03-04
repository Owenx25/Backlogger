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
        private MainWindowViewModel MainWindowVM;

        public MainWindow()
        {
            InitializeComponent();
            MainWindowVM = new MainWindowViewModel();
            List<BacklogRow> entries = new List<BacklogRow>();
            entries.Add(new BacklogRow("Name 1", DateTime.Today, PriorityType.High, "Example Note"));
            entries.Add(new BacklogRow("Name 2", DateTime.Today, PriorityType.Medium, "Example Note"));
            entries.Add(new BacklogRow("Name 3", DateTime.Today, PriorityType.Low, "Example Note"));
            entries.Add(new BacklogRow("Name 4", DateTime.Today, PriorityType.Low, "Example Note"));
            entries.Add(new BacklogRow("Name 5", DateTime.Today, PriorityType.Low, "Example Note"));
            MainWindowVM.BacklogTabs.Add(new BacklogTable("Test", entries));

            //entries.Add(new BacklogRow("Mafia 3", DateTime.Today, PriorityType.Low, "PS4 Title"));
            //entries.Add(new BacklogRow("Persona 5", DateTime.Today, PriorityType.Low, "PS4 Title"));
            //entries.Add(new BacklogRow("Journey", DateTime.Today, PriorityType.Low, "PS4 Title"));
            //entries.Add(new BacklogRow("Darkwood", DateTime.Today, PriorityType.Low, "Top-down Horror on steam"));
            //BacklogTabs.Add(new BacklogTable("Games", entries));

            DataContext = MainWindowVM;
        }

        void NewCanExecute(object target, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        void NewExecuted(object target, ExecutedRoutedEventArgs e)
        {
            TabControl tabs = e.Source as TabControl;
            BacklogTable table = tabs.SelectedContent as BacklogTable;
            MainWindowVM.AddRow(table, new BacklogRow("Name 6", DateTime.Today, PriorityType.Low, "Example Note"));
        }
    }
}
