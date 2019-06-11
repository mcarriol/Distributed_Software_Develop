using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;


namespace Booking
{
    class Encoder
    {
        //converts order object into an xml string 
        public static string Encode(OrderClass order)
        {
            String encoded;
            XmlSerializer ser = new XmlSerializer(typeof(OrderClass));  

            using (StringWriter writer = new StringWriter())
            {
                ser.Serialize(writer, order);
                encoded = writer.ToString();
            }
            //Console.WriteLine("CODED CODED CODED "+encoded);
            return encoded;
        }
    }
}
