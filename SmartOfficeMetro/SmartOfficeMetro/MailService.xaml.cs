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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using SmartOfficeMetro.Model;
namespace SmartOfficeMetro
{
    /// <summary>
    /// Interaction logic for orderMail.xaml
    /// </summary>
    public partial class MailService : UserControl
    {
        String mailDestination;
        String mailTime;
        String note;
        MetroWindow mainWindow; //need an instance of the main window to display message
        public MailService()
        {
            InitializeComponent();
            datePicker.SelectedDate = System.DateTime.Today;
            timePicker.Text = System.DateTime.Today.TimeOfDay.ToString();
        }

        

        private void sendNow(object sender, EventArgs e)
        {
            datePicker.IsEnabled = !datePicker.IsEnabled;
            timePicker.IsEnabled = !timePicker.IsEnabled;
        }

        private void sendToMailRoom(object sender, EventArgs e)
        {
            comboBoxReciver.IsEnabled = !comboBoxReciver.IsEnabled;
        }

        private void requestPickup(object sender, RoutedEventArgs e)
        {
            //SmartOfficeClient.sendMessage(new Mail(mailDestination, mailTime, note));
        }
    }
}
