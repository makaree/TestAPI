using System.Collections.Generic;

namespace API_Testing_RESTful_booker.Model.JSONModel.Response
{
    /// <summary>
    /// This class defines different data types present in BookingID in JSON format
    /// </summary>
    public class BookingIDs
    {
        public int bookingid { get; set; }
    }

    /// <summary>
    /// This class defines different data types present in BookingIDResponse in JSON format
    /// </summary>
    public class BookingIDResponse
    {
        public List<BookingIDs> bookingIDs { get; set; }
    }
}
