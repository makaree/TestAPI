using System;

namespace API_Testing_RESTful_booker.Model.JSONModel.Request
{
    /// <summary>
    /// This class defines different data types present in Booking in JSON format
    /// </summary>
    public class Booking
    {
        public string firstname { get; set; }
        public string lastname { get; set; }
        public int totalprice { get; set; }
        public bool depositpaid { get; set; }
        public Bookingdates bookingdates { get; set; }
        public string additionalneeds { get; set; }

        /// <summary>
        /// This method sets Firstname
        /// </summary>
        public void SetFirstname(string firstname)
        {
            this.firstname = firstname;
        }

        /// <summary>
        /// This method sets Lastname
        /// </summary>
        public void SetLastname(string lastname)
        {
            this.lastname = lastname;
        }

        /// <summary>
        /// This method sets total price
        /// </summary>
        public void SetTotalPrice(int totalprice)
        {
            this.totalprice = totalprice;
        }

        /// <summary>
        /// This method sets Deposit paid
        /// </summary>
        public void SetDepositPaid(bool depositpaid)
        {
            this.depositpaid = depositpaid;
        }

        /// <summary>
        /// This method sets booking dates
        /// </summary>
        public void SetBookingDates(Bookingdates bookingdates)
        {
            this.bookingdates = bookingdates;
        }

        /// <summary>
        /// This method sets Additional needs
        /// </summary>
        public void SetAdditionalNeeds(string additionalneeds)
        {
            this.additionalneeds = additionalneeds;
        }

        /// <summary>
        /// Constructor with parameters for Booking class
        /// </summary>
        public Booking(string firstname, string lastname, int totalprice, bool depositpaid, Bookingdates bookingdates, string additionalneeds)
        {
            this.firstname = firstname;
            this.lastname = lastname;
            this.totalprice = totalprice;
            this.depositpaid = depositpaid;
            this.bookingdates = bookingdates;
            this.additionalneeds = additionalneeds;
        }

        /// <summary>
        /// Converts given Datetime to string and returns string value
        /// </summary>
        public static string convertdateinstring(DateTime dateinstring)
        {
            dateinstring = dateinstring.ToLocalTime();
            return dateinstring.Year.ToString() + "-" + ((dateinstring.Month.ToString().Length > 1) ? dateinstring.Month.ToString() : "0" + dateinstring.Month.ToString()) + "-" + ((dateinstring.Day.ToString().Length > 1) ? dateinstring.Day.ToString() : "0" + dateinstring.Day.ToString());
        }

        /// <summary>
        /// Converts different parameters into booking xml format and converts the xml value to string
        /// </summary>
        public string CreateBookinginXMLFormat(string firstname, string lastname, int totalprice, bool depositpaid, Bookingdates bookingdates, string additionalneeds)
        {
            string checkindate = bookingdates.checkin.Year.ToString() + "-" + ((bookingdates.checkin.Month.ToString().Length > 1) ? bookingdates.checkin.Month.ToString() : "0" + bookingdates.checkin.Month.ToString()) + "-" + ((bookingdates.checkin.Day.ToString().Length > 1) ? bookingdates.checkin.Day.ToString() : "0" + bookingdates.checkin.Day.ToString());
            string checkoutdate = bookingdates.checkout.Year.ToString() + "-" + ((bookingdates.checkin.Month.ToString().Length > 1) ? bookingdates.checkin.Month.ToString() : "0" + bookingdates.checkin.Month.ToString()) + "-" + ((bookingdates.checkout.Day.ToString().Length > 1) ? bookingdates.checkout.Day.ToString() : "0" + bookingdates.checkout.Day.ToString());
            return ("<booking>" +
            "<firstname>" + firstname + "</firstname>" +
            "<lastname>" + lastname + "</lastname>" +
            "<totalprice>" + totalprice.ToString() + "</totalprice>" +
            "<depositpaid>" + depositpaid.ToString().ToLowerInvariant() + "</depositpaid>" +
            "<bookingdates>" +
            "<checkin>" + checkindate + "</checkin>" +
            "<checkout>" + checkoutdate + "</checkout>" +
            "</bookingdates>" +
            "<additionalneeds>" + additionalneeds + "</additionalneeds>" +
            "</booking>");
        }
        public Booking()
        {
        }

    }
}
