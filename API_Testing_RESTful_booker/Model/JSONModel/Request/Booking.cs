using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Testing_RESTful_booker.Model.JSONModel.Request
{

    public class Booking
    {
        public string firstname { get; set; }
        public string lastname { get; set; }
        public int totalprice { get; set; }
        public bool depositpaid { get; set; }
        public Bookingdates bookingdates { get; set; }
        public string additionalneeds { get; set; }
        public void SetFirstname(string firstname)
        {
            this.firstname = firstname;
        }

        public void SetLastname(string lastname)
        {
            this.lastname = lastname;
        }

        public void SetTotalPrice(int totalprice)
        {
            this.totalprice = totalprice;
        }

        public void SetDepositPaid(bool depositpaid)
        {
            this.depositpaid = depositpaid;
        }

        public void SetBookingDates(Bookingdates bookingdates)
        {
            this.bookingdates = bookingdates;
        }

        public void SetAdditionalNeeds(string additionalneeds)
        {
            this.additionalneeds = additionalneeds;
        }

        public Booking(string firstname, string lastname, int totalprice, bool depositpaid, Bookingdates bookingdates, string additionalneeds)
        {
            this.firstname = firstname;
            this.lastname = lastname;
            this.totalprice = totalprice;
            this.depositpaid = depositpaid;
            this.bookingdates = bookingdates;
            this.additionalneeds = additionalneeds;
        }
        public static string convertdateinstring(DateTime dateinstring)
        {
            dateinstring = dateinstring.ToLocalTime();
            return dateinstring.Year.ToString() + "-" + ((dateinstring.Month.ToString().Length > 1) ? dateinstring.Month.ToString() : "0" + dateinstring.Month.ToString()) + "-" + ((dateinstring.Day.ToString().Length > 1) ? dateinstring.Day.ToString() : "0" + dateinstring.Day.ToString());
        }

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
