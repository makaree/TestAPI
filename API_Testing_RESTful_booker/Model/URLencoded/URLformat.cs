using API_Testing_RESTful_booker.Model.JSONModel.Request;

namespace API_Testing_RESTful_booker.Model.URLencoded
{
    /// <summary>
    /// This class helps to serialize data into URL encoded format
    /// </summary>
    public class URLformat
    {
        /// <summary>
        /// Returns as object for Booking class type, and serializes it to URL format.
        /// </summary>
        public static object SerializeURLformat(string firstname, string lastname, int totalprice, bool depositpaid, Bookingdates bookingdates)
        {
            string checkindate = bookingdates.checkin.Year.ToString() + "-" + ((bookingdates.checkin.Month.ToString().Length > 1) ? bookingdates.checkin.Month.ToString() : "0" + bookingdates.checkin.Month.ToString()) + "-" + ((bookingdates.checkin.Day.ToString().Length > 1) ? bookingdates.checkin.Day.ToString() : "0" + bookingdates.checkin.Day.ToString());
            string checkoutdate = bookingdates.checkout.Year.ToString() + "-" + ((bookingdates.checkin.Month.ToString().Length > 1) ? bookingdates.checkin.Month.ToString() : "0" + bookingdates.checkin.Month.ToString()) + "-" + ((bookingdates.checkout.Day.ToString().Length > 1) ? bookingdates.checkout.Day.ToString() : "0" + bookingdates.checkout.Day.ToString());
            return ($"firstname=" + firstname + "&lastname=" + lastname + "&totalprice=" + totalprice.ToString() + "&depositpaid=" + depositpaid.ToString().ToLowerInvariant() + "&bookingdates%5Bcheckin%5D=" + checkindate + "&bookingdates%5Bcheckout%5D=" + checkoutdate);
        }

        /// <summary>
        /// Returns as object for BookingID class type, and serializes it to URL format.
        /// </summary>
        public static object SerializeURLformatWithBookID(int bookingid, string firstname, string lastname, int totalprice, bool depositpaid, Bookingdates bookingdates)
        {
            string checkindate = bookingdates.checkin.Year.ToString() + "-" + ((bookingdates.checkin.Month.ToString().Length > 1) ? bookingdates.checkin.Month.ToString() : "0" + bookingdates.checkin.Month.ToString()) + "-" + ((bookingdates.checkin.Day.ToString().Length > 1) ? bookingdates.checkin.Day.ToString() : "0" + bookingdates.checkin.Day.ToString());
            string checkoutdate = bookingdates.checkout.Year.ToString() + "-" + ((bookingdates.checkin.Month.ToString().Length > 1) ? bookingdates.checkin.Month.ToString() : "0" + bookingdates.checkin.Month.ToString()) + "-" + ((bookingdates.checkout.Day.ToString().Length > 1) ? bookingdates.checkout.Day.ToString() : "0" + bookingdates.checkout.Day.ToString());
            return ($"bookingid=" + bookingid.ToString() + "&booking%5Bfirstname%5D=" + firstname + "&booking%5Blastname%5D=" + lastname + "&booking%5Btotalprice%5D=" + totalprice.ToString() + "&booking%5Bdepositpaid%5D=" + depositpaid.ToString().ToLowerInvariant() + "&booking%5Bbookingdates%5D%5Bcheckin%5D=" + checkindate + "&booking%5Bbookingdates%5D%5Bcheckout%5D=" + checkoutdate);
        }
    }
}
