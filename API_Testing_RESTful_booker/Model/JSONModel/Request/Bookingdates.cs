using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Testing_RESTful_booker.Model.JSONModel.Request
{
    public class Bookingdates
    {
        public DateTime checkin { get; set; }
        public DateTime checkout { get; set; }
        public Bookingdates(DateTime checkin, DateTime checkout)
        {
            this.checkin = checkin;
            this.checkout = checkout;
        }
        public Bookingdates()
        { }
    }
}
