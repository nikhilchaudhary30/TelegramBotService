using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBotService
{
    public class WebReqInitiator : WebClient
    {
        public CookieContainer CookieContainer { get; set; }
        public Uri Uri { get; set; }

        public WebReqInitiator()
            : this(new CookieContainer())
        {
        }

        public WebReqInitiator(CookieContainer cookies)
        {
            this.CookieContainer = cookies;
        }

        protected override WebRequest GetWebRequest(Uri address)
        {
            WebRequest request = base.GetWebRequest(address);
            if (request is HttpWebRequest)
            {
                (request as HttpWebRequest).CookieContainer = this.CookieContainer;
            }
            HttpWebRequest httpRequest = (HttpWebRequest)request;
            httpRequest.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            return httpRequest;
        }

        protected override WebResponse GetWebResponse(WebRequest request)
        {
            WebResponse response = base.GetWebResponse(request);
            String setCookieHeader = response.Headers[HttpResponseHeader.SetCookie];

            if (setCookieHeader != null)
            {
                Cookie cookie = new Cookie();
                cookie.Domain = "www.amazon.in";
                cookie.Name = "csm-hit";
                this.CookieContainer.Add(cookie);
            }

            return response;
        }

        public string GetHTML(string url)
        {
            MethodInfo method = typeof(WebHeaderCollection).GetMethod
                        ("AddWithoutValidate", BindingFlags.Instance | BindingFlags.NonPublic);

            Uri uri = new Uri(url);
            WebRequest req = GetWebRequest(uri);
            req.Method = "GET";
            string key = "user-agent";
            string val = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/61.0.3163.100 Safari/537.36";

            method.Invoke(req.Headers, new object[] { key, val });

            using (StreamReader reader = new StreamReader(GetWebResponse(req).GetResponseStream()))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
