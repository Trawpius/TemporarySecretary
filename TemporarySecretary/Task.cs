using System;
using System.Xml;
using System.Xml.Serialization;

namespace TemporarySecretary
{
    [XmlType("task")]
    public class Task
    {
        public Task() { }

        public Task(TaskType taskType, DateTime startDate, DateTime endDate, string desc)
        {
            TaskType = taskType;
            StartDate = startDate;
            EndDate = endDate;
            Desc = desc;
        }

        [XmlElement("tasktype")]
        public TaskType TaskType { get; set; }
        [XmlElement("desc")]
        public string Desc { get; set; }

        [XmlElement("startdate")]
        public DateTime StartDate { get; set; }
        [XmlElement("enddate")]
        public DateTime EndDate { get; set; }

        [XmlElement("actualstart")]
        public DateTime ActualStart { get; set; }
        [XmlElement("actualend")]
        public DateTime ActualEnd { get; set; }

        [XmlElement("overdue")]
        public bool Overdue { get; set; } = false;
        [XmlElement("completed")]
        public bool Completed { get; set; } = false;
    }
}
