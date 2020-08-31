using System;

namespace API_Testing_RESTful_booker.Model.JSONModel.Request
{
    /// <summary>
    /// This class defines different data types present in BookingDates in JsON format
    /// </summary>
    public class Bookingdates
    {
        public DateTime checkin { get; set; }
        public DateTime checkout { get; set; }

        /// <summary>
        /// Constructor of Bookingdates class with parameters checkin and checkout date
        /// </summary>
        public Bookingdates(DateTime checkin, DateTime checkout)
        {
            this.checkin = checkin.Date.ToLocalTime();
            this.checkout = checkout.Date.ToLocalTime();
        }
        public Bookingdates()
        { }
    }
}
