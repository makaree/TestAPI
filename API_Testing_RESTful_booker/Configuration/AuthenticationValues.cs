using System;
using System.Net.Http.Headers;
using System.Text;

namespace API_Testing_RESTful_booker
{
    /// <summary>
    /// This class consists different values that could be used for Authentication
    /// </summary>
    public class AuthenticationValues
    {
        public static string DEFAULT_USERNAME = "admin";
        public static string DEFAULT_PASSWORD = "password123";
        public static string TOKEN_NAME = "token";

        /// <summary>
        /// This method returns Base64 encoded values required for Basic Authentication
        /// </summary>
        public static string Base64EncodedBaiscAuth()
        {
            var byteArray = Encoding.ASCII.GetBytes($"{DEFAULT_USERNAME}:{DEFAULT_PASSWORD}");
            var clientAuthrizationHeader = new AuthenticationHeaderValue("Basic",Convert.ToBase64String(byteArray));
            return clientAuthrizationHeader.ToString();
        }
    }
}
