using API_Testing_RESTful_booker.HelperClass.Request;
using API_Testing_RESTful_booker.Model.JSONModel.Request;
using API_Testing_RESTful_booker.Model.JSONModel.Response;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System;
using System.Collections.Generic;

namespace API_Testing_RESTful_booker.TestCases
{
    [TestClass]
    public class CreateBooking
    {
        private string url = "https://restful-booker.herokuapp.com/booking";
        private string pingurl = "https://restful-booker.herokuapp.com/ping";

        /// <summary>
        /// A simple health check endpoint to confirm whether the API is up and running.
        /// </summary>
        [TestInitialize]
        public void testinitialize()
        {
            RestClientHelper RestClientHelper = new RestClientHelper();
            IRestResponse RestResponse = RestClientHelper.PerformGetRequest(pingurl, null);
            if (RestResponse.IsSuccessful)
            {
                Assert.AreEqual(201, (int)RestResponse.StatusCode);
                Assert.IsNotNull(RestResponse.Content, "Created");
            }
            else
                Assert.Fail("Could not connect to API.");
        }

        /// <summary>
        /// This test creates a new booking in the API using post request for 
        /// a new booking request format as JSON and response format as JSON
        /// </summary>
        [TestMethod]
        [Description(@"This test makes post request for creating a new booking in the API with request format as JSON and" +
            "response format as JSON. The test steps are:"+
            "\n(Step1: Send post request using JSON content-type."+
            "\n(Step2: Verify the response is successful and contains the request data")]
        public void CreateBooking_JsonRequest_JsonResponse()
        {
            Dictionary<string, string> header = new Dictionary<string, string>()
            {
                {"Content-Type", "application/json" },
                {"Accept", "application/json" }
            };
            Model.JSONModel.Request.Booking booking= new Model.JSONModel.Request.Booking("Manisha", "Chanda", 200, true, new Bookingdates(new DateTime(2017, 2, 28), new DateTime(2017, 3, 1)), "Towel");
            RestClientHelper restClientHelper = new RestClientHelper();
            IRestResponse<BookingResponse> restResponse = restClientHelper.PerformPostRequest<BookingResponse>(url, header, null, booking, DataFormat.Json);
            Assert.AreEqual(200, (int)restResponse.StatusCode);
            Assert.IsNotNull(restResponse.Data, "Rest response is null");
            Assert.IsTrue(restResponse.Data.booking.firstname.Contains("Manisha"), "Data has not been added");
        }
    }
}
