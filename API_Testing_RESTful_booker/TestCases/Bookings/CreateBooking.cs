using API_Testing_RESTful_booker.HelperClass.Request;
using API_Testing_RESTful_booker.Model.JSONModel.Request;
using API_Testing_RESTful_booker.Model.JSONModel.Response;
using API_Testing_RESTful_booker.Model.URLencoded;
using API_Testing_RESTful_booker.Model.XMLModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System;
using System.Collections.Generic;

namespace API_Testing_RESTful_booker.TestCases
{
    /// <summary>
    /// This test class is used to test  Bookings - CreateBooking section
    /// </summary>
    [TestClass]
    public class CreateBooking
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
        /// This test creates a new booking in the API using post request for 
        /// a new booking request format as JSON and response format as JSON
        /// </summary>
        [TestMethod]
        [Description(@"This test makes post request for creating a new booking in the API with request format as JSON and" +
            "response format as JSON. The test steps are:" +
            "\n(Step1: Send post request using JSON content-type." +
            "\n(Step2: Verify the response is successful and contains the request data")]
        public void CreateBooking_JsonRequest_JsonResponse()
        {
            Dictionary<string, string> header = new Dictionary<string, string>()
            {
                {"Content-Type", "application/json" },
                {"Accept", "application/json" }
            };
            Booking booking = new Booking("Manisha", "Chanda", 200, true, new Bookingdates(new DateTime(2017, 2, 28), new DateTime(2017, 3, 1)), "Towel");
            RestClientHelper restClientHelper = new RestClientHelper();
            IRestResponse<BookingResponse> restResponse = restClientHelper.PerformPostRequest<BookingResponse>(URLEndPoint.bookingurl, header, null, booking, DataFormat.Json);
            Assert.AreEqual(200, (int)restResponse.StatusCode);
            Assert.IsNotNull(restResponse.Data, "Rest response is null");
            Assert.IsTrue(restResponse.Data.booking.firstname.Contains("Manisha"), "Data has not been added");
        }

        /// <summary>
        /// This test creates a new booking in the API using post request for 
        /// a new booking request format as JSON and response format as XML
        /// </summary>
        [TestMethod]
        [Description(@"This test makes post request for creating a new booking in the API with request format as JSON and" +
            "response format as XML. The test steps are:" +
            "\n(Step1: Send post request using JSON content-type." +
            "\n(Step2: Verify the response is successful and contains the request data")]
        public void CreateBooking_JsonRequest_XmlResponse()
        {
            Dictionary<string, string> header = new Dictionary<string, string>()
            {
                {"Content-Type", "application/json" },
                {"Accept", "application/xml" }
            };
            Booking booking = new Booking("Manisha", "Chanda", 200, true, new Bookingdates(new DateTime(2017, 2, 28), new DateTime(2017, 3, 1)), "Towel");
            RestClientHelper restClientHelper = new RestClientHelper();
            IRestResponse<CreatedbookingXML> restResponse = restClientHelper.PerformPostRequest<CreatedbookingXML>(URLEndPoint.bookingurl, header, null, booking, DataFormat.Json);
            Assert.AreEqual(200, (int)restResponse.StatusCode);
            Assert.IsNotNull(restResponse.Data, "Rest response is null");
            Assert.IsTrue(restResponse.Data.Booking.Firstname.Contains("Manisha"), "Data has not been added");
        }

        /// <summary>
        /// This test creates a new booking in the API using post request for 
        /// a new booking request format as JSON and response format as Url encoded
        /// </summary>
        [TestMethod]
        [Description(@"This test makes post request for creating a new booking in the API with request format as JSON and" +
            "response format as XML. The test steps are:" +
            "\n(Step1: Send post request using JSON content-type." +
            "\n(Step2: Verify the response is successful and contains the request data")]
        public void CreateBooking_JsonRequest_URLEncodedResponse()
        {
            Dictionary<string, string> header = new Dictionary<string, string>()
            {
                {"Content-Type", "application/json" },
                {"Accept", "application/x-www-form-urlencoded" }
            };
            Booking booking = new Booking("Manisha", "Chanda", 200, true, new Bookingdates(new DateTime(2017, 2, 28), new DateTime(2017, 3, 1)), "Towel");
            RestClientHelper restClientHelper = new RestClientHelper();
            IRestResponse restResponse = restClientHelper.PerformPostRequest(URLEndPoint.bookingurl, header, null, booking, DataFormat.Json);
            Assert.AreEqual(200, (int)restResponse.StatusCode);
            Assert.IsNotNull(restResponse.Content, "Rest response is null");
            Assert.IsTrue(restResponse.Content.Contains("&booking%5Btotalprice%5D"), "Data has not been added");
            Assert.IsTrue(restResponse.Content.Contains("Manisha"), "Firstname has not been added");
        }

