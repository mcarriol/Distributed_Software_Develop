using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Web.Script.Serialization;
using System.Net;
using System.IO;

namespace Homework4Part2
{
    public partial class TryIt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string url = @"http://localhost:59271/Service1.svc/Verify?url=" + TextBox1.Text+"&url2="+TextBox4.Text;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            Stream responseStream = response.GetResponseStream();

            StreamReader reader = new StreamReader(responseStream);

            string answer = reader.ReadToEnd();

            if (String.IsNullOrEmpty(answer)==true)
            {
                Label1.Text = "No Errors....Verified";
            }
            else {

                Label1.Text = answer;
            }
          

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string url = @"http://localhost:59271/Service1.svc/Search?url="+TextBox2.Text+"&path="+TextBox3.Text;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            Stream responseStream = response.GetResponseStream();

            StreamReader reader = new StreamReader(responseStream);

            string answer = reader.ReadToEnd();



            Label2.Text = answer;
        }
    }
}