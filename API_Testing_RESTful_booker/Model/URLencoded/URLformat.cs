using API_Testing_RESTful_booker.Model.JSONModel.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Testing_RESTful_booker.Model.URLencoded
{
    public class URLformat
    {
        public string SerializeURLformat(string firstname, string lastname, int totalprice, bool depositpaid, Bookingdates bookingdates)
        {
            string checkindate = bookingdates.checkin.Year.ToString() + "-" + bookingdates.checkin.Month.ToString() + "-" + bookingdates.checkin.Day.ToString();
            string checkoutdate = bookingdates.checkout.Year.ToString() + "-" + bookingdates.checkout.Month.ToString() + "-" + bookingdates.checkout.Day.ToString();

            return ("firstname="+ firstname+"&lastname="+ lastname +"&totalprice="+ totalprice.ToString()+"&depositpaid="+ depositpaid.ToString().ToLowerInvariant() + "&bookingdates%5Bcheckin%5D="+checkindate+"&bookingdates%5Bcheckout%5D="+ checkoutdate);
        }
        //

        public string SerializeURLformatWithBookindID(int bookingid,string firstname, string lastname, int totalprice, bool depositpaid, Bookingdates bookingdates)
        {
            string checkindate = bookingdates.checkin.Year.ToString() + "-" + bookingdates.checkin.Month.ToString() + "-" + bookingdates.checkin.Day.ToString();
            string checkoutdate = bookingdates.checkout.Year.ToString() + "-" + bookingdates.checkout.Month.ToString() + "-" + bookingdates.checkout.Day.ToString();

            return ("bookingid="+bookingid.ToString()+ "&booking%5Bfirstname%5D=" + firstname + "&booking%5Blastname%5D=" + lastname + "&booking%5Btotalprice%5D=" + totalprice.ToString() + "&booking%5Bdepositpaid%5D=" + depositpaid.ToString().ToLowerInvariant() + "&booking%5Bbookingdates%5D%5Bcheckin%5D=" + checkindate + "&booking%5Bbookingdates%5D%5Bcheckout%5D=" + checkoutdate); 
        }
    }
}
