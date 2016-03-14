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

namespace SmartOfficeMetro
{
    /// <summary>
    /// Interaction logic for NotificationTile.xaml
    /// </summary>
    public partial class NotificationTile : UserControl
    {
        Boolean expanded;
        public NotificationTile(String sender, String header, String description)
        {
            InitializeComponent();

            //Add subject description along with click description
            labelHeader.MouseLeftButtonDown += LabelHeader_MouseLeftButtonDown;
            labelHeader.Content = header;

            //Add body description to the tile
            labelDescription.Content = description;

            //Add sender name and it's assosiated click event
            labelSender.Content = sender;
            labelSender.MouseLeftButtonDown += LabelHeader_MouseLeftButtonDown;

            descriptionPanel.Visibility = Visibility.Collapsed;
            expanded = false;
        }

        private void LabelHeader_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //expander.IsExpanded = !expander.IsExpanded;
            if(!expanded)
            {
                this.Height += 200;
                descriptionPanel.Visibility = Visibility.Visible;
                descriptionPanel.Margin = new Thickness(0, 50, 0, 0);
                
                expanded = true;
            }
            else
            {
                this.Height -= 200;
                descriptionPanel.Visibility = Visibility.Collapsed;
                descriptionPanel.Margin = new Thickness(0, 0, 0, 0);
                
                expanded = false;
            }

            //MetroWindow w = new MetroWindow();
            //ThemeManager.GetAccent();

        }
    }
}
