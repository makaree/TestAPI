using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Testing_RESTful_booker.Model.JSONModel.Request
{
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


        public void SetUsername(string username)
        {
            this.username = username;
        }

        public void SetPassword(string password)
        {
            this.password = password;
        }
    }
    }
