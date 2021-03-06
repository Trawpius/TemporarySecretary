﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
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
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Private Fields
        //https://docs.microsoft.com/en-us/dotnet/api/system.reflection.assembly.getexecutingassembly?view=netcore-3.1
        private string config = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "config.xml");

        private TaskCollection _collection;
        #endregion

        #region Initialize
        public MainWindow()
        {
            InitializeComponent();

            Collection = Configuration<TaskCollection>.Deserialize(config);
            Collection.PropertyChanged += ItemPropertyChanged;

            Collection.Initialize();

            DataContext = this;
        }
        #endregion

        #region Public Properties
        public TaskCollection Collection
        {
            get { return _collection; }
            set
            {
                _collection = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region UI Events
        private void toolDatespan_Click(object sender, RoutedEventArgs e)
        {
            EditSpan wind = new EditSpan();
            wind.ShowDialog();

            if (wind.DialogResult == true)
                Collection.DateSpan = wind.Return;
        }

        private void toolAdd_Click(object sender, RoutedEventArgs e)
        {
            AddTask wind = new AddTask();
            wind.ShowDialog();

            Task rtn = wind.Return;
            Collection.Add(rtn);
        }

        private void ToolDelete_Click(object sender, RoutedEventArgs e)
        {
            DeleteTask wind = new DeleteTask(Collection);
            wind.ShowDialog();

            if (wind.DialogResult == true)
                Collection = wind.Return;
        }

        private void toolEdit_Click(object sender, RoutedEventArgs e)
        {
            EditTask wind = new EditTask(Collection);
            wind.ShowDialog();

            if(wind.DialogResult==true)
                Collection = wind.Return;
        }

        private void toolSaveClose_Click(object sender, RoutedEventArgs e)
        {
            Configuration<TaskCollection>.Serialize(config, Collection);
            Environment.Exit(0);
        }

        private void toolSave_Click(object sender, RoutedEventArgs e)
        {
            Configuration<TaskCollection>.Serialize(config, Collection);
        }
        #endregion

        #region Event Handler
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public void ItemPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            OnPropertyChanged("Collection");
        }
        #endregion
    } 
}
