using API_Testing_RESTful_booker.HelperClass.Request;
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
    public class HealthCheck
    {
        private string pingurl = "https://restful-booker.herokuapp.com/ping";

        /// <summary>
        /// This test makes a simple health check endpoint to confirm whether the API is up and running.
        /// </summary>
        [TestMethod]
        [Description(@"This test makes a simple health check endpoint to confirm whether the API is up and running." +
            "It performs a get request and verifies that the response is 201.")]
        public void GetBookingIDs_All_IDS()
        {
            RestClientHelper restClientHelper = new RestClientHelper();
            IRestResponse restResponse = restClientHelper.PerformGetRequest(pingurl, null);
            Assert.AreEqual(201, (int)restResponse.StatusCode);
            Assert.IsNotNull(restResponse.Content, "Created");
        }
    }
}
