﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOfficeServer.Model
{

    /// <summary>
    /// Converts an object to a JSON object accompnied with a requestType identifier
    /// </summary>
    class JSONObject
    {

        public int requestType;
        public Object info;

        /// <summary>
        /// Converts an object to a JSON object accompnied with a requestType identifier
        /// </summary>
        /// <param name="requestType">1: Notifications(Any kind) 2: Coffee 3: Login request 4: Mail request 5: BLANK 6: Initial user Data 7: delivery history 8: notification history </param>
        /// <param name="information">The data to be passed</param>
        public JSONObject(int requestType, Object information)
        {
            this.requestType = requestType;
            info = information;     
        }
    }// JSON object

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

    class User
    {
        public String id;
        public String username;
        public String password;
        public String Name;
        public String age;
        public String email;
        public String phone;
        public String department;
        public String image;
        public Boolean notification;
        
        public User(String username, String password)
        {
            
            this.username = username;
            this.password = password;
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
    class loginObject
    {
        public Boolean loginStatus;
        public User user;
        public loginObject(Boolean loginStatus, User user)
        {
            this.loginStatus = loginStatus;
            this.user = user;
        }
    }//login

    public class Destination
    {
        public String destination;
        public Destination(String destination)
        {
            this.destination = destination;
        }
        public override String ToString()
        {
            return destination;
        }
    }// destination

    public class Initial_data
    {
        List<List<String>> users;
        List<List<String>> delivery;
        List<List<String>> notification;
        public Initial_data(List<List<String>> users, List<List<String>> delivery, List<List<String>> notification)
        {
            this.users = users;
            this.delivery = delivery;
            this.notification = notification;
        }
    }
}
