using System;
using System.Xml;
using System.Xml.Serialization;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TemporarySecretary
{
    [XmlType("task")]
    public class Task: INotifyPropertyChanged
    {
        #region Event
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Private Field
        private bool _complete;
        #endregion

        #region Constructor
        public Task()
        {
            Completed = false;
        }

        public Task(TaskType taskType, DateTime startDate, DateTime endDate, string desc)
        {
            TaskType = taskType;
            StartDate = startDate;
            EndDate = endDate;
            Desc = desc;
            Completed = false;
        }
        #endregion

        #region Public Property

        [XmlElement("tasktype")]
        public TaskType TaskType { get; set; }
        [XmlElement("desc")]
        public string Desc { get; set; }

        [XmlElement("startdate")]
        public DateTime StartDate { get; set; }
        [XmlElement("enddate")]
        public DateTime EndDate { get; set; }

        [XmlElement("actualend")]
        public DateTime ActualEnd { get; set; }

        [XmlElement("overdue")]
        public bool Overdue { get; set; } = false;
        [XmlElement("completed")]
        public bool Completed { get; set; }
        #endregion

        #region Methods
        public void Complete()
        {
            Completed = true;
            ActualEnd = DateTime.Today;

            OnPropertyChanged("Completed");
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
