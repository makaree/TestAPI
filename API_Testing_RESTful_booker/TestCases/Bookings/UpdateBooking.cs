using API_Testing_RESTful_booker.HelperClass.Request;
using API_Testing_RESTful_booker.Model.JSONModel.Request;
using API_Testing_RESTful_booker.Model.JSONModel.Response;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Testing_RESTful_booker.TestCases
{
    [TestClass]
    public class UpdateBooking
    {
        private IRestResponse<AuthenticateResponse> restResponse;
        private string authurl = "https://restful-booker.herokuapp.com/auth";
        private string url = "https://restful-booker.herokuapp.com/booking";
        private string pingurl = "https://restful-booker.herokuapp.com/ping";

        /// <summary>
        /// A simple health check endpoint to confirm whether the API is up and running. 
        /// And also Creates a new auth token to use for access to the PUT and DELETE /booking
        /// </summary>
        [TestInitialize]
        public void testinitialize()
        {
            RestClientHelper RestClientHelper = new RestClientHelper();
            IRestResponse RestResponse = RestClientHelper.PerformGetRequest(pingurl, null);
            if (RestResponse.IsSuccessful)
            {
                Dictionary<string, string> header = new Dictionary<string, string>()
            {
                {"Content-Type", "application/json" }
            };
                var authenticate = new Authenticate();
                authenticate.SetUsername(Global.DEFAULT_USERNAME);
                authenticate.SetPassword(Global.DEFAULT_PASSWORD);
                RestClientHelper restClientHelper = new RestClientHelper();
                restResponse = restClientHelper.PerformPostRequest<AuthenticateResponse>(authurl, header, null, authenticate, DataFormat.Json);
            }
            else
                Assert.Fail("Could not connect to API.");
        }


        /// <summary>
        /// This test updates a current booking in the API using put request in xml format 
        /// and response format as JSON
        /// </summary>
        [TestMethod]
        [Description(@"This test updates a current booking in the API using put request in xml format" +
            "and response format as JSON. The test steps are: " +
            "\n(Step1: Make a post request to add new booking and save its bookingid" +
            "\n(Step2: Make a put request and update booking using bookingid from step1" +
            "\n(Step3: Make a get response and verify the booking has been updated")]
        public void UpdateBooking_XmlRequest_JsonResponse()
        {
            string tokenvalue = restResponse.Data.token;
            Dictionary<string, string> header = new Dictionary<string, string>()
            {
                {"Content-Type", "text/xml" },
                {"Accept", "application/json" }
            };
            Booking booking = new Booking();
            string xmlrequest = booking.CreateBookinginXMLFormat("Manisha", "Chanda", 200, true, new Bookingdates(new DateTime(2016, 02, 18), new DateTime(2017, 02, 21)), "Towel");
            RestClientHelper restClientHelper = new RestClientHelper();
            IRestResponse<BookingResponse> restresponse = restClientHelper.PerformPostRequest<BookingResponse>(url, header, null, xmlrequest, DataFormat.Xml);
            Assert.AreEqual(200, (int)restresponse.StatusCode);
            int bookingid = restresponse.Data.bookingid;

            header = new Dictionary<string, string>()
            {
                {"Content-Type", "text/xml" },
                {"Accept", "application/json" }
            };
            xmlrequest = booking.CreateBookinginXMLFormat("Manu", "Chandu", 150, false, new Bookingdates(new DateTime(2016, 02, 19), new DateTime(2017, 02, 20)), "Towel not needed");
            RestClientHelper restClientHelper1 = new RestClientHelper();
            IRestResponse<Booking> restresponse1 = restClientHelper1.PerformPutRequest<Booking>(url+"/" + bookingid, header, tokenvalue, xmlrequest, DataFormat.Xml);
            Assert.AreEqual(200, (int)restresponse1.StatusCode);

            header = new Dictionary<string, string>()
            {
                {"Accept", "application/json" }
            };
            RestClientHelper restClientHelper2 = new RestClientHelper();
            IRestResponse<Booking> restresponse2 = restClientHelper2.PerformGetRequest<Booking>(url + "/" + bookingid, header);
            Assert.AreEqual(200, (int)restresponse2.StatusCode);
            Assert.IsNotNull(restresponse2.Content, "Rest response is null");
            Assert.IsTrue(restresponse2.Data.firstname.Contains("Manu"), "Firstname is not updated ");
            Assert.IsTrue(restresponse2.Data.lastname.Contains("Chandu"), "Lastname is not updated");
            Assert.AreEqual(150,restresponse2.Data.totalprice, "Total price is not updated");
            Assert.AreNotEqual(false,restresponse2.Data.depositpaid, "Deposit paid should not be updated.");
            Assert.AreEqual("2016-02-19", Booking.convertdateinstring(restresponse2.Data.bookingdates.checkin), "Checkin date is not updated");
            Assert.AreEqual("2017-02-20", Booking.convertdateinstring(restresponse2.Data.bookingdates.checkout), "Checkout date is not updated");
            Assert.IsTrue(restresponse2.Data.additionalneeds.Contains("Towel not needed"), "Additional needs is not updated");
        }

    }
}
