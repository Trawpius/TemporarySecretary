using System;
using System.Linq;
using System.Collections.ObjectModel;
using System.Windows;


namespace TemporarySecretary
{
    /// <summary>
    /// Interaction logic for DeleteTask.xaml
    /// </summary>
    public partial class DeleteTask : Window
    {
        public DeleteTask(TaskCollection collection)
        {
            InitializeComponent();

            foreach (var item in collection)

                Tasks.Add(new DeleteItem(item));

            DataContext = this;
        }

        public ObservableCollection<DeleteItem> Tasks { get; set; } = new ObservableCollection<DeleteItem>();
        public TaskCollection Return { get; set; } = new TaskCollection();

        private void btnAccept_Click(object sender, RoutedEventArgs e)
        {
            foreach(DeleteItem del in Tasks)
            {
                if (!del.Selected)
                    Return.Add(del.Task);
            }

            DialogResult = true;
            Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }

    public class DeleteItem
    {
        public DeleteItem(Task task)
        {
            Task = task;
            Selected = false;
        }
        public Task Task { get; set; }
        public bool Selected { get; set; }
    }
}
