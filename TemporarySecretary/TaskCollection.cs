using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;

namespace TemporarySecretary
{
    [XmlRoot("alltasks")]
    public class TaskCollection : List<Task>
    {

        public static TaskCollection Deserialize(string file)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(TaskCollection));
            using (Stream reader = new FileStream(file, FileMode.Open))
            {
                return (TaskCollection)serializer.Deserialize(reader);
            }
        }

        public void Serialize(string file)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(TaskCollection));
            using (StreamWriter writer = new StreamWriter(file, append:false))
            {
                serializer.Serialize(writer, this);
            }
        }

        public TaskCollection SortByEnum(TaskType type)
        {
            var collection = (from x in this
                              where x.TaskType == type
                              select x);
            TaskCollection subtasks = new TaskCollection();
            foreach (var item in collection)
                subtasks.Add(item);

            return subtasks;

        }
    }
}
