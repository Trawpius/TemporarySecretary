using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml;
using System.Xml.Serialization;

namespace TemporarySecretary
{
    [XmlRoot("alltasks")]
    public class TaskCollection : ObservableCollection<Task>
    {
        #region Private Field

        private TaskCollection _active;
        private TaskCollection _overdue;

        public event PropertyChangedEventHandler PropertyChanged;
        #endregion


        #region Initializer
        public void Initialize()
        {
            InitializeActive();
            InitializeOverdue();
        }

        private void InitializeActive()
        {
            var collection = (from x in this
                              where DateSpan.Overlapped(new DateSpan(x.StartDate, x.EndDate)) && !x.Completed
                              select x);
            TaskCollection subtask = new TaskCollection();
            foreach (var item in collection)
            {
                item.PropertyChanged += ItemPropertyChanged;
                subtask.Add(item);
            }

            Active = subtask;
        }

        private void InitializeOverdue()
        {
            var collection = (from x in this
                              where x.EndDate < DateTime.Today && !x.Completed
                              select x);

            TaskCollection subtasks = new TaskCollection();
            foreach (var item in collection)
                subtasks.Add(item);

            Overdue = subtasks;
        }
        #endregion

        #region Properties
        public DateSpan DateSpan { get; set; } = new DateSpan(DateTime.Today, DateTime.Today);

        public TaskCollection Active
        {
            get { return _active; }
            set
            {
                _active = value;
                OnPropertyChanged();
            }
        }
        
        public TaskCollection Overdue
        {
            get { return _overdue; }
            set
            {
                _overdue = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Orderby
        public TaskCollection DisplayByEnum(TaskType type)
        {
            var collection = (from x in this
                              where x.TaskType == type
                              select x);
            TaskCollection subtasks = new TaskCollection();
            foreach (var item in collection)
                subtasks.Add(item);

            return subtasks;
        }

        public TaskCollection OrderByEnum(TaskType type)
        {
            var collection = (from x in this
                              orderby x.TaskType
                              select x);
            TaskCollection subtasks = new TaskCollection();
            foreach (var item in collection)
                subtasks.Add(item);

            return subtasks;
        }

        public TaskCollection OrderByEndDate(TaskType type)
        {
            var collection = (from x in this
                              orderby x.EndDate
                              select x);
            TaskCollection subtasks = new TaskCollection();
            foreach (var item in collection)
                subtasks.Add(item);

            return subtasks;
        }
        #endregion


        #region Property Change Events
        public void ItemPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            // Whem a Task changes, update Binded Collections
            Initialize();
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion
    }
}
