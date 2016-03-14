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
using SmartOfficeMetro.Model;
namespace SmartOfficeMetro
{
    /// <summary>
    /// Interaction logic for Notifications.xaml
    /// </summary>
    public partial class Notifications : UserControl
    {
        List<Notification> notifications;

        public Notifications()
        {
            InitializeComponent();
            notifications = new List<Notification>();
            //populate notifications with data
            notifications.Add(new Notification("Naorin", "Balance Sheet", "Hey!\n I am sending you the current balance sheet, could you please take a look at it? \n\nThanks!"));
            notifications.Add(new Notification("MAIL ROOM", "You have mail in the office", "Hey!\n You have mail in the office. Please press let us know when we can deliver it. \n Regards, \n Poornima"));
            notifications.Add(new Notification("Poornima", "Parts List", "Hey!\n\n I am sending you the parts list, could you please take a look at it? \n\nThanks!"));
            notifications.Add(new Notification("Terrell", "Pen", "Your Pen"));
            notifications.Add(new Notification("Raghav", "Network Update", "network updated"));
            notifications.Add(new Notification("Thinh", "UI Mockup", "Hey!\n\n I am sending you the UI mockup, could you please take a look at it? \n\nThanks!"));

            foreach(Notification notification in notifications)
            {
                NotificationTile tile = new NotificationTile(notification.sender, notification.subject, notification.description);
                tile.HorizontalAlignment = HorizontalAlignment.Stretch;
                tile.Width = Double.NaN;
                tile.MouseEnter += Tile_MouseEnter; 
                stackPanelNotifications.Children.Add(tile);
            }
        }

        private void Tile_MouseEnter(object sender, MouseEventArgs e)
        {
            NotificationTile tile = sender as NotificationTile;
            //tile.Background = SystemColors.HighlightBrushKey as System.Windows.Media.Brush;
        }
    }
}
