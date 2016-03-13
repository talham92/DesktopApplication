using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using System.Drawing;
using System.Windows;

namespace SmartOfficeMetro
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : MetroWindow
    {
        SmartOfficeClient client;
        public Login()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, RoutedEventArgs e)
        {
            String username = textBoxUsername.Text;
            String password = passwordBox.Password;
            String Name = "Garfield"; //need to get from database later!
            Image image = resizeImage(SmartOfficeMetro.Properties.Resources.kitten_2, new System.Drawing.Size(100,100));
            image.Tag = "kitten-2.jpg"; //image name to be used later!!
            User loginUser = new User(username,password,Name,image);

            //Create Client of user
            client = new SmartOfficeClient(loginUser);

            MainWindow createDisplay = new MainWindow(loginUser);
            Application.Current.MainWindow = createDisplay;
            this.Close();
            createDisplay.Show();
            
        }

        private Image resizeImage(Image image, System.Drawing.Size size)
        {
            return (Image)(new Bitmap(image, size));
        }
    }

}
