using API_Testing_RESTful_booker.HelperClass.Request;
using API_Testing_RESTful_booker.Model.JSONModel.Request;
using API_Testing_RESTful_booker.Model.JSONModel.Response;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System;
using System.Collections.Generic;

namespace API_Testing_RESTful_booker.TestCases
{
    /// <summary>
    /// This test class is used to test  Bookings - DeleteBooking section
    /// </summary>
    [TestClass]
    public class DeleteBooking
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
        /// This test deletes a booking in the API based on given bookingid when 
        /// token is provided.
        /// </summary>
        [TestMethod]
        [Description(@"This test deletes a booking in the API using delete request by using token." +
            "(The test steps are:" +
            "\n(Step1. Create a token by providing username and password" +
            "\n(Step2. Make a post request to add new booking and save its bookingid " +
            "\n(Step3. Use token based authentication and perfrom delete request using bookingid from step 2.")]
        public void DeleteBookingUsingToken()
        {
            //Token is created by providing username and password
            string tokenvalue = restResponse.Data.token;

            //Make a post request to add new booking and save its bookingid
            Dictionary<string, string> header = new Dictionary<string, string>()
            {
                {"Content-Type", "application/json" },
                {"Accept", "application/json" }
            };
            Booking booking = new Booking("Manisha", "Chanda", 200, true, new Bookingdates(new DateTime(2017, 2, 28), new DateTime(2017, 3, 1)), "Towel");
            RestClientHelper restClientHelper = new RestClientHelper();
            IRestResponse<BookingResponse> restresponse = restClientHelper.PerformPostRequest<BookingResponse>(URLEndPoint.bookingurl, header, null, booking, DataFormat.Json);
            Assert.AreEqual(200, (int)restresponse.StatusCode);
            Assert.IsNotNull(restresponse.Data, "Rest response is null");
            int bookingid = restresponse.Data.bookingid;

            //Use token based authentication and perfrom delete request using bookingid
            header = new Dictionary<string, string>()
            {
                {"Content-Type", "application/json" }
            };
            RestClientHelper restClientHelper1 = new RestClientHelper();
            IRestResponse restResponse1 = restClientHelper1.PerformDeleteRequest(URLEndPoint.bookingurl + bookingid, header, tokenvalue);
            Assert.AreEqual(201, (int)restResponse1.StatusCode);
            restResponse1 = restClientHelper.PerformDeleteRequest(URLEndPoint.bookingurl + bookingid, header, tokenvalue);
            Assert.AreEqual(405, (int)restResponse1.StatusCode);
        }

        /// <summary>
        /// This test deletes a booking in the API based on given bookingid when 
        /// username and password is provided.
        /// </summary>
        [TestMethod]
        [Description(@"This test deletes a booking in the API using delete request by using basic authentication." +
            "(The test steps are:" +
            "\n(Step1. Make a post request to add new booking and save its bookingid " +
            "\n(Step2. Use basic authentication and perfrom delete request using bookingid from step 1.")]
        public void DeleteBookingUsingBasicAuth()
        {
            //Make a post request to add new booking and save its bookingid
            Dictionary<string, string> header = new Dictionary<string, string>()
            {
                {"Content-Type", "application/json" },
                {"Accept", "application/json" }
            };
            Booking booking = new Booking("Manisha", "Chanda", 200, true, new Bookingdates(new DateTime(2017, 2, 28), new DateTime(2017, 3, 1)), "Towel");
            RestClientHelper restClientHelper = new RestClientHelper();
            IRestResponse<BookingResponse> restresponse = restClientHelper.PerformPostRequest<BookingResponse>(URLEndPoint.bookingurl, header, null, booking, DataFormat.Json);
            Assert.AreEqual(200, (int)restresponse.StatusCode);
            Assert.IsNotNull(restresponse.Data, "Rest response is null");
            int bookingid = restresponse.Data.bookingid;

            //Use basic authentication and perfrom delete request using bookingid
            header = new Dictionary<string, string>()
            {
                {"Content-Type", "application/json" },
                {"Authorization", AuthenticationValues.Base64EncodedBaiscAuth() }
            };
            RestClientHelper restClientHelper1 = new RestClientHelper();
            IRestResponse restResponse1 = restClientHelper1.PerformDeleteRequest(URLEndPoint.bookingurl + bookingid, header, null);
            Assert.AreEqual(201, (int)restResponse1.StatusCode);
            restResponse1 = restClientHelper.PerformDeleteRequest(URLEndPoint.bookingurl + bookingid, header, null);
            Assert.AreEqual(405, (int)restResponse1.StatusCode);
        }
    }
}
