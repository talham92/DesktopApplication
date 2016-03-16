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
using MahApps;
using MahApps.Metro.Controls;
using MahApps.Metro;
using System.Timers;
using System.Threading;

namespace SmartOfficeMetro
{
    /// <summary>
    /// Interaction logic for NotificationTile.xaml
    /// </summary>
    public partial class NotificationTile : UserControl
    {
        Boolean expanded;
        static int counter;
        System.Timers.Timer expand;
        System.Timers.Timer compress;
        SynchronizationContext context = SynchronizationContext.Current;
        public NotificationTile(String sender, String header, String description)
        {
            InitializeComponent();

            //Add subject description along with click description
            labelHeader.MouseLeftButtonDown += LabelHeader_MouseLeftButtonDown;
            labelHeader.Content = header;

            //Add body description to the tile
            labelDescription.Content = description;
            labelDescription.MouseLeftButtonDown += LabelHeader_MouseLeftButtonDown;

            //Add sender name and it's assosiated click event
            labelSender.Content = sender;
            labelSender.MouseLeftButtonDown += LabelHeader_MouseLeftButtonDown;

            descriptionPanel.Visibility = Visibility.Collapsed;
            expanded = false;

            expand = new System.Timers.Timer();
            expand.Interval = 25;
            expand.Elapsed += T_Elapsed;

            compress = new System.Timers.Timer();
            compress.Interval = 25;
            compress.Elapsed += Compress_Elapsed;
        }

        private void LabelHeader_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //expander.IsExpanded = !expander.IsExpanded;
            
            counter = 0;
            


            if(!expanded)
            {
                if(this.Height > 150)
                {
                    this.Height = 150;
                }

                try
                {
                    expand.Start();
                }
                catch(Exception ex)
                {
                    this.Height = 150;
                    counter = 0;
                    expand.Stop();
                }
                descriptionPanel.Visibility = Visibility.Visible;
                descriptionPanel.Margin = new Thickness(0, 0, 0, 0);
                expanded = true;
            }
            else
            {
                
                try
                {
                    compress.Start();
                }
                catch(Exception ex)
                {
                    this.Height = 30;
                    counter = 0;
                    compress.Stop();
                }
                descriptionPanel.Visibility = Visibility.Collapsed;
                descriptionPanel.Margin = new Thickness(0, 0, 0, 0);
                expanded = false;
            }

            //MetroWindow w = new MetroWindow();
            //ThemeManager.GetAccent();

        }//button click

        private void Compress_Elapsed(object sender, ElapsedEventArgs e)
        {
            context.Post(new SendOrPostCallback(new Action<object>(o => {
                
                this.Height -= 20;
            })), null);
            counter++;
            if (counter == 6)
                compress.Stop();
        }

        private void T_Elapsed(object sender, ElapsedEventArgs e)
        {
            context.Post(new SendOrPostCallback(new Action<object>(o => {
                this.Height += 20;
            })), null);
            counter++;
            if (counter == 6)
                expand.Stop();
        }
    }
}
