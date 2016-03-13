using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SmartOfficeMetro
{
    public class User
    {
        public String username;
        public String password;
        public String Name;
        public int age;
        public Image image;
        public Boolean notification;

        public User(String username, String password, String Name, Image image)
        {
            this.username = username;
            this.password = password;
            this.Name = Name;
            
            this.image = image;
            this.notification = false;
        }




    }
}
