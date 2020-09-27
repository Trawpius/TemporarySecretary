using System;
using System.Linq;
using System.Collections.ObjectModel;
using System.Windows;
using System.Collections.Generic;

namespace TemporarySecretary
{
    /// <summary>
    /// Interaction logic for EditTask.xaml
    /// </summary>
    public partial class EditTask : Window
    {
        public EditTask(TaskCollection collection)
        {
            InitializeComponent();

            foreach (var item in collection)
            {
                if(!item.Completed)
                    Tasks.Add(item);
            }

            IEnumerable<TaskType> enums = Enum.GetValues(typeof(TaskType)).Cast<TaskType>();

            foreach (TaskType type in enums)
                TaskTypes.Add(type);

            DataContext = this;
        }

        public ObservableCollection<Task> Tasks { get; set; } = new ObservableCollection<Task>();
        public ObservableCollection<TaskType> TaskTypes { get; set; } = new ObservableCollection<TaskType>();

        public TaskCollection Return { get; set; } = new TaskCollection();


        private void btnAccept_Click(object sender, RoutedEventArgs e)
        {
            foreach (Task task in Tasks)
                Return.Add(task);

            DialogResult = true;
            Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }

   
}
