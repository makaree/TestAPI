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
    public class CreateToken
    {
        private IRestResponse<AuthenticateResponse> restResponse;
        private string authurl = "https://restful-booker.herokuapp.com/auth";
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
        /// This test checks if a new auth token has been created or not
        /// </summary>
        [TestMethod]
        [Description(@"This test checks if a token value has been created after sending post"+
            "request. It also verifies if the token content is null or not")]
        public void CreateToken_Post()
        {
            if (restResponse.IsSuccessful)
            {
                Assert.AreEqual(200, (int)restResponse.StatusCode);
                Assert.IsNotNull(restResponse.Data.token, "Token value is null");
            }
            else Assert.Fail("Token has not been created");
        }
    }
}