        /// <summary>
        /// This test creates a new booking in the API using post request for 
        /// a new booking request format as XML and response format as XML
        /// </summary>
        [TestMethod]
        [Description(@"This test makes post request for creating a new booking in the API with request format as JSON and" +
            "response format as XML. The test steps are:" +
            "\n(Step1: Send post request using XML content-type." +
            "\n(Step2: Verify the response is successful and contains the request data")]
        public void CreateBooking_XmlRequest_XmlResponse()
        {
            Dictionary<string, string> header = new Dictionary<string, string>()
            {
                {"Content-Type", "text/xml" },
                {"Accept", "application/xml" }
            };
            Booking booking = new Booking();
            string xmlrequest = booking.CreateBookinginXMLFormat("Manisha", "Chanda", 200, true, new Bookingdates(new DateTime(2016, 2, 18), new DateTime(2017, 2, 21)), "Towel");
            RestClientHelper restClientHelper = new RestClientHelper();
            IRestResponse<CreatedbookingXML> restResponse = restClientHelper.PerformPostRequest<CreatedbookingXML>(URLEndPoint.bookingurl, header, null, xmlrequest, DataFormat.Xml);
            Assert.AreEqual(200, (int)restResponse.StatusCode);
            Assert.IsNotNull(restResponse.Data, "Rest response is null");
            Assert.IsTrue(restResponse.Data.Booking.Firstname.Contains("Manisha"), "Data has not been added");
        }

        /// <summary>
        /// This test creates a new booking in the API using post request for 
        /// a new booking request format as XML and response format as JSON
        /// </summary>
        [TestMethod]
        [TestCategory("Stable")]
        [Description(@"This test makes post request for creating a new booking in the API with request format as JSON and" +
            "response format as XML. The test steps are:" +
            "\n(Step1: Send post request using XML content-type." +
            "\n(Step2: Verify the response is successful and contains the request data")]
        public void CreateBooking_XmlRequest_JsonResponse()
        {
            Dictionary<string, string> header = new Dictionary<string, string>()
            {
                {"Content-Type", "text/xml" },
                {"Accept", "application/json" }
            };
            Booking booking = new Booking();
            string xmlrequest = booking.CreateBookinginXMLFormat("Manisha", "Chanda", 200, true, new Bookingdates(new DateTime(2016, 2, 18), new DateTime(2017, 2, 21)), "Towel");
            RestClientHelper restClientHelper = new RestClientHelper();
            IRestResponse<BookingResponse> restResponse = restClientHelper.PerformPostRequest<BookingResponse>(URLEndPoint.bookingurl, header, null, xmlrequest, DataFormat.Xml);
            Assert.AreEqual(200, (int)restResponse.StatusCode);
            Assert.IsNotNull(restResponse.Data, "Rest response is null");
            Assert.IsTrue(restResponse.Data.booking.firstname.Contains("Manisha"), "Data has not been added");
        }

        /// <summary>
        /// This test creates a new booking in the API using post request for 
        /// a new booking request format as XML and response format as JSON
        /// </summary>
        [TestMethod]
        [Description(@"This test makes post request for creating a new booking in the API with request format as JSON and" +
            "response format as XML. The test steps are:" +
            "\n(Step1: Send post request using XML content-type." +
            "\n(Step2: Verify the response is successful and contains the request data")]
        public void CreateBooking_XmlRequest_UrlEncodedResponse()
        {
            Dictionary<string, string> header = new Dictionary<string, string>()
            {
                {"Content-Type", "text/xml" },
                {"Accept", "application/x-www-form-urlencoded" }
            };
            Booking booking = new Booking();
            string xmlrequest = booking.CreateBookinginXMLFormat("Manisha", "Chanda", 200, true, new Bookingdates(new DateTime(2016, 2, 18), new DateTime(2017, 2, 21)), "Towel");
            RestClientHelper restClientHelper = new RestClientHelper();
            IRestResponse restResponse = restClientHelper.PerformPostRequest(URLEndPoint.bookingurl, header, null, xmlrequest, DataFormat.Xml);
            Assert.AreEqual(200, (int)restResponse.StatusCode);
            Assert.IsNotNull(restResponse.Content, "Rest response is null");
            Assert.IsTrue(restResponse.Content.Contains("&booking%5Btotalprice%5D"), "Data has not been added");
        }

