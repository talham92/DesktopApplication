using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOfficeMetro.Model
{
    class JSONObject
    {
    }
    class Mail
    {
        String mailDestination;
        String mailTime;
        String note;
        public Mail(String mailDestination, String mailTime, String note)
        {
            this.mailDestination = mailDestination;
            this.mailTime = mailTime;
            this.note = note;
        }
    }//mail

    class UserLogin
    {
        public String username;
        public String password;
        public String Name;
        public int age;
        public Image image;
        public Boolean notification;

        public UserLogin(String username, String password, String Name, Image image)
        {
            this.username = username;
            this.password = password;
            this.Name = Name;

            this.image = image;
            this.notification = false;
        }
    }// user login

    class Notification
    {
        public String sender;
        public String subject;
        public String description;

        public Notification(String sender, String subject, String description)
        {
            this.sender = sender;
            this.subject = subject;
            this.description = description;
        }
    }
}
