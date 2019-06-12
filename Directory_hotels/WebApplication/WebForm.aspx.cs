using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace WebApplication
{
    public partial class WebForm : System.Web.UI.Page
    {
        public XmlDocument doc = new XmlDocument();
        public XmlNode node;
        //public List<string> contents = new List<string>();
        String output = "";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //displays element tag names, text contents, attribute names,
            //attribute values, 

            //doc.Load(@"C:\Users\arrio\source\repos\Homework4\Homework4\XMLFile1.xml");
            doc.Load(TextBox1.Text);
            node = doc.DocumentElement;
            PrintNode(node);
            Label1.Text = output;
        
        }

        public void PrintNode(XmlNode node)
        {
            if (node == null)
                System.Environment.Exit(1);

         
                output = output + "<br/>" + node.Name + node.Value;
            
            if(node.Name=="hotel")
            {
                output += " stars:"+node.Attributes["stars"].Value;
            }
            if (node.Name == "address" && node.Attributes["buslines"] != null)
            {
                output += " buslines:" + node.Attributes["buslines"].Value;
            }
           
          
            if (node.HasChildNodes)
            {
                XmlNodeList children = node.ChildNodes;
                foreach (XmlNode child in children)
                    PrintNode(child);
            }
        }


       
      
    }
}