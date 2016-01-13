using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickREST
{

    // Inherit this to form the core of your application REST consuming code
    public abstract class RESTfulClientBase
    {
        public Dictionary<string, APIData> apiInformation;

        /// <summary>
        /// Adds an APIData with the specified URL inside the referenced dictionary with the listed Key.
        /// </summary>
        /// <param name="key">API Key</param>
        /// <param name="apidata">Function used to pass constructor of child class</param>
        /// <param name="url">argument for the child's constructor</param>
        /// <param name="api_dictionary">Should always be apiInformation</param>
        protected virtual void apiDictAdd(string key, string uri, newChildObject apiData, Dictionary<string, APIData> api_dictionary)
        {
            api_dictionary.Add(key, apiData(uri));
        }

        /// <summary>
        /// Initializes the Dictionary with APIData objects
        /// This dictionary should only one entry per unique URL
        /// This is intended to call APIdictAdd() several times
        /// </summary>
        /// <param name="dict">Should always be apiInformation</param>
        protected abstract void initializeAPIdict(Dictionary<string, APIData> dict);
    }
}
