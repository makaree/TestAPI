namespace API_Testing_RESTful_booker.Model.JSONModel.Request
{
    /// <summary>
    /// This class defines different data types present in Authenticate in JSON format
    /// </summary>
    public class Authenticate
    {
        public string username { get; private set; }
        public string password { get; private set; }

        private Authenticate(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public Authenticate()
        {
        }

        /// <summary>
        /// This method sets username given in input
        /// </summary>
        public void SetUsername(string username)
        {
            this.username = username;
        }

        /// <summary>
        /// This method sets password given in input
        /// </summary>
        public void SetPassword(string password)
        {
            this.password = password;
        }
    }
}
