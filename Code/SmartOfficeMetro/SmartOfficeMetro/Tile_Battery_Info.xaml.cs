
using System.ComponentModel;

using System.Windows;
using System.Windows.Controls;

using SmartOfficeMetro.Model;
using System.Threading;
namespace SmartOfficeMetro
{
    /// <summary>
    /// Interaction logic for Tile_Battery_Info.xaml
    /// </summary>
    public partial class Tile_Battery_Info : UserControl, INotifyPropertyChanged
    {
        Robot robot;
        public double BatteryLevel { get; set; }    //battery level of robot. Property
        public double Remaining_Battery_Time { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        System.Timers.Timer update_battery = new System.Timers.Timer(12000);
        SynchronizationContext update_context = SynchronizationContext.Current;
        public Tile_Battery_Info(Robot robot)
        {
            InitializeComponent();
            this.robot = robot;
            robotID.Content = "Robot " + this.robot.id;
            BatteryLevel = this.robot.battery_level;
            Remaining_Battery_Time = BatteryLevel * 1.75;
            update_battery.Elapsed += Update_battery_Elapsed;
            
            
            DataContext = this;
        }
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        private void Update_battery_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
        //find battery level and update property
            foreach(Robot robot in AdminManager.Instance.robot_list)
            {
                if(robot.id == this.robot.id)
                {
                    BatteryLevel = robot.battery_level;
                    break;
                }
            }//foreach
             //using randome battery drain factor for now
            Remaining_Battery_Time = BatteryLevel * 1.75;
            NotifyPropertyChanged("BatteryLevel");
            NotifyPropertyChanged("Remaining_Battery_Time");
        }

        private void recallButton_Click(object sender, RoutedEventArgs e)
        {
            //server code to recall is 10
            SmartOfficeClient.sendMessage(10, robot.id);
        }
    }
}
