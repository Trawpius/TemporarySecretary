
using System.Windows;
using System.Windows.Controls;

namespace TemporarySecretary
{
    /// <summary>
    /// Interaction logic for TaskControl.xaml
    /// </summary>
    public partial class TaskControl : UserControl
    { 
        public TaskControl()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Task task = this.DataContext as Task;
            task.Complete();
        }
    }
}
