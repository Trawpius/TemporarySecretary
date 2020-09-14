using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;

namespace TemporarySecretary
{
    /// <summary>
    /// Interaction logic for AddTask.xaml
    /// </summary>
    public partial class AddTask : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<TaskType> _tasktypes = new ObservableCollection<TaskType>();
        
        public AddTask()
        {
            InitializeComponent();
            DataContext = this;

            IEnumerable<TaskType> enums = Enum.GetValues(typeof(TaskType)).Cast<TaskType>();

            foreach (TaskType type in enums)
            {
                TaskTypes.Add(type);
            }

        }

        public Task Return { get; set; }

        public ObservableCollection<TaskType> TaskTypes
        {
            get { return _tasktypes; }
            set
            {
                _tasktypes = value;
                OnPropertyChanged();
            }
        }

        #region Events
        private void btnAccept_Click(object sender, RoutedEventArgs e)
        {
            DateTime start = dataPickStart.SelectedDate == null ? DateTime.MinValue : (DateTime)dataPickStart.SelectedDate;
            DateTime end = dataPickEnd.SelectedDate == null ? DateTime.MinValue : (DateTime)dataPickEnd.SelectedDate;
            string desc = txboxDesc.Text;
            TaskType typ;
            if (cmbTask.SelectedValue == null)
            {
                MessageBox.Show("Select Task Type");
                return;
            }
            else
                typ = (TaskType)cmbTask.SelectedValue;

            Return = new Task(typ, start, end, desc);
            DialogResult = true;
            Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
        #endregion

        #region Event Handler
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion
    }
}
