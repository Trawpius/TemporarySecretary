using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TemporarySecretary
{
    /// <summary>
    /// Interaction logic for EditSpan.xaml
    /// </summary>
    public partial class EditSpan : Window
    {
        public EditSpan()
        {
            InitializeComponent();

            DateTime today = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);
            Return = new DateSpan(today,today);
        }

        public DateSpan Return { get; set; }

        private void btnAccept_Click(object sender, RoutedEventArgs e)
        {
            DateTime start = (DateTime)dataPickStart.SelectedDate;
            DateTime end = (DateTime)dataPickEnd.SelectedDate;
            Return = new DateSpan(start, end);

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
