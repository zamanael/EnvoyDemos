using Newtonsoft.Json;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;

namespace VisitorManagement
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ScriptService]
    public class EnvoyWebService : WebService
    {
        [WebMethod]
        //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void HelloOptions()
        {
            var obj = new List<dynamic>
            {
                new
                {
                    label = "Hello",
                    value= "Hello",
                },
                new
                {
                    label = "Hola",
                    value= "Hola",
                },
                new
                {
                    label = "Aloha",
                    value= "Aloha",
                },
            };

            var serializedObj = JsonConvert.SerializeObject(obj);
            Context.Response.ContentType = "application/json";
            Context.Response.Write(serializedObj);
            Context.Response.End();
        }
    }

    public class SelectOptions
    {
        public string label { get; set; }
        public string value { get; set; }

    }
}
