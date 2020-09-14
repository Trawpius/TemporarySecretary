using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
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

namespace TemporarySecretary
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //https://docs.microsoft.com/en-us/dotnet/api/system.reflection.assembly.getexecutingassembly?view=netcore-3.1
        private string config = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "config.xml");


        public MainWindow()
        {
            InitializeComponent();

            TaskCollection collection = new TaskCollection();

            Collection = TaskCollection.Deserialize(config);

            collection.Serialize(config);
        }

        private void toolAdd_Click(object sender, RoutedEventArgs e)
        {
            AddTask task = new AddTask();
            task.ShowDialog();

            Task rtn = task.Return;
            Collection.Add(rtn);
        }

        public TaskCollection Collection { get; set; }

        private void toolSaveClose_Click(object sender, RoutedEventArgs e)
        {
            Collection.Serialize(config);
            Environment.Exit(0);
        }

        private void toolSave_Click(object sender, RoutedEventArgs e)
        {
            Collection.Serialize(config);
        }
    }
}
