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
using MahApps.Metro;
using System.ComponentModel;
using System.Globalization;
using System.Threading;
using MahApps.Metro.Controls.Dialogs;
using System.Windows.Forms;
using NetworksApi.TCP.CLIENT;
using System.Net;
using System.Net.Sockets;
namespace SmartOfficeMetro
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    ///

    

    public partial class MainWindow : MetroWindow
    {
        User currentUser = null;
        String imageSource;
        public string imgSrc { get { return imageSource; } set { imageSource = value; } }
        private System.Windows.Controls.Control currentControl;
       // MainDelivery window = null;
        System.Windows.Forms.NotifyIcon notifyIcon;
        System.Windows.Forms.ContextMenu notifyContextMenu;
        
        

        public MainWindow(User user)
        {
            InitializeComponent();
            this.currentUser = user;

           
            //set image
            BitmapImage logo = new BitmapImage();
            logo.BeginInit();
            logo.UriSource = new Uri("pack://application:,,,/SmartOfficeMetro;component/../../UserImages/" + currentUser.image.Tag);
            logo.EndInit();
            imageUserIcon.Source = logo;

            imageUserIcon.DataContext = imgSrc;
            //Set welcome message
            labelWelcome.Content = "Welcome, " + currentUser.Name + "!";

            //notify icon image
            System.Drawing.Icon icon = Properties.Resources.favicon;

            //Init notifyIcon
            notifyIcon = new System.Windows.Forms.NotifyIcon();
            notifyIcon.Icon = Properties.Resources.favicon;
            notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(notifyIcon_MouseDoubleClick);
           
            //Init context menu for notification tray!
            notifyContextMenu = new System.Windows.Forms.ContextMenu();
            System.Windows.Forms.MenuItem item1= new System.Windows.Forms.MenuItem();
            item1.Text = "hello";
            notifyContextMenu.MenuItems.Add(item1);
            notifyIcon.ContextMenu = notifyContextMenu;
            // notifyContextMenu.

            //start connection with server!
            

            //deal with a closing event to kill threads
            this.Closed += MainWindow_Closed;

        }

        private void MainWindow_Closed(object sender, EventArgs e)
        {
            System.Environment.Exit(System.Environment.ExitCode);
        }

        private void notifyIcon_MouseDoubleClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
                this.WindowState = WindowState.Maximized;
        }

        private void radioButtonGreen_Checked(object sender, RoutedEventArgs e)
        {
            ThemeManager.ChangeAppStyle(System.Windows.Application.Current, ThemeManager.GetAccent("Green"), ThemeManager.DetectAppStyle().Item1);
        }

        private void radioButtonBlue_Checked(object sender, RoutedEventArgs e)
        {
            ThemeManager.ChangeAppStyle(System.Windows.Application.Current, ThemeManager.GetAccent("Blue"), ThemeManager.DetectAppStyle().Item1);
        }

        private void radioButtonRed_Checked(object sender, RoutedEventArgs e)
        {
            ThemeManager.ChangeAppStyle(System.Windows.Application.Current, ThemeManager.GetAccent("Red"), ThemeManager.DetectAppStyle().Item1);
            
        }

        private void showSettings_Click(object sender, RoutedEventArgs e)
        {
            var flyout = this.Flyouts.Items[0] as Flyout;
            if(flyout == null)
            {
                return;
            }
            //switch between open and close states(true,false)
            flyout.IsOpen = !flyout.IsOpen;
        }
        private void showMainDelivery(object sender, RoutedEventArgs e)
        {
            showUserControl(new MainDelivery());
            /*
            if(window == null)
            {
                window = new MainDelivery();
            }
             
            currentControl = window;
            //Init User control dimensions 
            currentControl.Height = dockPanel.Height;
            currentControl.Width = dockPanel.Width;
            //clear current panel
            dockPanel.Children.Clear();
            //add User control
            dockPanel.Children.Add(currentControl);
            */
            
        }
        private void showPopup(object sender, RoutedEventArgs e)
        {
         //   popUp.ShowBalloonTip("Hi", imageSource, Hardcodet.Wpf.TaskbarNotification.BalloonIcon.Info);
        }

        private void orderCoffee(object sender, RoutedEventArgs e)
        { 
            SmartOfficeClient.sendMessage("I need coffee");
           
        }

       
        //To minimize window to taskbar!
        private void MetroWindow_StateChanged(object sender, EventArgs e)
        {
            if (this.WindowState == WindowState.Minimized)
            {
                this.ShowInTaskbar = false;
                popUp.ShowBalloonTip("Minimized!","just got minimized!",Hardcodet.Wpf.TaskbarNotification.BalloonIcon.Info);
                notifyIcon.Visible = true;
            }
            else if (this.WindowState == WindowState.Maximized)
            {
                notifyIcon.Visible = false;
                this.ShowInTaskbar = true;
            }
            else
            {
                this.WindowState = WindowState.Maximized; 
            }
        } //state changed

        public void showUserControl(System.Windows.Controls.UserControl control)
        {
            currentControl = control;
            //Init User control dimensions 
            currentControl.Height = dockPanel.Height;
            currentControl.Width = dockPanel.Width;
            //clear current panel
            dockPanel.Children.Clear();
            //add User control
            dockPanel.Children.Add(currentControl);
            
        }

    } // main window
   
}// namespace
