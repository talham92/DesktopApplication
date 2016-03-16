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
using MahApps.Metro.Controls.Dialogs;
using System.Data;

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
            DataTable notifications = new DataTable("notification");
            notifications.Columns.Add("Recipient", typeof(String));
            notifications.Columns.Add("Date", typeof(String));
            notifications.Columns.Add("Time Delivered", typeof(String));
            notifications.Columns.Add("Note", typeof(String));
            notifications.Columns.Add("Status", typeof(String));

            notifications.Rows.Add(new Object[] { "Naorin", "March 13, 2016", "1:00:00 PM", "Please sign the promotion letter", "Delivered" });
            notifications.Rows.Add(new Object[] { "Thinh", "March 13, 2016", "1:50:00 PM", "Rough UI draft" });
            notifications.Rows.Add(new Object[] { "Poornima", "March 13, 2016", "3:00:00 PM", "Proposal for data mapping", "Delivered" });
            notifications.Rows.Add(new Object[] { "Terrell", "March 13, 2016", "3:10:00 PM", "Your pen", "Delivered" });
            notifications.Rows.Add(new Object[] { "Raghav", "March 13, 2016", "4:00:00 PM", "Appraisal form", "Delivered" });
            InitializeComponent();

            dataGridHistory.DataContext = notifications.DefaultView;
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
            // var metroWindow = (_openedViews.First() as MetroWindow);

          //  SmartOfficeClient.sendMessage(4,);
        //    var metroWindow = (Application.Current.MainWindow as MetroWindow);

        //    metroWindow.ShowMessageAsync("Thank you!!", "You requested a pickup to Talha Mahmood. The robot is on it's way!", MessageDialogStyle.Affirmative);


            //window.show
            //SmartOfficeClient.sendMessage(new Mail(mailDestination, mailTime, note));
        }
        
    }
}
