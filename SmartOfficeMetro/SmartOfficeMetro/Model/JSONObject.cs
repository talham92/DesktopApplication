using System;
using System.Collections.Generic;
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

    }
}
