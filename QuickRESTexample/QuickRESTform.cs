using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuickREST;
using Newtonsoft.Json.Linq;// Includes

namespace QuickRESTexample
{
    public partial class QuickRESTform : Form
    {
        // Bridge library needed to access the APIs
        QuickRESTlib qrl;

        public QuickRESTform() // Constructor
        {
            InitializeComponent();
            qrl = new QuickRESTlib();
        }

        #region Event handlers to make the API requests.
        private void btnGetAll_Click(object sender, EventArgs e)
        {
            APIData ad = qrl.apiInformation["Get all"];
            uriArgs noargument = x => ad.APIuri;
            bool check = ad.obtainAPIresults(noargument, null);
            if (check) outputAllJson(ad.APIResult);
            else txtResults.Text = "Error";
        }

        private void btnUSA_Click(object sender, EventArgs e)
        {
            APIData ad = qrl.apiInformation["Get iso code"];
            string[] args = { "iso3code", "USA" };
            uriArgs arguments = x => String.Format(ad.APIuri, x[0], x[1]);
            bool check = ad.obtainAPIresults(arguments, args);
            if (check) outputJson(ad.APIResult);
            else txtResults.Text = "Error";
        }

        private void btnIT_Click(object sender, EventArgs e)
        {
            APIData ad = qrl.apiInformation["Get iso code"];
            string[] args = { "iso2code", "IT" };
            uriArgs arguments = x => String.Format(ad.APIuri, x[0], x[1]);
            bool check = ad.obtainAPIresults(arguments, args);
            if (check) outputJson(ad.APIResult);
            else txtResults.Text = "Error";
        }

        private void btnCA_Click(object sender, EventArgs e)
        {
            APIData ad = qrl.apiInformation["Search"];
            string[] args = { "ca" };
            uriArgs arguments = x => String.Format(ad.APIuri, x[0]);
            bool check = ad.obtainAPIresults(arguments, args);
            if (check) outputAllJson(ad.APIResult);
            else txtResults.Text = "Error";
        }
        #endregion

        #region Methods to parse resultant data and output it to the text box
        private void outputJson(JObject jobj)
        {
            txtResults.Text = "";
            JToken jt = jobj["RestResponse"]["result"];
            JObject jparsed = jt.Value<JObject>();
            foreach (var x in jparsed)
            {
                txtResults.Text += x.Key + " - " + x.Value + "\r\n";
            }
        }

        private void outputAllJson(JObject jobj)
        {
            try
            {
                txtResults.Text = "";
                JToken jt = jobj["RestResponse"]["result"];
                var jparsed = jt.Values<JObject>();

                foreach (var x in jparsed)
                {
                    foreach (var y in x)
                    {
                        txtResults.Text += y.Key + " - " + y.Value + "\r\n";
                    }
                    txtResults.Text += "\r\n---\r\n\r\n";
                }
            }
            catch
            {
                outputJson(jobj);
            }
        }
        #endregion
    }
}
