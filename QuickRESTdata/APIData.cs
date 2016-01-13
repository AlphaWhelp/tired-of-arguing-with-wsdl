using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Net;// Includes

namespace QuickREST
{
    public delegate string uriArgs(params string[] args);
    public delegate APIData newChildObject(string uri);

    // Inherit this if you do not need to authenticate with the API
    // Otherwise see APIDataWithKey below
    public abstract class APIData
    {
        protected JObject _APIResult; // contains raw JObject result
        protected string _APIuri; // part of the URL after the TLD, including query strings.
        protected abstract string root_api_uri { get; } // the TLD root

        protected WebRequest request = null;
        protected WebResponse response = null;
        protected string jsonString = "";
        protected string uri = "";

        /// <summary>
        /// Get this property to get the results of a request
        /// </summary>
        public JObject APIResult { get { return _APIResult; } }

        /// <summary>
        /// Get this property to get the unformatted URL of the request.
        /// </summary>
        public string APIuri { get { return root_api_uri + _APIuri; } }

        //override this with code to make the actual API call
        /// <summary>
        /// Makes a call to a RESTful service and returns the result
        /// </summary>
        /// <param name="finalURI">A formatted string URI</param>
        /// <returns>Newtonsoft.Json.Linq.JObject</returns>
        protected abstract JObject makeRESTrequest(string finalURI);

        protected void initRequest()
        {
            request = null;
            response = null;
            jsonString = "";
            uri = "";
        }

        /// <summary>
        /// Makes a REST request and stores the result inside of the APIData object APIResult property.
        /// Check the returned bool to see if it was successful.
        /// </summary>
        /// <param name="anonURI">Delegated function containing URI to be formatted.</param>
        /// <param name="arguments">Arguments for formatting anonURI</param>
        /// <returns>bool</returns>
        public bool obtainAPIresults(uriArgs anonURI, params string[] arguments)
        {
            try
            {
                initRequest();
                _APIResult = makeRESTrequest(anonURI(arguments));
                return true;
            }
            catch (Exception e)
            {
                errorLog(e);
                return false;
            }
        }

        /// <summary>
        /// Handles error logging.
        /// </summary>
        /// <param name="e">Exception</param>
        protected virtual void errorLog(Exception e)
        {
            // override with logging code
        }
    }

    public abstract class APIDataWithKey : APIData
    {
        protected abstract string user_api_id { get; }
        protected abstract string user_api_key { get; }
    }
}
