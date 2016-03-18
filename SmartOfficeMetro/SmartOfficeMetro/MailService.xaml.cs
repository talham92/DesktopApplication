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
        Boolean send_now;
        Boolean send_to_mail_room;
        String destination;
        DateTime pickup_time;
        String subject;
        String note;
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
            List<List<String>> user_names = new List<List<string>>();
            foreach(List<String> users in UserManager.Instance.user_details)
            {
                user_names.Add(new List<string> { users.ElementAt(0), users.ElementAt(1) });
            }
            comboBoxReciver.ItemsSource = user_names.ElementAt(0).ElementAt(1);
        }

        

        private void sendNow(object sender, EventArgs e)
        {
            //toggle between states
            datePicker.IsEnabled = !datePicker.IsEnabled;
            timePicker.IsEnabled = !timePicker.IsEnabled;
            send_now = !send_now;
        }

        private void sendToMailRoom(object sender, EventArgs e)
        {
            //toggle between states
            comboBoxReciver.IsEnabled = !comboBoxReciver.IsEnabled;
            send_to_mail_room = !send_to_mail_room;
        }

        private void requestPickup(object sender, RoutedEventArgs e)
        {
            if(send_now)
            {
                //request pickup immidiately
                pickup_time = DateTime.Now;
            }
            if(send_to_mail_room)
            {
                //send to mail room
                destination = "mail_room";
            }
            Mail mail = new Mail(destination, pickup_time, textBoxSubject.Text, textBoxNote.Text);
            SmartOfficeClient.sendMessage(5, mail); //5 is server code for mail delivery
            // var metroWindow = (_openedViews.First() as MetroWindow);
            
         //  SmartOfficeClient.sendMessage()
        //    var metroWindow = (Application.Current.MainWindow as MetroWindow);

        //    metroWindow.ShowMessageAsync("Thank you!!", "You requested a pickup to Talha Mahmood. The robot is on it's way!", MessageDialogStyle.Affirmative);


            //window.show
            //SmartOfficeClient.sendMessage(new Mail(mailDestination, mailTime, note));
        }
        
    }
}
