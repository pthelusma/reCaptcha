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

             var something = verifyRecaptcha(remoteip, privatekey, challenge, response);

            return Json(new {Result = "Success"});
        }

        private async Task<string> verifyRecaptcha(string remoteip, string privatekey, string challenge, string response)
        {

            HttpClient client = new HttpClient();

            var values = new List<KeyValuePair<string, string>>();
            values.Add(new KeyValuePair<string, string>("remoteip", HttpUtility.UrlEncode(remoteip)));
            values.Add(new KeyValuePair<string, string>("privatekey", HttpUtility.UrlEncode(privatekey)));
            values.Add(new KeyValuePair<string, string>("challenge", HttpUtility.UrlEncode(challenge)));
            values.Add(new KeyValuePair<string, string>("response", HttpUtility.UrlEncode(response)));

            var content = new FormUrlEncodedContent(values);
            var resp = await client.PostAsync("http://www.google.com/recaptcha/api/verify", content).ConfigureAwait(false);
            var responseString = await resp.Content.

            return responseString;
  
        }

    }
}
