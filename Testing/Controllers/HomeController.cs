using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Testing.Models;

namespace Testing.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Submit(string remoteip, string privatekey, string challenge, string response)
        {

            HttpClient client = new HttpClient();

            var values = new List<KeyValuePair<string, string>>();
            values.Add(new KeyValuePair<string, string>("remoteip", HttpUtility.UrlEncode(remoteip)));
            values.Add(new KeyValuePair<string, string>("privatekey", HttpUtility.UrlEncode(privatekey)));
            values.Add(new KeyValuePair<string, string>("challenge", HttpUtility.UrlEncode(challenge)));
            values.Add(new KeyValuePair<string, string>("response", HttpUtility.UrlEncode(response)));

            var content = new FormUrlEncodedContent(values);
            var postResponse = client.PostAsync("http://www.google.com/recaptcha/api/verify", content).Result;

            string resultContent = postResponse.Content.ReadAsStringAsync().Result;

            string[] responseResults = resultContent.Split(new string[] { "\n", "\\n" }, StringSplitOptions.RemoveEmptyEntries);

            Response resp = new Response()
            {
                result = responseResults[0],
                code = responseResults[1]
            };

            return Json(resp);
        }

        public class Response
        {
            public string result { get; set; }
            public string code { get; set; }
        }

    }
}