        /// <summary>
        /// This test creates a new booking in the API using post request for 
        /// a new booking request format encoded in url format and response format as JSON
        /// </summary>
        [TestMethod]
        [Description(@"This test makes post request for creating a new booking in the API with request format encoded in URL format and" +
            "response format as JSON. The test steps are:" +
            "\n(Step1: Send post request using urlencoded content-type." +
            "\n(Step2: Verify the response is successful and contains the request data")]
        public void CreateBooking_URLencodedRequest_JsonResponse()
        {
            Dictionary<string, string> header = new Dictionary<string, string>()
            {
                {"Content-Type", "application/x-www-form-urlencoded" },
                {"Accept", "application/json" }
            };
            Booking booking = new Booking("Manisha", "Chanda", 200, true, new Bookingdates(new DateTime(2017, 2, 28), new DateTime(2017, 3, 1)), "Towel");
            RestClientHelper restClientHelper = new RestClientHelper();
            object urlencodedbody = URLformat.SerializeURLformat(booking.firstname, booking.lastname, booking.totalprice, booking.depositpaid, booking.bookingdates);
            IRestResponse<BookingResponse> restResponse = restClientHelper.PerformPostRequest<BookingResponse>(URLEndPoint.bookingurl, header, null, urlencodedbody, true);
            Assert.AreEqual(200, (int)restResponse.StatusCode);
            Assert.IsNotNull(restResponse.Data, "Rest response is null");
            Assert.IsTrue(restResponse.Data.booking.firstname.Contains("Manisha"), "Data has not been added");
        }

        /// <summary>
        /// This test creates a new booking in the API using post request for 
        /// a new booking request format encoded in url format and response format as xml
        /// </summary>
        [TestMethod]
        [Description(@"This test makes post request for creating a new booking in the API with request format encoded in URL format and" +
            "response format as XML. The test steps are:" +
            "\n(Step1: Send post request using urlencoded content-type." +
            "\n(Step2: Verify the response is successful and contains the request data")]
        public void CreateBooking_URLencodedRequest_XmlResponse()
        {
            Dictionary<string, string> header = new Dictionary<string, string>()
            {
                {"Content-Type", "application/x-www-form-urlencoded" },
                {"Accept", "application/xml" }
            };
            Booking booking = new Booking("Manisha", "Chanda", 200, true, new Bookingdates(new DateTime(2017, 2, 28), new DateTime(2017, 3, 1)), "Towel");
            RestClientHelper restClientHelper = new RestClientHelper();
            object urlencodedbody = URLformat.SerializeURLformat(booking.firstname, booking.lastname, booking.totalprice, booking.depositpaid, booking.bookingdates);
            IRestResponse<CreatedbookingXML> restResponse = restClientHelper.PerformPostRequest<CreatedbookingXML>(URLEndPoint.bookingurl, header, null, urlencodedbody, true);
            Assert.AreEqual(200, (int)restResponse.StatusCode);
            Assert.IsNotNull(restResponse.Data, "Rest response is null");
            Assert.IsTrue(restResponse.Data.Booking.Firstname.Contains("Manisha"), "Data has not been added");
        }

        /// <summary>
        /// This test creates a new booking in the API using post request for 
        /// a new booking request format encoded in url format and response format as xml
        /// </summary>
        [TestMethod]
        [Description(@"This test makes post request for creating a new booking in the API with request format encoded in URL format and" +
            "response format as urlencoded. The test steps are:" +
            "\n(Step1: Send post request using urlencoded content-type." +
            "\n(Step2: Verify the response is successful and contains the request data")]
        public void CreateBooking_URLencodedRequest_URLencodedResponse()
        {
            Dictionary<string, string> header = new Dictionary<string, string>()
            {
                {"Content-Type", "application/x-www-form-urlencoded" },
                {"Accept", "application/x-www-form-urlencoded" }
            };
            Booking booking = new Booking("Manisha", "Chanda", 200, true, new Bookingdates(new DateTime(2017, 2, 28), new DateTime(2017, 3, 1)), "Towel");
            RestClientHelper restClientHelper = new RestClientHelper();
            object urlencodedbody = URLformat.SerializeURLformat(booking.firstname, booking.lastname, booking.totalprice, booking.depositpaid, booking.bookingdates);
            IRestResponse restResponse = restClientHelper.PerformPostRequest(URLEndPoint.bookingurl, header, null, urlencodedbody, true);
            Assert.AreEqual(200, (int)restResponse.StatusCode);
            Assert.IsNotNull(restResponse.Content, "Rest response is null");
            Assert.IsTrue(restResponse.Content.Contains("&booking%5Btotalprice%5D"), "Data has not been added");
        }
    }
}
