namespace API_Testing_RESTful_booker.Model.JSONModel.Response
{
    /// <summary>
    /// This class defines different data types present in Authenticate Responses in JSON Format
    /// </summary>
    public class AuthenticateResponse
    {
        public string token { get; set; }

        public void SetToken(string token)
        {
            this.token = token;
        }
    }
}
