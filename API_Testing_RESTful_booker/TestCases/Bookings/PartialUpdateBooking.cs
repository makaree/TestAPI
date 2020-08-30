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
    public class PartialUpdateBooking
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
        /// This test updates a Updates a current booking with a partial payload using patch request 
        /// </summary>
        [TestMethod]
        [Description(@"This test updates a Updates a current booking with a partial payload using patch request" +
            "The test steps are: " +
            "\n(Step1: Make a post request to add new booking and save its bookingid" +
            "\n(Step2: Make a patch request and update booking using bookingid from step1" +
            "\n(Step3: Make a get response and verify the booking has been updated")]
        public void UpdatePartialBooking_JsonRequest_JsonResponse()
        {
            string tokenvalue = restResponse.Data.token;
            Dictionary<string, string> header = new Dictionary<string, string>()
            {
                {"Content-Type", "text/xml" },
                {"Accept", "application/json" }
            };
            Booking booking = new Booking("Manisha", "Chanda", 200, true, new Bookingdates(new DateTime(2016, 02, 18), new DateTime(2017, 02, 21)), "Towel");
            string xmlrequest = booking.CreateBookinginXMLFormat(booking.firstname,booking.lastname,booking.totalprice,booking.depositpaid,booking.bookingdates,booking.additionalneeds);
            RestClientHelper restClientHelper = new RestClientHelper();
            IRestResponse<BookingResponse> restresponse = restClientHelper.PerformPostRequest<BookingResponse>(url, header, null, xmlrequest, DataFormat.Xml);
            Assert.AreEqual(200, (int)restresponse.StatusCode);
            int bookingid = restresponse.Data.bookingid;

            header = new Dictionary<string, string>()
            {
                {"Content-Type", "application/json" },
                {"Accept", "application/json" }
            };booking.SetFirstname("Raju");
            booking.SetLastname("Dahal");
            booking.SetTotalPrice(130);
            RestClientHelper restClientHelper1 = new RestClientHelper();
            IRestResponse<Booking> restresponse1 = restClientHelper1.PerformPatchRequest<Booking>(url + "/" + bookingid, header, tokenvalue, booking, DataFormat.Json);
            Assert.AreEqual(200, (int)restresponse1.StatusCode);

            header = new Dictionary<string, string>()
            {
                {"Accept", "application/json" }
            };
            RestClientHelper restClientHelper2 = new RestClientHelper();
            IRestResponse<Booking> restresponse2 = restClientHelper2.PerformGetRequest<Booking>(url + "/" + bookingid, header);
            Assert.AreEqual(200, (int)restresponse2.StatusCode);
            Assert.IsNotNull(restresponse2.Content, "Rest response is null");
            Assert.IsTrue(restresponse2.Data.firstname.Contains("Raju"), "Firstname is not updated ");
            Assert.IsTrue(restresponse2.Data.lastname.Contains("Dahal"), "Lastname is not updated");
            Assert.AreEqual(130, restresponse2.Data.totalprice, "Total price is not updated");
        }
    }
}
