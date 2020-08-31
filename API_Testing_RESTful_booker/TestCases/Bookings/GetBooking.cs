using API_Testing_RESTful_booker.HelperClass.Request;
using API_Testing_RESTful_booker.Model.JSONModel.Request;
using API_Testing_RESTful_booker.Model.XMLModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System.Collections.Generic;
using System.Web;

namespace API_Testing_RESTful_booker.TestCases
{
    /// <summary>
    /// This test class is used to test  Bookings - GetBooking section
    /// </summary>
    [TestClass]
    public class GetBooking
    {
        private string id = "4";

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
        /// This test returns a specific booking based upon the booking id provided and reponse is JSON.
        /// </summary>
        [TestMethod]
        [Description(@"This test returns a specific booking based upon the bookingid provided.  Get Request" +
            "is sent and the reponse is obtained JSON format. If also verifies in case the response are in JSON format.")]
        public void GetBooking_JsonResponse()
        {
            try
            {
                Dictionary<string, string> header = new Dictionary<string, string>()
            {
                {"Accept", "application/json" }
            };
                RestClientHelper restClientHelper = new RestClientHelper();
                IRestResponse<Booking> restResponse1 = restClientHelper.PerformGetRequest<Booking>(URLEndPoint.bookingurl + id, header);
                if (restResponse1.IsSuccessful)
                {
                    Assert.AreEqual(200, (int)restResponse1.StatusCode);
                    Assert.IsNotNull(restResponse1.Content, "Rest response is null");
                    Assert.IsNotNull(restResponse1.Data.firstname, "Rest response is not Deserialized into JSON");
                }
                else throw new HttpException((int)restResponse1.StatusCode, "Not found");
            }
            catch (HttpException e)
            {
                Assert.AreEqual(404, e.GetHttpCode());
            }
        }

        /// <summary>
        /// This test returns a specific booking based upon the booking id provided and reponse is XML.
        /// </summary>
        [TestMethod]
        [Description(@"This test returns a specific booking based upon the bookingid provided.  Get Request" +
            "is sent and the reponse is obtained in xml format. If also verifies in case the values are in XML format")]
        public void GetBooking_XmlResponse()
        {
            try
            {
                Dictionary<string, string> header = new Dictionary<string, string>()
            {
                {"Accept", "application/xml" }
            };
                RestClientHelper restClientHelper = new RestClientHelper();
                IRestResponse<BookingXML> restResponse1 = restClientHelper.PerformGetRequest<BookingXML>(URLEndPoint.bookingurl + id, header);
                if (restResponse1.IsSuccessful)
                {
                    Assert.AreEqual(200, (int)restResponse1.StatusCode);
                    Assert.IsNotNull(restResponse1.Content, "Rest response is null");
                    Assert.IsNotNull(restResponse1.Data.Firstname, "Rest response is not Deserialized into XML");
                }
                else throw new HttpException((int)restResponse1.StatusCode, "Not found");
            }
            catch (HttpException e)
            {
                Assert.AreEqual(404, e.GetHttpCode());
            }
        }

        /// <summary>
        /// This test returns a specific booking based upon the booking id provided and reponse is Url encoded format.
        /// </summary>
        [TestMethod]
        [Description(@"This test returns a specific booking based upon the bookingid provided.  Get Request" +
            "is sent and the reponse is obtained in Url Encoded format. If also verifies in case in case the response are in URL encoded format")]
        public void GetBooking_UrlResponse()
        {
            try
            {
                Dictionary<string, string> header = new Dictionary<string, string>()
            {
                {"Accept", "application/x-www-form-urlencoded" }
            };
                RestClientHelper restClientHelper = new RestClientHelper();
                IRestResponse restResponse1 = restClientHelper.PerformGetRequest(URLEndPoint.bookingurl + id, header);
                if (restResponse1.IsSuccessful)
                {
                    Assert.AreEqual(200, (int)restResponse1.StatusCode);
                    Assert.IsNotNull(restResponse1.Content, "Rest response is null");
                    Assert.IsTrue(restResponse1.Content.Contains("&bookingdates%5Bcheckin%5D="), "Rest response does not contains URL Encoded Response");
                }
                else throw new HttpException((int)restResponse1.StatusCode, "Not found");
            }
            catch (HttpException e)
            {
                Assert.AreEqual(404, e.GetHttpCode());
            }
        }
    }
}
