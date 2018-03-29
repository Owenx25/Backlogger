using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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
            ObservableCollection<BacklogRow> entries = new ObservableCollection<BacklogRow>
            {
                new BacklogRow("Name 1", DateTime.Today, PriorityType.High, "Example Note"),
                new BacklogRow("Name 2", DateTime.Today, PriorityType.Medium, "Example Note"),
                new BacklogRow("Name 3", DateTime.Today, PriorityType.Low, "Example Note"),
                new BacklogRow("Name 4", DateTime.Today, PriorityType.Low, "Example Note"),
                new BacklogRow("Name 5", DateTime.Today, PriorityType.Low, "Example Note")
            };
            MainWindowVM.BacklogTabs.Add(new BacklogTable("Test", entries));

            //entries.Add(new BacklogRow("Mafia 3", DateTime.Today, PriorityType.Low, "PS4 Title"));
            //entries.Add(new BacklogRow("Persona 5", DateTime.Today, PriorityType.Low, "PS4 Title"));
            //entries.Add(new BacklogRow("Journey", DateTime.Today, PriorityType.Low, "PS4 Title"));
            //entries.Add(new BacklogRow("Darkwood", DateTime.Today, PriorityType.Low, "Top-down Horror on steam"));
            //BacklogTabs.Add(new BacklogTable("Games", entries));
            MainWindowVM.SelectedTable = MainWindowVM.BacklogTabs[0];
            DataContext = MainWindowVM;
        }
    }
}
