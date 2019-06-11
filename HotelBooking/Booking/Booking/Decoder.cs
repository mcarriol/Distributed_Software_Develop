using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Booking
{
    class Decoder
    {
        //converts xml string into an orderclass object
        public static OrderClass Decode(string encodedOrder)
        {
            OrderClass decoded;
            XmlSerializer ser = new XmlSerializer(typeof(OrderClass));

            using (StringReader reader = new StringReader(encodedOrder))
            {
                decoded = (OrderClass)ser.Deserialize(reader);
            }
          //  Console.WriteLine("DECODED DECODED DECODED "+decoded.ToString());
            return decoded;
        }

       

    }
}
