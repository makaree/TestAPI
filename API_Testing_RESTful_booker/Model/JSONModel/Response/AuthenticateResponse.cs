using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Testing_RESTful_booker.Model.JSONModel.Response
{
    public class AuthenticateResponse
    {
        public string token { get; set; }

        public void SetToken(string token)
        {
            this.token = token;
        }
    }
}
