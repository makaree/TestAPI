using API_Testing_RESTful_booker.HelperClass.Request;
using API_Testing_RESTful_booker.Model.JSONModel.Request;
using API_Testing_RESTful_booker.Model.JSONModel.Response;
using API_Testing_RESTful_booker.Model.XMLModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System;
using System.Collections.Generic;

namespace API_Testing_RESTful_booker.TestCases
{
    /// <summary>
    /// This test class is used to test  Bookings - PartialUpdateBooking section
    /// </summary>
    [TestClass]
    public class PartialUpdateBooking
    {
        private IRestResponse<AuthenticateResponse> restResponse;
        
        /// <summary>
        /// A simple health check endpoint to confirm whether the API is up and running. 
        /// And also Creates a new auth token to use for access to the PUT and DELETE /booking
        /// </summary>
        [TestInitialize]
        public void testinitialize()
        {
            RestClientHelper RestClientHelper = new RestClientHelper();
            IRestResponse RestResponse = RestClientHelper.PerformGetRequest(URLEndPoint.pingurl, null);
            if (RestResponse.IsSuccessful)
            {
                Dictionary<string, string> header = new Dictionary<string, string>()
            {
                {"Content-Type", "application/json" }
            };
                var authenticate = new Authenticate();
                authenticate.SetUsername(AuthenticationValues.DEFAULT_USERNAME);
                authenticate.SetPassword(AuthenticationValues.DEFAULT_PASSWORD);
                RestClientHelper restClientHelper = new RestClientHelper();
                restResponse = restClientHelper.PerformPostRequest<AuthenticateResponse>(URLEndPoint.authurl, header, null, authenticate, DataFormat.Json);
            }
            else
                Assert.Fail("Could not connect to API.");
        }

        /// <summary>
        /// This test updates a Updates a current booking with a partial payload using patch request.
        /// This test uses Token based Authentication.
        /// </summary>
        [TestMethod]
        [Description(@"This test updates a Updates a current booking with a partial payload using patch request" +
            "This test uses Token Based Authenticaiton. The test steps are: " +
            "\n(Step1: Make a post request to add new booking and save its bookingid" +
            "\n(Step2: Make a patch request and update booking using bookingid from step1" +
            "\n(Step3: Make a get response and verify the booking has been updated")]
        public void UpdatePartialBooking_JsonRequest_JsonResponse_TokenAuth()
        {
            string tokenvalue = restResponse.Data.token;

            //Make a post request to add new booking and save its bookingid
            Dictionary<string, string> header = new Dictionary<string, string>()
            {
                {"Content-Type", "application/json" },
                {"Accept", "application/json" }
            };
            Booking booking = new Booking("Arif", "Hood", 200, true, new Bookingdates(new DateTime(2016, 12, 18), new DateTime(2017, 02, 21)), "Braekfast");
            RestClientHelper restClientHelper = new RestClientHelper();
            IRestResponse<BookingResponse> restresponse = restClientHelper.PerformPostRequest<BookingResponse>(URLEndPoint.bookingurl, header, null, booking, DataFormat.Json);
            Assert.AreEqual(200, (int)restresponse.StatusCode);
            int bookingid = restresponse.Data.bookingid;

            //Make a patch request and update booking using bookingid
            header = new Dictionary<string, string>()
            {
                {"Content-Type", "application/json" },
                {"Accept", "application/json" }
            }; booking.SetFirstname("Raju");
            booking.SetLastname("Dahal");
            booking.SetTotalPrice(130);
            RestClientHelper restClientHelper1 = new RestClientHelper();
            IRestResponse<Booking> restresponse1 = restClientHelper1.PerformPatchRequest<Booking>(URLEndPoint.bookingurl + bookingid, header, tokenvalue, booking, DataFormat.Json);
            Assert.AreEqual(200, (int)restresponse1.StatusCode);

            //Make a get response and verify the booking has been updated
            header = new Dictionary<string, string>()
            {
                {"Accept", "application/json" }
            };
            RestClientHelper restClientHelper2 = new RestClientHelper();
            IRestResponse<Booking> restresponse2 = restClientHelper2.PerformGetRequest<Booking>(URLEndPoint.bookingurl + bookingid, header);
            Assert.AreEqual(200, (int)restresponse2.StatusCode);
            Assert.IsNotNull(restresponse2.Content, "Rest response is null");
            Assert.IsTrue(restresponse2.Data.firstname.Contains("Raju"), "Firstname is not updated ");
            Assert.IsTrue(restresponse2.Data.lastname.Contains("Dahal"), "Lastname is not updated");
            Assert.AreEqual(130, restresponse2.Data.totalprice, "Total price is not updated");
        }

