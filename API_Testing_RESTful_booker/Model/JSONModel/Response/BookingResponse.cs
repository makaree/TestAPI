using API_Testing_RESTful_booker.Model.JSONModel.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Testing_RESTful_booker.Model.JSONModel.Response
{
    public class BookingResponse
    {
        public int bookingid { get; set; }
        public Booking booking { get; set; }
        public void SetBookingiId(int bookingid)
        {
            this.bookingid = bookingid;
        }

        public void SetBooking(Booking booking)
        {
            this.booking = booking;
        }
    }
}
