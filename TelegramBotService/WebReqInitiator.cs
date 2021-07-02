using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;

namespace TelegramBotService
{
    public class WebReqInitiator : WebClient
    {
        public CookieContainer CookieContainer { get; set; }
        public Uri Uri { get; set; }
        static TelegramBotClient telegramBotClient = new TelegramBotClient(Convert.ToString(ConfigurationManager.AppSettings["TelegramBotToken"]));

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
            try
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
            catch (Exception ex)
            {
                #region Exception
                List<string> list = new List<string>();
                list.Add("ServiceName: TelegramBotService, ClassName: WebReqInitiator, MethodName: GetWebRequest");
                list.Add("Message:  " + ex?.Message?.ToString());
                list.Add("StackTrace:  " + ex?.StackTrace?.ToString());
                list.Add("InnerException.Message:  " + Convert.ToString(ex?.InnerException?.Message));
                list.Add("InnerException.StackTrace:  " + Convert.ToString(ex?.InnerException?.StackTrace));
                telegramBotClient.SendTextMessageAsync(1715334607, exceptionStringBuilder(list.ToArray()));
                System.Threading.Thread.Sleep(5000);
                #endregion
                return null;
            }
        }

        protected override WebResponse GetWebResponse(WebRequest request)
        {
            try
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
            catch (Exception ex)
            {
                #region Exception
                List<string> list = new List<string>();
                list.Add("ServiceName: TelegramBotService, ClassName: WebReqInitiator, MethodName: GetWebResponse");
                list.Add("Message:  " + ex?.Message?.ToString());
                list.Add("StackTrace:  " + ex?.StackTrace?.ToString());
                list.Add("InnerException.Message:  " + Convert.ToString(ex?.InnerException?.Message));
                list.Add("InnerException.StackTrace:  " + Convert.ToString(ex?.InnerException?.StackTrace));
                telegramBotClient.SendTextMessageAsync(1715334607, exceptionStringBuilder(list.ToArray()));
                System.Threading.Thread.Sleep(5000);
                #endregion
                return null;
            }
        }

        public string GetHTML(string url)
        {
            try
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
            catch (Exception ex)
            {
                #region Exception
                List<string> list = new List<string>();
                list.Add("ServiceName: TelegramBotService, ClassName: WebReqInitiator, MethodName: GetHTML");
                list.Add("Message:  " + ex?.Message?.ToString());
                list.Add("StackTrace:  " + ex?.StackTrace?.ToString());
                list.Add("InnerException.Message:  " + Convert.ToString(ex?.InnerException?.Message));
                list.Add("InnerException.StackTrace:  " + Convert.ToString(ex?.InnerException?.StackTrace));
                telegramBotClient.SendTextMessageAsync(1715334607, exceptionStringBuilder(list.ToArray()));
                System.Threading.Thread.Sleep(5000);
                #endregion
                return string.Empty;
            }
        }

        public static string exceptionStringBuilder(String[] str = null)
        {
            StringBuilder errMsg = new StringBuilder();
            errMsg.AppendLine();
            errMsg.AppendLine("Exception occured at: " + DateTime.Now.ToString(Constant.DateTimeFormat));
            errMsg.AppendLine();
            foreach (var l in str)
            {
                errMsg.AppendLine(l);
                errMsg.AppendLine();
            }
            errMsg.AppendLine();
            return errMsg.ToString();
        }
    }
}
