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
using System.Threading;

namespace SmartOfficeMetro
{
    /// <summary>
    /// Interaction logic for Notifications.xaml
    /// </summary>
    public partial class Notifications : UserControl
    {

        static int counter = 0;
        SynchronizationContext context;
        System.Timers.Timer remove;
        public Notifications()
        {
            InitializeComponent();
            
            //populate notifications with dummy data
            UserManager.Instance.current_notifications.Enqueue(new Notification("Naorin", "Balance Sheet", "Hey!\n I am sending you the current balance sheet, could you please take a look at it? \n\nThanks!"));
            UserManager.Instance.current_notifications.Enqueue(new Notification("MAIL ROOM", "You have mail in the office", "Hey!\n You have mail in the office. Please press let us know when we can deliver it. \n Regards, \n Poornima"));
            UserManager.Instance.current_notifications.Enqueue(new Notification("Poornima", "Parts List", "Hey!\n\n I am sending you the parts list, could you please take a look at it? \n\nThanks!"));
            UserManager.Instance.current_notifications.Enqueue(new Notification("Terrell", "Pen", "Your Pen"));
            UserManager.Instance.current_notifications.Enqueue(new Notification("Raghav", "Network Update", "network updated"));
            UserManager.Instance.current_notifications.Enqueue(new Notification("Thinh", "UI Mockup", "Hey!\n\n I am sending you the UI mockup, could you please take a look at it? \n\nThanks!"));
            updateUI();

            remove = new System.Timers.Timer();
            remove.Interval = 50;
            remove.Elapsed += Remove_Elapsed;

            //get main UI thread
            context = SynchronizationContext.Current;
        }

        

        private void Tile_MouseEnter(object sender, MouseEventArgs e)
        {
           // NotificationTile tile = sender as NotificationTile;
            //tile.Background = SystemColors.HighlightBrushKey as System.Windows.Media.Brush;
        }

        private void clearAll_Click(object sender, RoutedEventArgs e)
        {
            /*
            counter = 0;
            Thread t = new Thread(()=>remove.Start());
            t.Start();
            t.Join();
            */
            UserManager.Instance.current_notifications.Clear();
            stackPanelNotifications.Children.Clear();
            
            
             
            
            
        }
        private void Remove_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            context.Post(new SendOrPostCallback(new Action<object>(o => {
                Thickness margin = stackPanelNotifications.Margin;
                margin.Left += 250;
                stackPanelNotifications.Margin = margin;
                this.InvalidateVisual();
            })), null);
            counter++;
            if (counter == 6)
                remove.Stop();
        }
        private void updateUI()
        {
            foreach (Notification notification in UserManager.Instance.current_notifications)
            {
                NotificationTile tile = new NotificationTile(notification.sender, notification.subject, notification.description);
                tile.HorizontalAlignment = HorizontalAlignment.Stretch;
                tile.Width = Double.NaN;
                tile.MouseEnter += Tile_MouseEnter;
                stackPanelNotifications.Children.Add(tile);
            }
            UserManager.Instance.current_notifications.Clear();     //Clear current notifications after displaying them
            stackPanelNotifications.Margin = new Thickness(0);
            
        }
    }
}
