using API_Testing_RESTful_booker.HelperClass.Request;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace API_Testing_RESTful_booker.TestCases
{
    [TestClass]
    public class GetBooking
    {
        private string url = "https://restful-booker.herokuapp.com/booking";
        private string id = "4";
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
        /// This test returns a specific booking based upon the booking id provided and reponse is JSON.
        /// </summary>
        [TestMethod]
        [Description(@"This test returns a specific booking based upon the bookingid provided.  Get Request" +
            "is sent and the reponse is obtained JSON format. If also verifies in case bookingid does not exist.")]
        public void GetBooking_JsonResponse()
        {
            try
            {
                Dictionary<string, string> header = new Dictionary<string, string>()
            {
                {"Accept", "application/json" }
            };
                RestClientHelper restClientHelper = new RestClientHelper();
                IRestResponse restResponse1 = restClientHelper.PerformGetRequest(url + "/" + id, header);
                if (restResponse1.IsSuccessful)
                {
                    Assert.AreEqual(200, (int)restResponse1.StatusCode);
                    Assert.IsNotNull(restResponse1.Content, "Rest response is null");
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
