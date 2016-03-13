using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
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

namespace SmartOfficeMetro
{
    /// <summary>
    /// Interaction logic for MainDelivery.xaml
    /// </summary>
    public partial class MainDelivery : UserControl
    {
        // TcpClientTest client;
        MainWindow mainWindow = null;
        public MainDelivery()
        {
            InitializeComponent();
          //  client = new TcpClientTest();
          
        }

        private void orderCoffee(object sender, RoutedEventArgs e)
        {
           // SmartOfficeClient.sendMessage("Coffee"); 
        }

        private void mailService(object sender, RoutedEventArgs e)
        {
            if (mainWindow == null)
                mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow.showUserControl(new MailService());
            
        }


    }
}
