using API_Testing_RESTful_booker.HelperClass.Request;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;

namespace API_Testing_RESTful_booker.TestCases
{
    /// <summary>
    /// This test class is used to test Ping - Health Check
    /// </summary>
    [TestClass]
    public class HealthCheck
    {
        
        /// <summary>
        /// This test makes a simple health check endpoint to confirm whether the API is up and running.
        /// </summary>
        [TestMethod]
        [Description(@"This test makes a simple health check endpoint to confirm whether the API is up and running." +
            "It performs a get request and verifies that the response is 201.")]
        public void HealthCheck_Ping()
        {
            RestClientHelper restClientHelper = new RestClientHelper();
            IRestResponse restResponse = restClientHelper.PerformGetRequest(URLEndPoint.pingurl, null);
            Assert.AreEqual(201, (int)restResponse.StatusCode);
            Assert.IsNotNull(restResponse.Content, "Created");
        }
    }
}
