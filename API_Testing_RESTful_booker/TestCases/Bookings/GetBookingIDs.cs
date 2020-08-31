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
    /// This test class is used to test  Bookings - GetBookingIDs section
    /// </summary>
    [TestClass]
    public class GetBookingIDs
    {
        
        /// <summary>
        /// A simple health check endpoint to confirm whether the API is up and running.
        /// </summary>
        [TestInitialize]
        public void testinitialize()
        {
            RestClientHelper RestClientHelper = new RestClientHelper();
            IRestResponse RestResponse = RestClientHelper.PerformGetRequest(URLEndPoint.pingurl, null);
            if (RestResponse.IsSuccessful)
            {
                Assert.AreEqual(201, (int)RestResponse.StatusCode);
                Assert.IsNotNull(RestResponse.Content, "Created");
            }
            else
                Assert.Fail("Could not connect to API.");
        }

        /// <summary>
        /// This test returns the ids of all the bookings that exist within the API.
        /// </summary>
        [TestMethod]
        [Description(@"This test returns the ids of all the bookings that exist within the API." +
            "It performs a get request and verifies that the response is not null.")]
        public void GetBookingIDs_All_IDS()
        {
            Dictionary<string, string> header = new Dictionary<string, string>()
            {
                {"Accept", "application/json" }
            };
            RestClientHelper restClientHelper = new RestClientHelper();
            IRestResponse restResponse = restClientHelper.PerformGetRequest(URLEndPoint.bookingurl, header);
            Assert.AreEqual(200, (int)restResponse.StatusCode);
            Assert.IsNotNull(restResponse.Content, "Rest response is null");
        }

        /// <summary>
        /// This test returns the ids of all the bookings that exist within the API.
        /// It takes name as query strings to search and return a subset of booking ids.
        /// </summary>
        [TestMethod]
        [Description(@"This test returns the ids of all the bookings that exist within the API." +
            "It takes name as query strings to search and return a subset of booking ids." +
            "The test steps are: " +
            "\n(Step1: Make a post request to add new booking and save its bookingid" +
            "\n(Step2: Make a get request using firstname and lastname from step1" +
            "\n(Step3: Check the response contains bookingid from step1")]
        public void GetBookingIDs_FilterByName()
        {
            //Make a post request to add new booking and save its bookingid
            Dictionary<string, string> header = new Dictionary<string, string>()
            {
                {"Content-Type", "application/json" },
                {"Accept", "application/json" }
            };
            Booking booking = new Booking("Manisha", "Chanda", 200, true, new Bookingdates(new DateTime(2017, 2, 28), new DateTime(2017, 3, 1)), "Towel");
            RestClientHelper restClientHelper = new RestClientHelper();
            IRestResponse<BookingResponse> restResponse = restClientHelper.PerformPostRequest<BookingResponse>(URLEndPoint.bookingurl, header, null, booking, DataFormat.Json);
            Assert.AreEqual(200, (int)restResponse.StatusCode);

            //Make a get request using firstname and lastname
            int bookingid = restResponse.Data.bookingid;
            Dictionary<string, string> queryparameter = new Dictionary<string, string>()
            {
                {"firstname", "Manisha" },
                {"lastname", "Chanda" }
            };
            IRestResponse restResponse1 = restClientHelper.PerformGetRequest(URLEndPoint.bookingurlforquery, header, queryparameter);
            Assert.AreEqual(200, (int)restResponse1.StatusCode);
            Assert.IsNotNull(restResponse1.Content, "Rest response is null");
            Assert.IsTrue(restResponse1.Content.Contains(bookingid.ToString()), "Name posted is not present");
        }

        /// <summary>
        /// This test returns the ids of all the bookings that exist within the API.
        /// It takes checkin and checkout dates as query strings to search and return 
        /// all booking ids that lie within this time period.
        /// </summary>
        [TestMethod]
        [Description(@"This test returns the ids of all the bookings that exist within the API." +
            "It takes checkin and checkout dates as query strings to search and return all booking" +
            "ids that lie within this time period. The test steps are: " +
            "\n(Step1: Make a post request to add new booking and save its bookingid" +
            "\n(Step2: Make a get request using a checkin date and checkout date that includes dates in step1" +
            "\n(Step3: Check the response contains bookingid from step1")]
        public void GetBookingIDs_FilterByDate()
        {
            //Make a post request to add new booking and save its bookingid
            Dictionary<string, string> header = new Dictionary<string, string>()
            {
                {"Content-Type", "application/json" },
                {"Accept", "application/json" }
            };
            Booking booking = new Booking("Manisha", "Chanda", 200, true, new Bookingdates(new DateTime(2016, 2, 18), new DateTime(2017, 2, 21)), "Towel");
            RestClientHelper restClientHelper = new RestClientHelper();
            IRestResponse<BookingResponse> restResponse = restClientHelper.PerformPostRequest<BookingResponse>(URLEndPoint.bookingurlforquery, header, null, booking, DataFormat.Json);
            Assert.AreEqual(200, (int)restResponse.StatusCode);

            //Make a get request using a checkin date and checkout date that includes dates
            int bookingid = restResponse.Data.bookingid;
            Dictionary<string, string> queryparameter = new Dictionary<string, string>()
            {
                {"checkin","2014-03-01"},
                {"checkout","2019-03-01"}
            };
            IRestResponse restResponse1 = restClientHelper.PerformGetRequest(URLEndPoint.bookingurl, header, queryparameter);
            Assert.AreEqual(200, (int)restResponse1.StatusCode);
            Assert.IsNotNull(restResponse1.Content, "Rest response is null");
            Assert.IsTrue(restResponse1.Content.Contains(bookingid.ToString()), "Name posted is not present");
        }
    }
}