        /// <summary>
        /// This test updates a Updates a current booking with a partial payload using patch request.
        /// This test uses Basic Authentication.
        /// </summary>
        [TestMethod]
        [Description(@"This test updates a Updates a current booking with a partial payload using patch request" +
            "This test uses Basic Authenticaiton. The test steps are: " +
            "\n(Step1: Make a post request to add new booking and save its bookingid" +
            "\n(Step2: Make a patch request and update booking using bookingid from step1" +
            "\n(Step3: Make a get response and verify the booking has been updated")]
        public void UpdatePartialBooking_JsonRequest_XmlResponse_BasicAuth()
        {
            //Make a post request to add new booking and save its bookingid
            Dictionary<string, string> header = new Dictionary<string, string>()
            {
                {"Content-Type", "application/json" },
                {"Accept", "application/xml" }
            };
            Booking booking = new Booking("Mikk", "Poom", 2120, false, new Bookingdates(new DateTime(2017, 01, 21), new DateTime(2017, 02, 21)), "Towel needed");
            RestClientHelper restClientHelper = new RestClientHelper();
            IRestResponse<CreatedbookingXML> restresponse = restClientHelper.PerformPostRequest<CreatedbookingXML>(URLEndPoint.bookingurl, header, null, booking, DataFormat.Json);
            Assert.AreEqual(200, (int)restresponse.StatusCode);
            int bookingid = int.Parse(restresponse.Data.Bookingid);

            //Make a patch request and update booking using bookingid 
            header = new Dictionary<string, string>()
            {
                {"Content-Type", "application/json" },
                {"Accept", "application/xml" },
                {"Authorization",AuthenticationValues.Base64EncodedBaiscAuth() }
            };
            DateTime checkin = new DateTime(2016, 02, 09);
            DateTime checkout = new DateTime(2017, 02, 20);
            booking.SetAdditionalNeeds("Nothing required");
            booking.SetBookingDates(new Bookingdates(checkin, checkout));
            RestClientHelper restClientHelper1 = new RestClientHelper();
            IRestResponse<BookingXML> restresponse1 = restClientHelper1.PerformPatchRequest<BookingXML>(URLEndPoint.bookingurl +  bookingid, header, null, booking, DataFormat.Json);
            Assert.AreEqual(200, (int)restresponse1.StatusCode);

            // Make a get response and verify the booking has been updated
            header = new Dictionary<string, string>()
            {
                {"Accept", "application/xml" }
            };
            RestClientHelper restClientHelper2 = new RestClientHelper();
            IRestResponse<BookingXML> restresponse2 = restClientHelper2.PerformGetRequest<BookingXML>(URLEndPoint.bookingurl + bookingid, header);
            Assert.AreEqual(200, (int)restresponse2.StatusCode);
            Assert.IsNotNull(restresponse2.Content, "Rest response is null");
            Assert.AreEqual(Booking.convertdateinstring(checkin), restresponse2.Data.Bookingdates.Checkin, "Checkin date is not updated");
            Assert.AreEqual(Booking.convertdateinstring(checkout), restresponse2.Data.Bookingdates.Checkout, "Checkout date is not updated");
            Assert.IsTrue(restresponse2.Data.Additionalneeds.Contains("Nothing required"), "Additional needs is not updated");
        }


    }
}
