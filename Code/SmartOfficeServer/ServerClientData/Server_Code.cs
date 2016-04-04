using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerClientData
{
    public enum Server_Code
    {
        //1: Notifications(Any kind) 2: Coffee 3: Login request 4: Mail request 5: BLANK 6: Initial user Data 7: delivery history 8: notification history 10:recall robot
        Coffee,
        Login_Request,
        Mail_Request,
        Delivery_Request,
        Initial_User_Data,
        Delivery_History,
        Notification_History,
        Admin_Data,
        Recall_Robot
    }
}
