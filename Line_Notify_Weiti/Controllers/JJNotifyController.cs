using System;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;
using isRock.LineNotify;
using Newtonsoft.Json.Linq;

namespace Line_Notify_Example.Controllers
{
    public class JJNotifyController: ApiController
    {
        [HttpPost]
        public HttpResponseMessage Post(NotifyInput notifyInput)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            var ret = Utility.SendNotify(notifyInput.Token, notifyInput.Content);
            res.Content = new ObjectContent<JObject>(JObject.FromObject(new { Msg = ret.message }), new JsonMediaTypeFormatter());
            return res;
        }

        public class NotifyInput
        {
            public string Token { get; set; }
            public string Content { get; set; }
        }
    }
}
