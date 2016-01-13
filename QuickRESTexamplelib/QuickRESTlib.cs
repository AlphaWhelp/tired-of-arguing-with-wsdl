using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickREST;
using Newtonsoft.Json.Linq;
using System.Net;
using System.IO;

namespace QuickRESTexample
{
    public class ExampleAPIData : APIData
    {
        protected override string root_api_uri { get { return @"http://services.groupkt.com/country"; } }

        protected override JObject makeRESTrequest(string finalURI)
        {
            request = WebRequest.Create(finalURI);
            ((HttpWebRequest)request).Accept = "application/json";
            response = request.GetResponse();
            jsonString = new StreamReader(response.GetResponseStream(), new UTF8Encoding()).ReadToEnd();
            return JObject.Parse(jsonString);
        }

        public ExampleAPIData(string uri)
        {
            _APIuri = uri;
            _APIResult = null;
        }
    }

    public class QuickRESTlib : RESTfulClientBase
    {
        newChildObject nco = uri => new ExampleAPIData(uri);

        public QuickRESTlib()
        {
            apiInformation = new Dictionary<string, APIData>();
            initializeAPIdict(apiInformation);
        }

        protected override void initializeAPIdict(Dictionary<string, APIData> dict)
        {
            apiDictAdd("Get all", @"/get/all", nco, dict);
            apiDictAdd("Get iso code", @"/get/{0}/{1}", nco, dict);
            apiDictAdd("Search", @"/search?text={0}", nco, dict);
        }
    }
}
