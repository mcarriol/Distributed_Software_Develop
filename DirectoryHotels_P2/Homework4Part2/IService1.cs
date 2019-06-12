using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Homework4Part2
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {


        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "Verify?url={url}&url2={url2}")]
        string verification(string url, string url2);

        //returns path expression value of given path : list of nodes, content value 
        [OperationContract]
        [WebGet(ResponseFormat =WebMessageFormat.Json, UriTemplate ="Search?url={url}&path={exp}")]
        string xPathSearch(String url, string exp);
        
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    
}
