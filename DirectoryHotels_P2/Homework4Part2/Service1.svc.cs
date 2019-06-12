using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.IO;
using System.Xml.XPath;


namespace Homework4Part2
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {

        //verification validates the XML file against XSD api returns No Error 
        //or Error message showing the the error point '
        public static string answ;
        public string verification(string url, string url2)
        {
            //string answ="";

            XmlReaderSettings settings = new XmlReaderSettings();
            settings.ValidationType = ValidationType.Schema;
            settings.Schemas.Add(null, url2);
            settings.ValidationFlags |= XmlSchemaValidationFlags.ProcessInlineSchema;
            settings.ValidationFlags |= XmlSchemaValidationFlags.ProcessSchemaLocation;
            settings.ValidationFlags |= XmlSchemaValidationFlags.ReportValidationWarnings;
            settings.ValidationEventHandler += new ValidationEventHandler(validate);
            settings.IgnoreWhitespace = true;
            XmlReader book = XmlReader.Create(url, settings);

            while (book.Read())
            {
                //answ = "No Error";
            }
            return answ;
        }
        private static void validate(object sender, ValidationEventArgs e)
        {
            if (e.Severity != XmlSeverityType.Warning)
            {
                 answ = answ+ "Error message" + e.Message + "    ";
            }
        }



        public string xPathSearch(String url, string exp) {
            string answ = " ";

            // XPathDocument dx = new XPathDocument(@"C:\Users\arrio\source\repos\Homework4\Homework4\XMLFile1.xml");
            XPathDocument dx = new XPathDocument(url);
            // string exp2 = "/hotels/hotel/address[@buslines='30, 90, 250']";

            // Console.WriteLine(dx);
            XPathNavigator nav = dx.CreateNavigator();
            XPathNodeIterator iter = nav.Select(exp);
            while (iter.MoveNext())
            {
                string temp = iter.Current.Value;
              
              
                answ += temp;

            }




            return answ;




        }

    }
}
