using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Configuration;

namespace QHMobile
{
    public class QHWebservices
    {
        public static NetworkCredential WebServiceAuthentication()
        {
            NetworkCredential nc = new NetworkCredential();
            //nc.Domain = "dpte";
            //nc.UserName = ConfigurationManager.AppSettings["USERNAME"].ToString();
            //nc.Password = ConfigurationManager.AppSettings["PASSWORD"].ToString();
            return nc;
        }


    }
}
