using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace API_Testing_RESTful_booker.HelperClass.Request
{
    public class RestClientHelper
    {
        private IRestClient GetRestClient()
        {
            IRestClient restClient = new RestClient();
            return restClient;
        }

        private IRestRequest GetRestRequest(string url, Dictionary<string, string> header,string tokenvalue, Method method, object body, DataFormat dataformat)
        {
            IRestRequest restRequest = new RestRequest()
            {
                Method = method,
                Resource = url
            };

            if (header != null)
            {
                foreach (string key in header.Keys)
                {
                    restRequest.AddHeader(key, header[key]);
                }
            }
            if (tokenvalue !=null)
            {
                restRequest.AddCookie(Global.TOKEN_NAME, tokenvalue);
            }
            if (body != null)
            {
                restRequest.RequestFormat = dataformat;
                switch (dataformat)
                {
                    case DataFormat.Json:
                        restRequest.AddBody(body);
                        break;
                    case DataFormat.Xml:
                        restRequest.XmlSerializer = new RestSharp.Serializers.DotNetXmlSerializer();
                        restRequest.AddParameter("xmlbody", body.GetType().Equals(typeof(string)) ? body : restRequest.XmlSerializer.Serialize(body), ParameterType.RequestBody);
                        break;
                }

            }
            return restRequest;
        }

        private IRestResponse SendRequest(IRestRequest restRequest)
        {
            IRestClient restClient = GetRestClient();
            IRestResponse restResponse = restClient.Execute(restRequest);
            return restResponse;
        }

        private IRestResponse<T> SendRequest<T>(IRestRequest restRequest) where T : new()
        {
            IRestClient restClient = GetRestClient();
            //restRequest.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };
            IRestResponse<T> restResponse = restClient.Execute<T>(restRequest);
            
                if (restResponse.ContentType.Equals("application/xml")|| restResponse.ContentType.Equals("text/html; charset=utf-8"))
                {
                    var deserializer = new RestSharp.Deserializers.DotNetXmlDeserializer();
                    restResponse.Data = deserializer.Deserialize<T>(restResponse);
                }
                else
                {
                    restResponse.Data = JsonConvert.DeserializeObject<T>(restResponse.Content);
                }
            return restResponse;
        }

        public IRestResponse PerformGetRequest(string url, Dictionary<string, string> header)
        {
            IRestRequest restrequest = GetRestRequest(url, header,null, Method.GET, null, DataFormat.None);
            IRestResponse restresponse = SendRequest(restrequest);
            return restresponse;
        }

        public IRestResponse<T> PerformGetRequest<T>(string url, Dictionary<string, string> header) where T : new()
        {
            IRestRequest restrequest = GetRestRequest(url, header,null, Method.GET, null, DataFormat.None);
            IRestResponse<T> restresponse = SendRequest<T>(restrequest);
            return restresponse;
        }
        public IRestResponse PerformGetRequest(string url, Dictionary<string, string> header, Dictionary<string, string> queryparameter)
        {
            IRestRequest restrequest = GetRestRequest(url, header, null, Method.GET, null, DataFormat.None);
            if (queryparameter != null)
            {
                foreach (string key in queryparameter.Keys)
                {
                    restrequest.AddQueryParameter(key, queryparameter[key]);
                }
            }
            IRestResponse restresponse = SendRequest(restrequest);
            return restresponse;
        }

        public IRestResponse<T> PerformPostRequest<T>(string url, Dictionary<string, string> header,string tokenvalue, object body, DataFormat dataformat) where T : new()
        {
            IRestRequest restrequest = GetRestRequest(url, header, tokenvalue, Method.POST, body, dataformat);
            IRestResponse<T> restresponse = SendRequest<T>(restrequest);
            return restresponse;
        }

        public IRestResponse<T> PerformPatchRequest<T>(string url, Dictionary<string, string> header, string tokenvalue, object body, DataFormat dataformat) where T : new()
        {
            IRestRequest restrequest = GetRestRequest(url, header, tokenvalue, Method.PATCH, body, dataformat);
            IRestResponse<T> restresponse = SendRequest<T>(restrequest);
            return restresponse;
        }

        public IRestResponse PerformPostRequest(string url, Dictionary<string, string> header, string tokenvalue, object body, DataFormat dataformat)
        {
            IRestRequest restrequest = GetRestRequest(url, header, tokenvalue, Method.POST, body, dataformat);
            IRestResponse restresponse = SendRequest(restrequest);
            return restresponse;
        }

        public IRestResponse<T> PerformPutRequest<T>(string url, Dictionary<string, string> header, string tokenvalue, object body, DataFormat dataformat) where T : new()
        {
            IRestRequest restrequest = GetRestRequest(url, header, tokenvalue, Method.PUT, body, dataformat);
            IRestResponse<T> restresponse = SendRequest<T>(restrequest);
            return restresponse;
        }

        public IRestResponse PerformPutRequest(string url, Dictionary<string, string> header, string tokenvalue, object body, DataFormat dataformat)
        {
            IRestRequest restrequest = GetRestRequest(url, header, tokenvalue, Method.PUT, body, dataformat);
            IRestResponse restresponse = SendRequest(restrequest);
            return restresponse;
        }

        public IRestResponse PerformDeleteRequest(string url, Dictionary<string, string> header, string tokenvalue)
        {
            IRestRequest restrequest = GetRestRequest(url, header, tokenvalue, Method.DELETE, null, DataFormat.None);
            IRestResponse restresponse = SendRequest(restrequest);
            return restresponse;
        }
    }
}
