using API_Testing_RESTful_booker.Model.JSONModel.Request;

namespace API_Testing_RESTful_booker.Model.JSONModel.Response
{
    /// <summary>
    /// This class defines different data types present in BookingResponse in JSON format
    /// </summary>
    public class BookingResponse
    {
        public int bookingid { get; set; }
        public Booking booking { get; set; }

        /// <summary>
        /// This method sets Booking ID
        /// </summary>
        public void SetBookingiId(int bookingid)
        {
            this.bookingid = bookingid;
        }

        /// <summary>
        /// This method sets Booking class
        /// </summary>
        public void SetBooking(Booking booking)
        {
            this.booking = booking;
        }
    }
}
