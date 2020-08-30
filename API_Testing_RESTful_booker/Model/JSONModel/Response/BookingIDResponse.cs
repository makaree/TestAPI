using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Testing_RESTful_booker.Model.JSONModel.Response
{
    public class BookingIDs
    {
        public int bookingid { get; set; }
    }

    public class BookingIDResponse
    {
        public List<BookingIDs> bookingIDs { get; set; }
    }
}
