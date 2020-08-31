using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Testing_RESTful_booker
{
    /// <summary>
    /// This class consists different urlendpoints
    /// </summary>
    public class URLEndPoint
    {
        public static string url = "https://restful-booker.herokuapp.com/";
        public static string pingurl = url + "ping";
        public static string authurl = url + "auth";
        public static string bookingurlforquery = url + "booking";
        public static string bookingurl = url + "booking/";
    }
}
