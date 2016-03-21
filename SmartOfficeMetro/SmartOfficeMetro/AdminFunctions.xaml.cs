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
using System.Data;

namespace SmartOfficeMetro
{
    /// <summary>
    /// Interaction logic for AdminFunctions.xaml
    /// </summary>
    public partial class AdminFunctions : UserControl
    {
        DataTable logged_in_users = new DataTable();
        public AdminFunctions()
        {
            InitializeComponent();
            logged_in_users.Columns.Add("User ID");
            logged_in_users.Columns.Add("User Name");
            logged_in_users.Columns.Add("Disconnect User");
            logged_in_users.Rows.Add(new object[] { "test", "test", "test" });

            foreach(Robot robot in AdminManager.Instance.robot_list)
            {
                Tile_Battery_Info robot_tile = new Tile_Battery_Info(robot);
                robot_tile.HorizontalAlignment = HorizontalAlignment.Stretch;
                robot_tile.Width = Double.NaN;  //to automatically set it to auto width
                stackPanelBattery.Children.Add(robot_tile);
            }
            availableUserGrid.DataContext = logged_in_users.DefaultView;
            
        }

        private void Disconnect_button_Click(object sender, RoutedEventArgs e)
        {
            String username = ((Button)sender).Tag.ToString();
            SmartOfficeClient.sendMessage(11, username);
        }

        public void Update_UI()
        {
            stackPanelBattery.Children.Clear();
            foreach (Robot robot in AdminManager.Instance.robot_list)
            {
                Tile_Battery_Info robot_tile = new Tile_Battery_Info(robot);
                robot_tile.HorizontalAlignment = HorizontalAlignment.Stretch;
                robot_tile.Width = Double.NaN;  //to automatically set it to auto width
                stackPanelBattery.Children.Add(robot_tile);
            }//foreach robot battery

            //logged in user data table
            try
            {
                foreach (String user in AdminManager.Instance.logged_in_users)
                {
                    String id = "";
                    //add a disconnect user button and assign it a tag of username which can be used to disconnect user
                    Button disconnect_button = new Button();
                    disconnect_button.Content = "Disconnect";
                    disconnect_button.Tag = user;
                    disconnect_button.Click += Disconnect_button_Click;
                    //perform a data search in local table for user ID
                    foreach (List<String> u in UserManager.Instance.user_details)
                    {
                        if (u.ElementAt(1) == user)
                        {
                            id = u.ElementAt(0);
                            break;
                        }//if
                    }//foreach find user id
                    logged_in_users.Rows.Add(new object[] { id, user, disconnect_button });
                }//foreach populate logged in users
                System.Diagnostics.Debug.WriteLine("I came here once");
            }
            catch(NullReferenceException ex)
            {
                //null reference occuers if the application hasn't heard from the server yet
                // due to maybe latency, in this case we ignore it and wait for another update to happen
            }

        }//update
    }//class
}//namespace
