//------------------------------------------------------------------------------
// <self-generated>
//    This code was developed by Nikhil Chaudhary on 19-05-2021.
//    Vaccine Notification Service
//    Manual changes to this file may cause unexpected behavior in your application.
// </self-generated>
//------------------------------------------------------------------------------
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Media;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Telegram.Bot;

namespace TelegramBotService
{
    public class ServiceMethods
    {
        #region Service Helping Components

        private static Dictionary<int, string> URLs { get; set; }
        static TelegramBotClient telegramBotClient = new TelegramBotClient(Convert.ToString(ConfigurationManager.AppSettings["TelegramBotToken"]));

        public ServiceMethods()
        {
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
        }

        public void Start()
        {
            telegramBotClient.SendTextMessageAsync(1715334607, Constant.ServiceStartMessage);
            TelegramBotInitiator();
        }

        public void Stop()
        {
            telegramBotClient.SendTextMessageAsync(1715334607, Constant.ServiceStopMessage);
        }

        #endregion

        #region Helpers

        public static List<string> Utility()
        {
            List<string> list = new List<string>();

            #region Battery Info
            System.Windows.Forms.PowerStatus pwr = System.Windows.Forms.SystemInformation.PowerStatus;
            list.Add("Please find the below system details.");
            list.Add("Battery Charge Status: " + pwr.BatteryChargeStatus.ToString());
            list.Add("Battery Life Percent: " + (int)(pwr.BatteryLifePercent * 100) + "%");
            list.Add("Battery Life Remaining: " + pwr.BatteryLifeRemaining.ToString());
            list.Add("Power Line Status: " + pwr.PowerLineStatus.ToString());
            #endregion

            #region Internet Info
            System.Net.WebClient wc = new System.Net.WebClient();
            DateTime dt1 = DateTime.Now;
            byte[] data = wc.DownloadData("http://google.com");
            DateTime dt2 = DateTime.Now;
            list.Add("Internet Status: " + Math.Round((data.Length / 1024) / (dt2 - dt1).TotalSeconds, 2) + " Kb/Sec");
            list.Add("Host Name: " + Dns.GetHostName().ToString());
            #endregion

            #region Memory Info
            PerformanceCounter cpuCounter;
            PerformanceCounter ramCounter;
            PerformanceCounter diskCounter;

            cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            ramCounter = new PerformanceCounter("Memory", "Available MBytes");
            diskCounter = new PerformanceCounter("PhysicalDisk", "% Disk Time", "_Total");
            ramCounter.NextValue(); ramCounter.NextValue();
            cpuCounter.NextValue(); cpuCounter.NextValue();
            diskCounter.NextValue(); diskCounter.NextValue();
            list.Add("CPU Usage: " + cpuCounter.NextValue() + "%");
            list.Add("RAM Usage: " + ramCounter.NextValue() + " MB");
            list.Add("DISK Usage: " + diskCounter.NextValue() + "%");
            #endregion

            list.Add(Constant.ServiceRunningMessage);
            return list;
        }

        #region API Models
        public class Session
        {
            public string session_id { get; set; }
            public string date { get; set; }
            public int available_capacity { get; set; }
            public int min_age_limit { get; set; }
            public string vaccine { get; set; }
            public List<string> slots { get; set; }
            public int available_capacity_dose1 { get; set; }
            public int available_capacity_dose2 { get; set; }
        }

        public class Center
        {
            public int center_id { get; set; }
            public string name { get; set; }
            public string address { get; set; }
            public string state_name { get; set; }
            public string district_name { get; set; }
            public string block_name { get; set; }
            public int pincode { get; set; }
            public int lat { get; set; }
            public int @long { get; set; }
            public string from { get; set; }
            public string to { get; set; }
            public string fee_type { get; set; }
            public List<Session> sessions { get; set; }
        }

        public class Root
        {
            public List<Center> centers { get; set; }
        }
        #endregion

        #region String Builders
        public static string emailStringBuilder(String[] str = null, List<List<string>> listString = null)
        {
            StringBuilder errMsg = new StringBuilder();
            errMsg.AppendLine();
            errMsg.AppendLine("Hi All,");
            errMsg.AppendLine();
            if (listString != null)
            {
                foreach (var l in listString)
                {
                    foreach (var i in l)
                    {
                        errMsg.AppendLine(i);
                    }
                    errMsg.AppendLine();
                    errMsg.AppendLine();
                }
            }
            else if (str != null)
            {
                foreach (var l in str)
                {
                    errMsg.AppendLine(l);
                }
                errMsg.AppendLine("");
            }
            errMsg.AppendLine("Hurry book your slot at: https://selfregistration.cowin.gov.in/");
            errMsg.AppendLine("");
            errMsg.AppendLine("Regards,");
            errMsg.AppendLine("Service Bot");
            return errMsg.ToString();
        }

        public static string StringBuilder(String[] str)
        {
            StringBuilder errMsg = new StringBuilder();
            errMsg.AppendLine();
            errMsg.AppendLine();
            foreach (var i in str)
            {
                errMsg.AppendLine(i);
            }
            errMsg.AppendLine();
            return errMsg.ToString();
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

        public static string gameStringBuilder(String[] str = null, List<List<string>> listString = null)
        {
            StringBuilder errMsg = new StringBuilder();
            errMsg.AppendLine();
            errMsg.AppendLine("Please find the below details for free game:");
            errMsg.AppendLine("");
            foreach (var l in listString)
            {
                foreach (var i in l)
                {
                    errMsg.AppendLine(i);
                }
                errMsg.AppendLine();
                errMsg.AppendLine();
            }
            return errMsg.ToString();
        }

        public static IEnumerable<string> StringSplitter(string str, int chunkSize)
        {
            return Enumerable.Range(0, str.Length / chunkSize)
                .Select(i => str.Substring(i * chunkSize, chunkSize));
        }


        #endregion

        #region Log Writing
        public static void LogWrite(string logMessage)
        {
            if (Convert.ToInt32(ConfigurationManager.AppSettings["isLogging"]) == 1)
            {
                string _Path = Convert.ToString(ConfigurationManager.AppSettings["LogPath"]);
                try
                {
                    if (!string.IsNullOrWhiteSpace(_Path))
                    {
                        using (StreamWriter w = File.AppendText(_Path + "\\" + "TelegramBot_" + DateTime.Now.ToString("dd-MM-yyyy") + ".txt"))
                        {
                            Log(logMessage, w);
                        }
                    }
                }
                catch (Exception ex)
                {
                }
            }
        }

        public static void Log(string logMessage, TextWriter txtWriter)
        {
            try
            {
                txtWriter.Write("\r\n" + logMessage + " Date: " + DateTime.Now.ToString(Constant.DateTimeFormat));
            }
            catch (Exception ex)
            {
            }
        }
        #endregion

        #endregion

        #region Telegram BOT

        public static void TelegramBotInitiator()
        {
            telegramBotClient.StartReceiving();
            telegramBotClient.OnMessage += TelegramBotClient_OnMessage;
            telegramBotClient.OnMessageEdited += TelegramBotClient_OnMessage;
        }

        private async static void TelegramBotClient_OnMessage(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            SystemSounds.Beep.Play();
            if (e.Message.Type == Telegram.Bot.Types.Enums.MessageType.Text)
            {
                Helpercommands(sender, e);
            }
            else if (e.Message.Type == Telegram.Bot.Types.Enums.MessageType.Photo)
            {
                await telegramBotClient.SendTextMessageAsync(e.Message.Chat.Id, "This phase is under development...");
            }
            else if (e.Message.Type == Telegram.Bot.Types.Enums.MessageType.Audio)
            {
                await telegramBotClient.SendTextMessageAsync(e.Message.Chat.Id, "This phase is under development...");
            }
            else if (e.Message.Type == Telegram.Bot.Types.Enums.MessageType.Video)
            {
                await telegramBotClient.SendVideoAsync(e.Message.Chat.Id, "This phase is under development...");
            }
            else if (e.Message.Type == Telegram.Bot.Types.Enums.MessageType.Poll)
            {
                await telegramBotClient.SendTextMessageAsync(e.Message.Chat.Id, "This phase is under development...");
            }
            else if (e.Message.Type == Telegram.Bot.Types.Enums.MessageType.Sticker)
            {
                await telegramBotClient.SendTextMessageAsync(e.Message.Chat.Id, "This phase is under development...");
            }
        }

        public async static void Helpercommands(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            SystemSounds.Beep.Play();
            e.Message.Text.Trim();
            LogWrite("\r\n\n\n\n****************** Log Started ******************");
            LogWrite("Name: " + e.Message.Chat.FirstName + " " + e.Message.Chat.LastName + ", Username: " + e.Message.Chat.Username + ", ChatID: " + e.Message.Chat.Id + ", Message: " + e.Message.Text + ",");
            if (e.Message.Text.ToLower().Contains("help"))
            {
                List<string> help = new List<string>();
                //help.Add("1. For vaccine notifications please type below commands: ");
                //help.Add("      > Chandigarh");
                //help.Add("      > Mohali");
                //help.Add("      > Karnal");
                //help.Add("      > Agra");
                //help.Add("      > Faridabad");
                //help.Add("      > Sonipat");
                //help.Add("      > Hyderabad");
                //help.Add("      > Mumbai");
                //help.Add("      > Pune");
                //help.Add("      > New Delhi");
                //help.Add("      > Central Delhi");
                //help.Add("      > West Delhi");
                //help.Add("      > North West Delhi");
                //help.Add("      > South East Delhi");
                //help.Add("      > East Delhi");
                //help.Add("      > North Delhi");
                //help.Add("      > North East Delhi");
                //help.Add("      > Shahdara");
                //help.Add("      > South Delhi");
                //help.Add("      > South West Delhi");
                //help.Add("      > Jaipur I");
                //help.Add("      > Jaipur II");
                //help.Add(" ");
                help.Add("1. For system notifications please type 'Info'.");
                help.Add(" ");
                help.Add("2. For free game noifications please type 'Game'.");
                help.Add(" ");
                help.Add("3. For date noifications please type 'Date'.");
                help.Add(" ");
                help.Add("4. For weather noifications please type 'Weather placename', E.g: Weather Chandigarh or Weather Delhi");
                help.Add(" ");
                help.Add("5. For covid report noifications please type below commands: ");
                help.Add("      > For all over type: 'Covid All'");
                help.Add("      > For state wise type: 'Covid StateName' like Covid Chandigarh");
                help.Add(" ");
                help.Add("6. For searching please type 'Search Text', E.g: Search C#.NET");
                help.Add(" ");
                help.Add("7. For horoscope please type 'Horoscope SignName', E.g: Horoscope Leo");
                help.Add(" ");
                help.Add("8. For stocks please type 'Stock StockSymbol', E.g: Stock ITC");
                help.Add(" ");
                help.Add("9. For gaming channel please type 'Ranzo'");
                help.Add(" ");
                help.Add("10. For PS5 availability check on Amazon/ Flipkart please type 'PS5 Check'");
                help.Add(" ");
                help.Add("11. For requesting something new, please type 'Request keywords'");
                await telegramBotClient.SendTextMessageAsync(e.Message.Chat.Id, StringBuilder(help.ToArray()));
            }
            //else if (e.Message.Text.ToLower() == "chandigarh")
            //{
            //    TelegramBotAPIInitiator(e.Message.Chat.Id, "108", e);
            //}
            //else if (e.Message.Text.ToLower() == "mohali")
            //{
            //    TelegramBotAPIInitiator(e.Message.Chat.Id, "496", e);
            //}
            //else if (e.Message.Text.ToLower() == "karnal")
            //{
            //    TelegramBotAPIInitiator(e.Message.Chat.Id, "203", e);
            //}
            //else if (e.Message.Text.ToLower() == "agra")
            //{
            //    TelegramBotAPIInitiator(e.Message.Chat.Id, "622", e);
            //}
            //else if (e.Message.Text.ToLower() == "faridabad")
            //{
            //    TelegramBotAPIInitiator(e.Message.Chat.Id, "199", e);
            //}
            //else if (e.Message.Text.ToLower() == "sonipat")
            //{
            //    TelegramBotAPIInitiator(e.Message.Chat.Id, "198", e);
            //}
            //else if (e.Message.Text.ToLower() == "hyderabad")
            //{
            //    TelegramBotAPIInitiator(e.Message.Chat.Id, "581", e);
            //}
            //else if (e.Message.Text.ToLower() == "mumbai")
            //{
            //    TelegramBotAPIInitiator(e.Message.Chat.Id, "395", e);
            //}
            //else if (e.Message.Text.ToLower() == "pune")
            //{
            //    TelegramBotAPIInitiator(e.Message.Chat.Id, "363", e);
            //}
            //else if (e.Message.Text.ToLower() == "new delhi")
            //{
            //    TelegramBotAPIInitiator(e.Message.Chat.Id, "140", e);
            //}
            //else if (e.Message.Text.ToLower() == "central delhi")
            //{
            //    TelegramBotAPIInitiator(e.Message.Chat.Id, "141", e);
            //}
            //else if (e.Message.Text.ToLower() == "west delhi")
            //{
            //    TelegramBotAPIInitiator(e.Message.Chat.Id, "142", e);
            //}
            //else if (e.Message.Text.ToLower() == "north west delhi")
            //{
            //    TelegramBotAPIInitiator(e.Message.Chat.Id, "143", e);
            //}
            //else if (e.Message.Text.ToLower() == "south east delhi")
            //{
            //    TelegramBotAPIInitiator(e.Message.Chat.Id, "144", e);
            //}
            //else if (e.Message.Text.ToLower() == "east delhi")
            //{
            //    TelegramBotAPIInitiator(e.Message.Chat.Id, "145", e);
            //}
            //else if (e.Message.Text.ToLower() == "north delhi")
            //{
            //    TelegramBotAPIInitiator(e.Message.Chat.Id, "146", e);
            //}
            //else if (e.Message.Text.ToLower() == "north east delhi")
            //{
            //    TelegramBotAPIInitiator(e.Message.Chat.Id, "147", e);
            //}
            //else if (e.Message.Text.ToLower() == "shahdara")
            //{
            //    TelegramBotAPIInitiator(e.Message.Chat.Id, "148", e);
            //}
            //else if (e.Message.Text.ToLower() == "south delhi")
            //{
            //    TelegramBotAPIInitiator(e.Message.Chat.Id, "149", e);
            //}
            //else if (e.Message.Text.ToLower() == "south west delhi")
            //{
            //    TelegramBotAPIInitiator(e.Message.Chat.Id, "150", e);
            //}
            //else if (e.Message.Text.ToLower() == "jaipur i")
            //{
            //    TelegramBotAPIInitiator(e.Message.Chat.Id, "505", e);
            //}
            //else if (e.Message.Text.ToLower() == "jaipur ii")
            //{
            //    TelegramBotAPIInitiator(e.Message.Chat.Id, "506", e);
            //}
            else if (e.Message.Text.ToLower() == "hi" || e.Message.Text.ToLower() == "hello" || e.Message.Text.ToLower() == "hey" || e.Message.Text.ToLower() == "hola" || e.Message.Text.ToLower() == "whatsup" || e.Message.Text.ToLower() == "wassup" || e.Message.Text.ToLower() == "ssup")
            {
                await telegramBotClient.SendTextMessageAsync(e.Message.Chat.Id, e.Message.Text.ToLower() + " " + e.Message.Chat.FirstName + " " + e.Message.Chat.LastName + " you can type 'Help' for Commands!");
            }
            else if (e.Message.Text.ToLower().Contains("/start"))
            {
                List<string> list = new List<string>();
                int hour = DateTime.Now.Hour;
                var greeting = (hour < 12 ? "Good morning" : hour < 16 ? "Good afternoon" : "Good evening");
                list.Add(greeting + " " + e.Message.Chat.FirstName + " " + e.Message.Chat.LastName);
                list.Add("");
                list.Add("Welcome to notification service");
                list.Add("Please type 'Help' for commands!");
                await telegramBotClient.SendTextMessageAsync(e.Message.Chat.Id, StringBuilder(list.ToArray()));
            }
            else if (e.Message.Text.ToLower().Contains("info"))
            {
                await telegramBotClient.SendTextMessageAsync(e.Message.Chat.Id, StringBuilder(Utility().ToArray()));
            }
            else if (e.Message.Text.ToLower() == "nikhil")
            {
                await telegramBotClient.SendTextMessageAsync(e.Message.Chat.Id, "Ohh Nikhil, hmm is my creator. You should Thank him :)");
            }
            else if (e.Message.Text.ToLower() == "game")
            {
                TelegramBotGameAPIInitiator(e.Message.Chat.Id, "", e);
            }
            else if (e.Message.Text.ToLower().Contains("date") || e.Message.Text.ToLower().Contains("datetime") || e.Message.Text.ToLower().Contains("time") || e.Message.Text.ToLower().Contains("clock"))
            {
                List<string> list = new List<string>();
                var britishZone = TimeZoneInfo.FindSystemTimeZoneById("GMT Standard Time");
                var aus = TimeZoneInfo.FindSystemTimeZoneById("AUS Eastern Standard Time");
                var can = TimeZoneInfo.FindSystemTimeZoneById("Atlantic Standard Time");
                var uae = TimeZoneInfo.FindSystemTimeZoneById("Arabian Standard Time");
                var ams = TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time");
                var Los_Angeles = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");
                list.Add("World Date Time");
                list.Add("");
                list.Add("UTC : " + DateTime.UtcNow.ToString(Constant.DateTimeFormat));
                list.Add("");
                list.Add("India: " + DateTime.Now.ToString(Constant.DateTimeFormat));
                list.Add("");
                list.Add("UK: " + TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.Local, britishZone).ToString(Constant.DateTimeFormat));
                list.Add("");
                list.Add("Melbourne: " + TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.Local, aus).ToString(Constant.DateTimeFormat));
                list.Add("");
                list.Add("Ontario: " + TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.Local, can).ToString(Constant.DateTimeFormat));
                list.Add("");
                list.Add("Dubai: " + TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.Local, uae).ToString(Constant.DateTimeFormat));
                list.Add("");
                list.Add("Amsterdam/ Berlin: " + TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.Local, ams).ToString(Constant.DateTimeFormat));
                list.Add("");
                list.Add("Los Angeles: " + TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.Local, Los_Angeles).ToString(Constant.DateTimeFormat));
                await telegramBotClient.SendTextMessageAsync(e.Message.Chat.Id, StringBuilder(list.ToArray()));
            }
            else if (e.Message.Text.ToLower().Contains("weather"))
            {
                var txt = e.Message.Text.Split(' ');
                if (txt.Length > 1)
                {
                    if (txt.Length > 2)
                    {
                        TelegramBotWeatherAPIInitiator(e.Message.Chat.Id, e.Message.Text.Split(' ', (char)2)[1], e);
                    }
                    else
                    {
                        TelegramBotWeatherAPIInitiator(e.Message.Chat.Id, txt[1], e);
                    }
                }
                else
                {
                    await telegramBotClient.SendTextMessageAsync(e.Message.Chat.Id, "Please use keywords like: 'Weather Chandigarh'");
                }
            }
            else if (e.Message.Text.ToLower().Contains("covid"))
            {
                var txt = e.Message.Text.Split(' ');
                if (txt.Length > 1)
                {
                    if (txt[1].ToLower() == "all")
                    {
                        TelegramBotCovidInfoAPIInitiator(e.Message.Chat.Id, "", e, "All");
                    }
                    else
                    {
                        if (txt.Length > 2)
                        {
                            TelegramBotCovidInfoAPIInitiator(e.Message.Chat.Id, e.Message.Text.Split(' ', (char)2)[1], e, "State");
                        }
                        else
                        {
                            TelegramBotCovidInfoAPIInitiator(e.Message.Chat.Id, txt[1], e, "State");
                        }
                    }
                }
                else
                {
                    await telegramBotClient.SendTextMessageAsync(e.Message.Chat.Id, "Please use keywords like: 'Weather Chandigarh'");
                }
            }
            else if (e.Message.Text.ToLower() == "ranzo")
            {
                List<string> list = new List<string>();
                list.Add("Hey welcome to best gaming channel ever");
                list.Add("Subscribe Ranzo YT: " + "https://www.youtube.com/c/RanzoYT");
                list.Add("");
                list.Add("Click on below links to watch amazing videos: ");
                list.Add("https://www.youtube.com/watch?v=M5gjUT33EYc");
                list.Add("");
                list.Add("https://www.youtube.com/watch?v=kRUq3vQDPY4");
                list.Add("");
                list.Add("https://www.youtube.com/watch?v=JnbTzoxwe-M");
                list.Add("");
                list.Add("https://www.youtube.com/watch?v=qzposQ-Da5Y");
                list.Add("");
                list.Add("https://www.youtube.com/watch?v=PmwzxdAihxg");
                list.Add("");
                list.Add("A Valorant Montage: " + "https://www.youtube.com/watch?v=-hYjgI1oZxY");
                list.Add("");
                using (var stream = File.Open(Convert.ToString(ConfigurationManager.AppSettings["PhotoPath"]), FileMode.Open))
                {
                    var rep = await telegramBotClient.SendPhotoAsync(e.Message.Chat.Id, stream, StringBuilder(list.ToArray()));
                }
            }
            else if (e.Message.Text.ToLower().Contains("search"))
            {
                var txt = e.Message.Text.Split(' ');
                if (txt.Length > 1)
                {
                    TelegramBotSearchAPIInitiator(e.Message.Chat.Id, e.Message.Text.Split(' ', (char)2)[1], e);
                }
            }
            else if (e.Message.Text.ToLower().Contains("horoscope"))
            {
                var txt = e.Message.Text.Split(' ');
                if (txt.Length > 1)
                {
                    TelegramBotHoroscopeAPIInitiator(e.Message.Chat.Id, e.Message.Text.Split(' ', (char)2)[1], e);
                }
            }
            else if (e.Message.Text.ToLower().Contains("stock"))
            {
                var txt = e.Message.Text.Split(' ');
                if (txt.Length > 1)
                {
                    TelegramBotStockAPIInitiator(e.Message.Chat.Id, e.Message.Text.Split(' ', (char)2)[1], e);
                }
            }
            else if (e.Message.Text.ToLower() == "send alert")
            {
                TelegramBotAlertSendInitiator(e);
            }
            else if (e.Message.Text.ToLower().Contains("ps5"))
            {
                var txt = e.Message.Text.Split(' ');
                if (txt.Length > 1)
                {
                    TelegramBotPS5StockAPIInitiator(e.Message.Chat.Id, e.Message.Text.Split(' ', (char)2)[1], e);
                }
            }
            else if (e.Message.Text.ToLower().Contains("insta360"))
            {
                var txt = e.Message.Text.Split(' ');
                if (txt.Length > 1)
                {
                    TelegramBotInsta360GO2StockAPIInitiator(e.Message.Chat.Id, e.Message.Text.Split(' ', (char)2)[1], e);
                    TelegramBotInsta360XOneStockAPIInitiator(e.Message.Chat.Id, e.Message.Text.Split(' ', (char)2)[1], e);
                }
            }
            else if (e.Message.Text.ToLower().Contains("request"))
            {
                var txt = e.Message.Text.Split(' ');
                if (txt.Length > 1)
                {
                    await telegramBotClient.SendTextMessageAsync(e.Message.Chat.Id, "Request noted for " + e.Message.Text.Split(' ', (char)2)[1]);
                }
            }
            else
            {
                await telegramBotClient.SendTextMessageAsync(e.Message.Chat.Id, "Hey " + e.Message.Chat.FirstName + " " + e.Message.Chat.LastName + " looks like this command is not available currently. You can type 'Help' for commands!");
            }
        }

        #endregion

        #region Third Party APIs

        public async static void TelegramBotAlertSendInitiator(Telegram.Bot.Args.MessageEventArgs e = null)
        {
            StringBuilder sb;
            try
            {
                string file = Convert.ToString(ConfigurationManager.AppSettings["SendAlertPath"]);
                string _SendAlertTo = Convert.ToString(ConfigurationManager.AppSettings["SendAlertTo"]);
                sb = new StringBuilder();

                if (!string.IsNullOrWhiteSpace(file))
                {
                    using (FileStream fs = File.Open(file, FileMode.Open))
                    {
                        using (BufferedStream bs = new BufferedStream(fs))
                        {
                            using (StreamReader sr = new StreamReader(bs))
                            {
                                string str;
                                while ((str = sr.ReadLine()) != null)
                                {
                                    sb.AppendLine(str);
                                }
                            }
                        }
                    }
                    var finalString = sb.ToString();
                    if (!string.IsNullOrWhiteSpace(finalString))
                    {
                        foreach (var to in _SendAlertTo.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries))
                        {
                            try
                            {
                                await telegramBotClient.SendTextMessageAsync(to, finalString, Telegram.Bot.Types.Enums.ParseMode.Default, true);
                            }
                            catch (Exception ex)
                            {
                                #region Exception
                                List<string> list = new List<string>();
                                list.Add("Class name: ServiceMethods, Method name: TelegramBotAlertSendInitiator - _SendAlertTo");
                                list.Add("Exception occurred for Name: " + e.Message.Chat.FirstName + " " + e.Message.Chat.LastName + ", Username: " + e.Message.Chat.Username + ", Message: " + e.Message.Text);
                                list.Add("Message:  " + ex?.Message?.ToString());
                                list.Add("StackTrace:  " + ex?.StackTrace?.ToString());
                                list.Add("InnerException.Message:  " + Convert.ToString(ex?.InnerException?.Message));
                                list.Add("InnerException.StackTrace:  " + Convert.ToString(ex?.InnerException?.StackTrace));
                                await telegramBotClient.SendTextMessageAsync(1715334607, exceptionStringBuilder(list.ToArray()));
                                #endregion
                                continue;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                #region Exception
                List<string> list = new List<string>();
                list.Add("Class name: ServiceMethods, Method name: TelegramBotAlertSendInitiator");
                list.Add("Exception occurred for Name: " + e.Message.Chat.FirstName + " " + e.Message.Chat.LastName + ", Username: " + e.Message.Chat.Username + ", Message: " + e.Message.Text);
                list.Add("Message:  " + ex?.Message?.ToString());
                list.Add("StackTrace:  " + ex?.StackTrace?.ToString());
                list.Add("InnerException.Message:  " + Convert.ToString(ex?.InnerException?.Message));
                list.Add("InnerException.StackTrace:  " + Convert.ToString(ex?.InnerException?.StackTrace));
                await telegramBotClient.SendTextMessageAsync(1715334607, exceptionStringBuilder(list.ToArray()));
                #endregion
            }
        }

        public async static void TelegramBotAPIInitiator(long ID, string _DistrictIDs, Telegram.Bot.Args.MessageEventArgs e = null)
        {
            bool isTelegramSent = false;
            if (!string.IsNullOrWhiteSpace(_DistrictIDs))
            {
                await telegramBotClient.SendTextMessageAsync(e.Message.Chat.Id, "Please wait while we're processing your request...");
                int _APIHitCounter = 1;
                string urlParameter = string.Empty;
                Root result = new Root();
                List<Root> root = new List<Root>();
                var client = new HttpClient();
                client.BaseAddress = new Uri("http://cdn-api.co-vin.in/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
                URLs = new Dictionary<int, string>();
                foreach (var id in _DistrictIDs.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries))
                {
                    URLs.Add(Convert.ToInt32(id), "api/v2/appointment/sessions/public/calendarByDistrict?district_id=" + id + "&date=#DateHere");
                }
                try
                {
                    foreach (var URL in URLs)
                    {
                        string date = DateTime.Now.ToString("dd-MM-yyyy");
                        string _DateFor108 = DateTime.Now.AddDays(Convert.ToDouble(ConfigurationManager.AppSettings["DateFor108"])).ToString("dd-MM-yyyy");
                        for (int a = 0; a < 5; a--)
                        {
                            if (URL.Key == 108)
                                urlParameter = URL.Value.Replace("#DateHere", _DateFor108);
                            else
                                urlParameter = URL.Value.Replace("#DateHere", date);
                            var task = client.GetAsync(urlParameter);
                            task.Wait();
                            var response = task.Result;
                            if (response.IsSuccessStatusCode)
                            {
                                LogWrite("Number of API Hit for URL: [" + urlParameter + "] is " + Convert.ToString(_APIHitCounter++));
                                var readTask = response.Content.ReadAsStringAsync();
                                readTask.Wait();
                                result = JsonConvert.DeserializeObject<Root>(readTask.Result);

                                if (result.centers.Count > 0)
                                {
                                    root.Add(result);
                                    DateTime date1 = Convert.ToDateTime(date).AddDays(1);
                                    date = date1.ToString("dd-MM-yyyy");
                                    if (URL.Key == 108)
                                    {
                                        DateTime _DateFor108_2 = Convert.ToDateTime(_DateFor108).AddDays(1);
                                        _DateFor108 = _DateFor108_2.ToString("dd-MM-yyyy");
                                    }
                                }
                                else
                                {
                                    break;
                                }
                            }
                            else
                            {
                                LogWrite("API Error StatusCode: " + response.StatusCode.ToString());
                                LogWrite("API Error RequestMessage: " + response.RequestMessage.ToString());
                                break;
                            }
                        }
                    }
                    #region Final List Variables
                    List<List<string>> finalList = new List<List<string>>();
                    List<List<string>> ritvikFinalList = new List<List<string>>();
                    List<List<string>> agraFinalList = new List<List<string>>();
                    List<List<string>> karnalFinalList = new List<List<string>>();
                    List<List<string>> faridabadFinalList = new List<List<string>>();
                    List<List<string>> sonipatFinalList = new List<List<string>>();
                    List<List<string>> hyderabadFinalList = new List<List<string>>();
                    List<List<string>> puneFinalList = new List<List<string>>();
                    List<List<string>> mumbaiFinalList = new List<List<string>>();

                    List<List<string>> delhi140FinalList = new List<List<string>>();
                    List<List<string>> delhi141FinalList = new List<List<string>>();
                    List<List<string>> delhi142FinalList = new List<List<string>>();
                    List<List<string>> delhi143FinalList = new List<List<string>>();
                    List<List<string>> delhi144FinalList = new List<List<string>>();
                    List<List<string>> delhi145FinalList = new List<List<string>>();
                    List<List<string>> delhi146FinalList = new List<List<string>>();
                    List<List<string>> delhi147FinalList = new List<List<string>>();
                    List<List<string>> delhi148FinalList = new List<List<string>>();
                    List<List<string>> delhi149FinalList = new List<List<string>>();
                    List<List<string>> delhi150FinalList = new List<List<string>>();

                    List<List<string>> jaipuriFinalList = new List<List<string>>();
                    List<List<string>> jaipuriiFinalList = new List<List<string>>();

                    #endregion

                    #region Data Filtering 
                    foreach (var r in root)
                    {
                        foreach (var center in r.centers)
                        {
                            #region Chandigarh & Mohali
                            if (center.block_name.ToLower() == "mohali" || center.block_name.ToLower() == "chandigarh")
                            {
                                foreach (var sess in center.sessions)
                                {
                                    if (sess.min_age_limit == 18 && sess.available_capacity_dose1 > 5)
                                    {
                                        List<string> list = new List<string>();
                                        list.Add("Please find below details for " + center.district_name + " for Date: " + sess.date);
                                        list.Add("Vaccine: " + sess.vaccine);
                                        list.Add("Center Name: " + center.name);
                                        list.Add("Center Address: " + center.address + ", Pincode: " + center.pincode);
                                        list.Add("Slots: " + String.Join(" | ", sess.slots.ToArray()));
                                        list.Add("Available Capacity: " + sess.available_capacity.ToString());
                                        list.Add("Available Capacity of Dose 1 for " + sess.min_age_limit + "+: " + Convert.ToString(sess.available_capacity_dose1));
                                        finalList.Add(list);
                                        var res = emailStringBuilder(null, finalList);
                                        if (res.Length > 4096)
                                        {
                                            if (res.Length > 4096)
                                            {
                                                foreach (var i in StringSplitter(res, 4096))
                                                {
                                                    await telegramBotClient.SendTextMessageAsync(ID, i);
                                                }
                                            }
                                        }
                                        else
                                        {
                                            await telegramBotClient.SendTextMessageAsync(ID, res);
                                        }
                                        //Thread.Sleep(2000);
                                        LogWrite("******************* Alert sent to: Name: " + e.Message.Chat.FirstName + " " + e.Message.Chat.LastName + ", Username: " + e.Message.Chat.Username);
                                        isTelegramSent = true;
                                    }
                                }
                            }
                            #endregion

                            #region Jaipur
                            if (center.district_name.ToLower() == "jaipur i")
                            {
                                foreach (var sess in center.sessions)
                                {
                                    if (sess.min_age_limit == 18 && sess.available_capacity_dose1 > 5)
                                    {
                                        List<string> list = new List<string>();
                                        list.Add("Please find below details for " + center.district_name + " for Date: " + sess.date);
                                        list.Add("Vaccine: " + sess.vaccine);
                                        list.Add("Center Name: " + center.name);
                                        list.Add("Center Address: " + center.address + ", Pincode: " + center.pincode);
                                        list.Add("Slots: " + String.Join(" | ", sess.slots.ToArray()));
                                        list.Add("Available Capacity: " + sess.available_capacity.ToString());
                                        list.Add("Available Capacity of Dose 1 for " + sess.min_age_limit + "+: " + Convert.ToString(sess.available_capacity_dose1));
                                        agraFinalList.Add(list);
                                        await telegramBotClient.SendTextMessageAsync(ID, emailStringBuilder(null, jaipuriFinalList));
                                        LogWrite("******************* Alert sent to: Name: " + e.Message.Chat.FirstName + " " + e.Message.Chat.LastName + ", Username: " + e.Message.Chat.Username);
                                        isTelegramSent = true;
                                    }
                                }
                            }

                            if (center.district_name.ToLower() == "jaipur ii")
                            {
                                foreach (var sess in center.sessions)
                                {
                                    if (sess.min_age_limit == 18 && sess.available_capacity_dose1 > 5)
                                    {
                                        List<string> list = new List<string>();
                                        list.Add("Please find below details for " + center.district_name + " for Date: " + sess.date);
                                        list.Add("Vaccine: " + sess.vaccine);
                                        list.Add("Center Name: " + center.name);
                                        list.Add("Center Address: " + center.address + ", Pincode: " + center.pincode);
                                        list.Add("Slots: " + String.Join(" | ", sess.slots.ToArray()));
                                        list.Add("Available Capacity: " + sess.available_capacity.ToString());
                                        list.Add("Available Capacity of Dose 1 for " + sess.min_age_limit + "+: " + Convert.ToString(sess.available_capacity_dose1));
                                        agraFinalList.Add(list);
                                        await telegramBotClient.SendTextMessageAsync(ID, emailStringBuilder(null, jaipuriiFinalList));
                                        LogWrite("******************* Alert sent to: Name: " + e.Message.Chat.FirstName + " " + e.Message.Chat.LastName + ", Username: " + e.Message.Chat.Username);
                                        isTelegramSent = true;
                                    }
                                }
                            }
                            #endregion

                            #region Agra
                            if (center.district_name.ToLower() == "agra")
                            {
                                foreach (var sess in center.sessions)
                                {
                                    if (sess.min_age_limit == 18 && sess.available_capacity_dose1 > 5)
                                    {
                                        List<string> list = new List<string>();
                                        list.Add("Please find below details for " + center.district_name + " for Date: " + sess.date);
                                        list.Add("Vaccine: " + sess.vaccine);
                                        list.Add("Center Name: " + center.name);
                                        list.Add("Center Address: " + center.address + ", Pincode: " + center.pincode);
                                        list.Add("Slots: " + String.Join(" | ", sess.slots.ToArray()));
                                        list.Add("Available Capacity: " + sess.available_capacity.ToString());
                                        list.Add("Available Capacity of Dose 1 for " + sess.min_age_limit + "+: " + Convert.ToString(sess.available_capacity_dose1));
                                        agraFinalList.Add(list);
                                        await telegramBotClient.SendTextMessageAsync(ID, emailStringBuilder(null, agraFinalList));
                                        LogWrite("******************* Alert sent to: Name: " + e.Message.Chat.FirstName + " " + e.Message.Chat.LastName + ", Username: " + e.Message.Chat.Username);
                                        isTelegramSent = true;
                                    }
                                }
                            }
                            #endregion

                            #region Haryana: Karnal, Faridabad, Sonipat
                            if (center.district_name.ToLower() == "karnal")
                            {
                                foreach (var sess in center.sessions)
                                {
                                    if (sess.min_age_limit == 18 && sess.available_capacity_dose1 > 5)
                                    {
                                        List<string> list = new List<string>();
                                        list.Add("Please find below details for " + center.district_name + " for Date: " + sess.date);
                                        list.Add("Vaccine: " + sess.vaccine);
                                        list.Add("Center Name: " + center.name);
                                        list.Add("Center Address: " + center.address + ", Pincode: " + center.pincode);
                                        list.Add("Slots: " + String.Join(" | ", sess.slots.ToArray()));
                                        list.Add("Available Capacity: " + sess.available_capacity.ToString());
                                        list.Add("Available Capacity of Dose 1 for " + sess.min_age_limit + "+: " + Convert.ToString(sess.available_capacity_dose1));
                                        karnalFinalList.Add(list);
                                        await telegramBotClient.SendTextMessageAsync(ID, emailStringBuilder(null, karnalFinalList));
                                        LogWrite("******************* Alert sent to: Name: " + e.Message.Chat.FirstName + " " + e.Message.Chat.LastName + ", Username: " + e.Message.Chat.Username);
                                        isTelegramSent = true;
                                    }
                                }
                            }
                            if (center.district_name.ToLower() == "faridabad")
                            {
                                foreach (var sess in center.sessions)
                                {
                                    if (sess.min_age_limit == 18 && sess.available_capacity_dose1 > 5)
                                    {
                                        List<string> list = new List<string>();
                                        list.Add("Please find below details for " + center.district_name + " for Date: " + sess.date);
                                        list.Add("Vaccine: " + sess.vaccine);
                                        list.Add("Center Name: " + center.name);
                                        list.Add("Center Address: " + center.address + ", Pincode: " + center.pincode);
                                        list.Add("Slots: " + String.Join(" | ", sess.slots.ToArray()));
                                        list.Add("Available Capacity: " + sess.available_capacity.ToString());
                                        list.Add("Available Capacity of Dose 1 for " + sess.min_age_limit + "+: " + Convert.ToString(sess.available_capacity_dose1));
                                        faridabadFinalList.Add(list);
                                        await telegramBotClient.SendTextMessageAsync(ID, emailStringBuilder(null, faridabadFinalList));
                                        LogWrite("******************* Alert sent to: Name: " + e.Message.Chat.FirstName + " " + e.Message.Chat.LastName + ", Username: " + e.Message.Chat.Username);
                                        isTelegramSent = true;
                                    }
                                }
                            }
                            if (center.district_name.ToLower() == "sonipat")
                            {
                                foreach (var sess in center.sessions)
                                {
                                    if (sess.min_age_limit == 18 && sess.available_capacity_dose1 > 5)
                                    {
                                        List<string> list = new List<string>();
                                        list.Add("Please find below details for " + center.district_name + " for Date: " + sess.date);
                                        list.Add("Vaccine: " + sess.vaccine);
                                        list.Add("Center Name: " + center.name);
                                        list.Add("Center Address: " + center.address + ", Pincode: " + center.pincode);
                                        list.Add("Slots: " + String.Join(" | ", sess.slots.ToArray()));
                                        list.Add("Available Capacity: " + sess.available_capacity.ToString());
                                        list.Add("Available Capacity of Dose 1 for " + sess.min_age_limit + "+: " + Convert.ToString(sess.available_capacity_dose1));
                                        sonipatFinalList.Add(list);
                                        await telegramBotClient.SendTextMessageAsync(ID, emailStringBuilder(null, sonipatFinalList));
                                        LogWrite("******************* Alert sent to: Name: " + e.Message.Chat.FirstName + " " + e.Message.Chat.LastName + ", Username: " + e.Message.Chat.Username);
                                        isTelegramSent = true;
                                    }
                                }
                            }
                            #endregion

                            #region 140: New Delhi | 141: Central Delhi | 142: West Delhi | 143: North West Delhi | 144: South East Delhi | 145: East Delhi | 146: North Delhi | 147: North East Delhi | 148: Shahdara | 149: South Delhi | 150: South West Delhi
                            if (center.district_name.ToLower() == "new delhi")
                            {
                                foreach (var sess in center.sessions)
                                {
                                    if (sess.min_age_limit == 18 && sess.available_capacity_dose1 > 5)
                                    {
                                        List<string> list = new List<string>();
                                        list.Add("Please find below details for " + center.district_name + " for Date: " + sess.date);
                                        list.Add("Vaccine: " + sess.vaccine);
                                        list.Add("Center Name: " + center.name);
                                        list.Add("Center Address: " + center.address + ", Pincode: " + center.pincode);
                                        list.Add("Slots: " + String.Join(" | ", sess.slots.ToArray()));
                                        list.Add("Available Capacity: " + sess.available_capacity.ToString());
                                        list.Add("Available Capacity of Dose 1 for " + sess.min_age_limit + "+: " + Convert.ToString(sess.available_capacity_dose1));
                                        delhi140FinalList.Add(list);
                                        await telegramBotClient.SendTextMessageAsync(ID, emailStringBuilder(null, delhi140FinalList));
                                        LogWrite("******************* Alert sent to: Name: " + e.Message.Chat.FirstName + " " + e.Message.Chat.LastName + ", Username: " + e.Message.Chat.Username);
                                        isTelegramSent = true;
                                    }
                                }
                            }

                            if (center.district_name.ToLower() == "central delhi")
                            {
                                foreach (var sess in center.sessions)
                                {
                                    if (sess.min_age_limit == 18 && sess.available_capacity_dose1 > 5)
                                    {
                                        List<string> list = new List<string>();
                                        list.Add("Please find below details for " + center.district_name + " for Date: " + sess.date);
                                        list.Add("Vaccine: " + sess.vaccine);
                                        list.Add("Center Name: " + center.name);
                                        list.Add("Center Address: " + center.address + ", Pincode: " + center.pincode);
                                        list.Add("Slots: " + String.Join(" | ", sess.slots.ToArray()));
                                        list.Add("Available Capacity: " + sess.available_capacity.ToString());
                                        list.Add("Available Capacity of Dose 1 for " + sess.min_age_limit + "+: " + Convert.ToString(sess.available_capacity_dose1));
                                        delhi141FinalList.Add(list);
                                        await telegramBotClient.SendTextMessageAsync(ID, emailStringBuilder(null, delhi141FinalList));
                                        LogWrite("******************* Alert sent to: Name: " + e.Message.Chat.FirstName + " " + e.Message.Chat.LastName + ", Username: " + e.Message.Chat.Username);
                                        isTelegramSent = true;
                                    }
                                }
                            }

                            if (center.district_name.ToLower() == "west delhi")
                            {
                                foreach (var sess in center.sessions)
                                {
                                    if (sess.min_age_limit == 18 && sess.available_capacity_dose1 > 5)
                                    {
                                        List<string> list = new List<string>();
                                        list.Add("Please find below details for " + center.district_name + " for Date: " + sess.date);
                                        list.Add("Vaccine: " + sess.vaccine);
                                        list.Add("Center Name: " + center.name);
                                        list.Add("Center Address: " + center.address + ", Pincode: " + center.pincode);
                                        list.Add("Slots: " + String.Join(" | ", sess.slots.ToArray()));
                                        list.Add("Available Capacity: " + sess.available_capacity.ToString());
                                        list.Add("Available Capacity of Dose 1 for " + sess.min_age_limit + "+: " + Convert.ToString(sess.available_capacity_dose1));
                                        delhi142FinalList.Add(list);
                                        await telegramBotClient.SendTextMessageAsync(ID, emailStringBuilder(null, delhi142FinalList));
                                        LogWrite("******************* Alert sent to: Name: " + e.Message.Chat.FirstName + " " + e.Message.Chat.LastName + ", Username: " + e.Message.Chat.Username);
                                        isTelegramSent = true;
                                    }
                                }
                            }

                            if (center.district_name.ToLower() == "north west delhi")
                            {
                                foreach (var sess in center.sessions)
                                {
                                    if (sess.min_age_limit == 18 && sess.available_capacity_dose1 > 5)
                                    {
                                        List<string> list = new List<string>();
                                        list.Add("Please find below details for " + center.district_name + " for Date: " + sess.date);
                                        list.Add("Vaccine: " + sess.vaccine);
                                        list.Add("Center Name: " + center.name);
                                        list.Add("Center Address: " + center.address + ", Pincode: " + center.pincode);
                                        list.Add("Slots: " + String.Join(" | ", sess.slots.ToArray()));
                                        list.Add("Available Capacity: " + sess.available_capacity.ToString());
                                        list.Add("Available Capacity of Dose 1 for " + sess.min_age_limit + "+: " + Convert.ToString(sess.available_capacity_dose1));
                                        delhi143FinalList.Add(list);
                                        await telegramBotClient.SendTextMessageAsync(ID, emailStringBuilder(null, delhi143FinalList));
                                        LogWrite("******************* Alert sent to: Name: " + e.Message.Chat.FirstName + " " + e.Message.Chat.LastName + ", Username: " + e.Message.Chat.Username);
                                        isTelegramSent = true;
                                    }
                                }
                            }

                            if (center.district_name.ToLower() == "south east delhi")
                            {
                                foreach (var sess in center.sessions)
                                {
                                    if (sess.min_age_limit == 18 && sess.available_capacity_dose1 > 5)
                                    {
                                        List<string> list = new List<string>();
                                        list.Add("Please find below details for " + center.district_name + " for Date: " + sess.date);
                                        list.Add("Vaccine: " + sess.vaccine);
                                        list.Add("Center Name: " + center.name);
                                        list.Add("Center Address: " + center.address + ", Pincode: " + center.pincode);
                                        list.Add("Slots: " + String.Join(" | ", sess.slots.ToArray()));
                                        list.Add("Available Capacity: " + sess.available_capacity.ToString());
                                        list.Add("Available Capacity of Dose 1 for " + sess.min_age_limit + "+: " + Convert.ToString(sess.available_capacity_dose1));
                                        delhi144FinalList.Add(list);
                                        await telegramBotClient.SendTextMessageAsync(ID, emailStringBuilder(null, delhi144FinalList));
                                        LogWrite("******************* Alert sent to: Name: " + e.Message.Chat.FirstName + " " + e.Message.Chat.LastName + ", Username: " + e.Message.Chat.Username);
                                        isTelegramSent = true;
                                    }
                                }
                            }

                            if (center.district_name.ToLower() == "east delhi")
                            {
                                foreach (var sess in center.sessions)
                                {
                                    if (sess.min_age_limit == 18 && sess.available_capacity_dose1 > 5)
                                    {
                                        List<string> list = new List<string>();
                                        list.Add("Please find below details for " + center.district_name + " for Date: " + sess.date);
                                        list.Add("Vaccine: " + sess.vaccine);
                                        list.Add("Center Name: " + center.name);
                                        list.Add("Center Address: " + center.address + ", Pincode: " + center.pincode);
                                        list.Add("Slots: " + String.Join(" | ", sess.slots.ToArray()));
                                        list.Add("Available Capacity: " + sess.available_capacity.ToString());
                                        list.Add("Available Capacity of Dose 1 for " + sess.min_age_limit + "+: " + Convert.ToString(sess.available_capacity_dose1));
                                        delhi145FinalList.Add(list);
                                        await telegramBotClient.SendTextMessageAsync(ID, emailStringBuilder(null, delhi145FinalList));
                                        LogWrite("******************* Alert sent to: Name: " + e.Message.Chat.FirstName + " " + e.Message.Chat.LastName + ", Username: " + e.Message.Chat.Username);
                                        isTelegramSent = true;
                                    }
                                }
                            }

                            if (center.district_name.ToLower() == "north delhi")
                            {
                                foreach (var sess in center.sessions)
                                {
                                    if (sess.min_age_limit == 18 && sess.available_capacity_dose1 > 5)
                                    {
                                        List<string> list = new List<string>();
                                        list.Add("Please find below details for " + center.district_name + " for Date: " + sess.date);
                                        list.Add("Vaccine: " + sess.vaccine);
                                        list.Add("Center Name: " + center.name);
                                        list.Add("Center Address: " + center.address + ", Pincode: " + center.pincode);
                                        list.Add("Slots: " + String.Join(" | ", sess.slots.ToArray()));
                                        list.Add("Available Capacity: " + sess.available_capacity.ToString());
                                        list.Add("Available Capacity of Dose 1 for " + sess.min_age_limit + "+: " + Convert.ToString(sess.available_capacity_dose1));
                                        delhi146FinalList.Add(list);
                                        await telegramBotClient.SendTextMessageAsync(ID, emailStringBuilder(null, delhi146FinalList));
                                        LogWrite("******************* Alert sent to: Name: " + e.Message.Chat.FirstName + " " + e.Message.Chat.LastName + ", Username: " + e.Message.Chat.Username);
                                        isTelegramSent = true;
                                    }
                                }
                            }

                            if (center.district_name.ToLower() == "north east delhi")
                            {
                                foreach (var sess in center.sessions)
                                {
                                    if (sess.min_age_limit == 18 && sess.available_capacity_dose1 > 5)
                                    {
                                        List<string> list = new List<string>();
                                        list.Add("Please find below details for " + center.district_name + " for Date: " + sess.date);
                                        list.Add("Vaccine: " + sess.vaccine);
                                        list.Add("Center Name: " + center.name);
                                        list.Add("Center Address: " + center.address + ", Pincode: " + center.pincode);
                                        list.Add("Slots: " + String.Join(" | ", sess.slots.ToArray()));
                                        list.Add("Available Capacity: " + sess.available_capacity.ToString());
                                        list.Add("Available Capacity of Dose 1 for " + sess.min_age_limit + "+: " + Convert.ToString(sess.available_capacity_dose1));
                                        delhi147FinalList.Add(list);
                                        await telegramBotClient.SendTextMessageAsync(ID, emailStringBuilder(null, delhi147FinalList));
                                        LogWrite("******************* Alert sent to: Name: " + e.Message.Chat.FirstName + " " + e.Message.Chat.LastName + ", Username: " + e.Message.Chat.Username);
                                        isTelegramSent = true;
                                    }
                                }
                            }

                            if (center.district_name.ToLower() == "shahdara")
                            {
                                foreach (var sess in center.sessions)
                                {
                                    if (sess.min_age_limit == 18 && sess.available_capacity_dose1 > 5)
                                    {
                                        List<string> list = new List<string>();
                                        list.Add("Please find below details for " + center.district_name + " for Date: " + sess.date);
                                        list.Add("Vaccine: " + sess.vaccine);
                                        list.Add("Center Name: " + center.name);
                                        list.Add("Center Address: " + center.address + ", Pincode: " + center.pincode);
                                        list.Add("Slots: " + String.Join(" | ", sess.slots.ToArray()));
                                        list.Add("Available Capacity: " + sess.available_capacity.ToString());
                                        list.Add("Available Capacity of Dose 1 for " + sess.min_age_limit + "+: " + Convert.ToString(sess.available_capacity_dose1));
                                        delhi148FinalList.Add(list);
                                        await telegramBotClient.SendTextMessageAsync(ID, emailStringBuilder(null, delhi148FinalList));
                                        LogWrite("******************* Alert sent to: Name: " + e.Message.Chat.FirstName + " " + e.Message.Chat.LastName + ", Username: " + e.Message.Chat.Username);
                                        isTelegramSent = true;
                                    }
                                }
                            }

                            if (center.district_name.ToLower() == "south delhi")
                            {
                                foreach (var sess in center.sessions)
                                {
                                    if (sess.min_age_limit == 18 && sess.available_capacity_dose1 > 5)
                                    {
                                        List<string> list = new List<string>();
                                        list.Add("Please find below details for " + center.district_name + " for Date: " + sess.date);
                                        list.Add("Vaccine: " + sess.vaccine);
                                        list.Add("Center Name: " + center.name);
                                        list.Add("Center Address: " + center.address + ", Pincode: " + center.pincode);
                                        list.Add("Slots: " + String.Join(" | ", sess.slots.ToArray()));
                                        list.Add("Available Capacity: " + sess.available_capacity.ToString());
                                        list.Add("Available Capacity of Dose 1 for " + sess.min_age_limit + "+: " + Convert.ToString(sess.available_capacity_dose1));
                                        delhi149FinalList.Add(list);
                                        await telegramBotClient.SendTextMessageAsync(ID, emailStringBuilder(null, delhi149FinalList));
                                        LogWrite("******************* Alert sent to: Name: " + e.Message.Chat.FirstName + " " + e.Message.Chat.LastName + ", Username: " + e.Message.Chat.Username);
                                        isTelegramSent = true;
                                    }
                                }
                            }

                            if (center.district_name.ToLower() == "south west delhi")
                            {
                                foreach (var sess in center.sessions)
                                {
                                    if (sess.min_age_limit == 18 && sess.available_capacity_dose1 > 5)
                                    {
                                        List<string> list = new List<string>();
                                        list.Add("Please find below details for " + center.district_name + " for Date: " + sess.date);
                                        list.Add("Vaccine: " + sess.vaccine);
                                        list.Add("Center Name: " + center.name);
                                        list.Add("Center Address: " + center.address + ", Pincode: " + center.pincode);
                                        list.Add("Slots: " + String.Join(" | ", sess.slots.ToArray()));
                                        list.Add("Available Capacity: " + sess.available_capacity.ToString());
                                        list.Add("Available Capacity of Dose 1 for " + sess.min_age_limit + "+: " + Convert.ToString(sess.available_capacity_dose1));
                                        delhi150FinalList.Add(list);
                                        await telegramBotClient.SendTextMessageAsync(ID, emailStringBuilder(null, delhi150FinalList));
                                        LogWrite("******************* Alert sent to: Name: " + e.Message.Chat.FirstName + " " + e.Message.Chat.LastName + ", Username: " + e.Message.Chat.Username);
                                        isTelegramSent = true;
                                    }
                                }
                            }
                            #endregion

                            #region Hyderabad
                            if (center.district_name.ToLower() == "hyderabad")
                            {
                                foreach (var sess in center.sessions)
                                {
                                    if (sess.min_age_limit == 18 && sess.available_capacity_dose1 > 5)
                                    {
                                        List<string> list = new List<string>();
                                        list.Add("Please find below details for " + center.district_name + " for Date: " + sess.date);
                                        list.Add("Vaccine: " + sess.vaccine);
                                        list.Add("Center Name: " + center.name);
                                        list.Add("Center Address: " + center.address + ", Pincode: " + center.pincode);
                                        list.Add("Slots: " + String.Join(" | ", sess.slots.ToArray()));
                                        list.Add("Available Capacity: " + sess.available_capacity.ToString());
                                        list.Add("Available Capacity of Dose 1 for " + sess.min_age_limit + "+: " + Convert.ToString(sess.available_capacity_dose1));
                                        hyderabadFinalList.Add(list);
                                        await telegramBotClient.SendTextMessageAsync(ID, emailStringBuilder(null, hyderabadFinalList));
                                        LogWrite("******************* Alert sent to: Name: " + e.Message.Chat.FirstName + " " + e.Message.Chat.LastName + ", Username: " + e.Message.Chat.Username);
                                        isTelegramSent = true;
                                    }
                                }
                            }
                            #endregion

                            #region Maharashtra
                            if (center.district_name.ToLower() == "pune")
                            {
                                foreach (var sess in center.sessions)
                                {
                                    if (sess.min_age_limit == 18 && sess.available_capacity_dose1 > 5)
                                    {
                                        List<string> list = new List<string>();
                                        list.Add("Please find below details for " + center.district_name + " for Date: " + sess.date);
                                        list.Add("Vaccine: " + sess.vaccine);
                                        list.Add("Center Name: " + center.name);
                                        list.Add("Center Address: " + center.address + ", Pincode: " + center.pincode);
                                        list.Add("Slots: " + String.Join(" | ", sess.slots.ToArray()));
                                        list.Add("Available Capacity: " + sess.available_capacity.ToString());
                                        list.Add("Available Capacity of Dose 1 for " + sess.min_age_limit + "+: " + Convert.ToString(sess.available_capacity_dose1));
                                        puneFinalList.Add(list);
                                        await telegramBotClient.SendTextMessageAsync(ID, emailStringBuilder(null, puneFinalList));
                                        LogWrite("******************* Alert sent to: Name: " + e.Message.Chat.FirstName + " " + e.Message.Chat.LastName + ", Username: " + e.Message.Chat.Username);
                                        isTelegramSent = true;
                                    }
                                }
                            }

                            if (center.district_name.ToLower() == "mumbai")
                            {
                                foreach (var sess in center.sessions)
                                {
                                    if (sess.min_age_limit == 18 && sess.available_capacity_dose1 > 5)
                                    {
                                        List<string> list = new List<string>();
                                        list.Add("Please find below details for " + center.district_name + " for Date: " + sess.date);
                                        list.Add("Vaccine: " + sess.vaccine);
                                        list.Add("Center Name: " + center.name);
                                        list.Add("Center Address: " + center.address + ", Pincode: " + center.pincode);
                                        list.Add("Slots: " + String.Join(" | ", sess.slots.ToArray()));
                                        list.Add("Available Capacity: " + sess.available_capacity.ToString());
                                        list.Add("Available Capacity of Dose 1 for " + sess.min_age_limit + "+: " + Convert.ToString(sess.available_capacity_dose1));
                                        mumbaiFinalList.Add(list);
                                        await telegramBotClient.SendTextMessageAsync(ID, emailStringBuilder(null, mumbaiFinalList));
                                        LogWrite("******************* Alert sent to: Name: " + e.Message.Chat.FirstName + " " + e.Message.Chat.LastName + ", Username: " + e.Message.Chat.Username);
                                        isTelegramSent = true;
                                    }
                                }
                            }
                            #endregion
                        }
                    }
                    if (!isTelegramSent)
                    {
                        await telegramBotClient.SendTextMessageAsync(ID, "No data available. Please try again later!");
                        LogWrite("******************* NOT sent to: Name: " + e.Message.Chat.FirstName + " " + e.Message.Chat.LastName + ", Username: " + e.Message.Chat.Username);
                    }
                    #endregion
                }
                catch (Exception ex)
                {
                    #region Exception
                    List<string> list = new List<string>();
                    list.Add("Class name: ServiceMethods, Method name: TelegramBotAPIInitiator");
                    list.Add("Exception occurred for Name: " + e.Message.Chat.FirstName + " " + e.Message.Chat.LastName + ", Username: " + e.Message.Chat.Username + ", Message: " + e.Message.Text);
                    list.Add("Message:  " + ex?.Message?.ToString());
                    list.Add("StackTrace:  " + ex?.StackTrace?.ToString());
                    list.Add("InnerException.Message:  " + Convert.ToString(ex?.InnerException?.Message));
                    list.Add("InnerException.StackTrace:  " + Convert.ToString(ex?.InnerException?.StackTrace));
                    await telegramBotClient.SendTextMessageAsync(1715334607, exceptionStringBuilder(list.ToArray()));
                    #endregion
                }
            }
        }

        public async static void TelegramBotGameAPIInitiator(long ID, string _DistrictIDs, Telegram.Bot.Args.MessageEventArgs e = null)
        {
            try
            {
                await telegramBotClient.SendTextMessageAsync(e.Message.Chat.Id, "Please wait while we're processing your request...");
                var client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
                URLs = new Dictionary<int, string>();
                string urlParameter = "https://store-site-backend-static.ak.epicgames.com/freeGamesPromotions?locale=en-US&country=IN&allowCountries=IN";
                var task = client.GetAsync(urlParameter);
                task.Wait();
                var response = task.Result;
                List<List<string>> finalList = new List<List<string>>();
                List<string> list = new List<string>();
                string addFileEntry = string.Empty;
                if (response.IsSuccessStatusCode)
                {
                    var readTask = response.Content.ReadAsStringAsync();
                    readTask.Wait();
                    var result = JsonConvert.DeserializeObject<EpicApiModel>(readTask.Result).Data.Catalog.SearchStore;
                    foreach (var i in result.Elements)
                    {
                        list = new List<string>();
                        if (i.Promotions != null)
                        {
                            foreach (var i_2 in i.Promotions?.PromotionalOffers)
                            {
                                list.Add("Please find the below details for free game:");
                                list.Add("Game Name: " + i.Title);
                                addFileEntry = i.Title;
                                list.Add("Game Description: " + i.Description);
                                foreach (var i_3 in i_2.PromotionalOffers)
                                {
                                    list.Add("Start Date: " + i_3.StartDate?.LocalDateTime.ToString(Constant.DateTimeFormat));
                                    list.Add("End Date: " + i_3.EndDate?.LocalDateTime.ToString(Constant.DateTimeFormat));
                                }
                                list.Add("URL: " + "https://www.epicgames.com/store/en-US/");
                            }
                        }
                        if (list.Count > 0 && (i.Promotions.PromotionalOffers.Length > 0 || i.Promotions.UpcomingPromotionalOffers.Length > 0))
                        {
                            finalList.Add(list);
                        }
                    }
                    foreach (var i in result.Elements)
                    {
                        list = new List<string>();
                        if (i.Promotions != null)
                        {
                            foreach (var i_2 in i.Promotions.UpcomingPromotionalOffers)
                            {
                                list.Add("***** Upcoming Offers *****");
                                list.Add("Game Name: " + i.Title);
                                foreach (var i_3 in i_2.PromotionalOffers)
                                {
                                    list.Add("Start Date: " + i_3.StartDate?.LocalDateTime.ToString(Constant.DateTimeFormat));
                                    list.Add("End Date: " + i_3.EndDate?.LocalDateTime.ToString(Constant.DateTimeFormat));
                                }
                            }
                        }
                        if (list.Count > 0 && (i.Promotions.PromotionalOffers.Length > 0 || i.Promotions.UpcomingPromotionalOffers.Length > 0))
                        {
                            finalList.Add(list);
                        }
                    }
                }
                if (finalList.Count > 0)
                {
                    using (var stream = File.Open(Convert.ToString(ConfigurationManager.AppSettings["EpicPhotoPath"]), FileMode.Open))
                    {
                        var rep = await telegramBotClient.SendPhotoAsync(ID, stream, gameStringBuilder(null, finalList));
                    }
                }
                else
                {
                    await telegramBotClient.SendTextMessageAsync(ID, "No game data available. Please try again later!");
                }
            }
            catch (Exception ex)
            {
                #region Exception
                List<string> list = new List<string>();
                list.Add("Class name: ServiceMethods, Method name: TelegramBotGameAPIInitiator");
                list.Add("Exception occurred for Name: " + e.Message.Chat.FirstName + " " + e.Message.Chat.LastName + ", Username: " + e.Message.Chat.Username + ", Message: " + e.Message.Text);
                list.Add("Message:  " + ex?.Message?.ToString());
                list.Add("StackTrace:  " + ex?.StackTrace?.ToString());
                list.Add("InnerException.Message:  " + Convert.ToString(ex?.InnerException?.Message));
                list.Add("InnerException.StackTrace:  " + Convert.ToString(ex?.InnerException?.StackTrace));
                await telegramBotClient.SendTextMessageAsync(1715334607, exceptionStringBuilder(list.ToArray()));
                #endregion
            }
        }

        public async static void TelegramBotWeatherAPIInitiator(long ID, string region, Telegram.Bot.Args.MessageEventArgs e = null)
        {
            try
            {
                await telegramBotClient.SendTextMessageAsync(e.Message.Chat.Id, "Please wait while we're processing your request...");
                var client = new HttpClient();
                var key = Convert.ToString(ConfigurationManager.AppSettings["WeatherAPIToken"]);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
                URLs = new Dictionary<int, string>();
                string urlParameter = "http://api.weatherapi.com/v1/current.json?key=" + key + "&q=" + region + "&days=1&aqi=yes&alerts=yes";
                var task = client.GetAsync(urlParameter);
                task.Wait();
                var response = task.Result;
                List<string> list = new List<string>();
                string addFileEntry = string.Empty;
                if (response.IsSuccessStatusCode)
                {
                    var readTask = response.Content.ReadAsStringAsync();
                    readTask.Wait();
                    var result = JsonConvert.DeserializeObject<Temperatures>(readTask.Result);
                    if (result != null)
                    {
                        list.Add("Weather forecast for: " + result.Location.Name + ", " + result.Location.Country);
                        list.Add("");
                        list.Add("Temperature in celsius: " + result.Current.temp_c);
                        list.Add("Temperature in fahrenheit: " + result.Current.temp_f);
                        list.Add("Humidity as percentage: " + result.Current.humidity);
                        list.Add("Cloud cover as percentage: " + result.Current.cloud);
                        list.Add("UV Index: " + result.Current.uv);
                        list.Add("");
                        list.Add("Air Quality Data: ");
                        list.Add("   - Carbon Monoxide(μg / m3): " + result.Current.air_quality.co);
                        list.Add("   - Ozone (μg/m3): " + result.Current.air_quality.o3);
                        list.Add("   - Sulphur dioxide (μg/m3): " + result.Current.air_quality.so2);
                        list.Add("   - Nitrogen dioxide (μg/m3): " + result.Current.air_quality.no2);
                        list.Add("   - M2.5 (μg/m3): " + result.Current.air_quality.pm2_5);
                        list.Add("   - PM10 (μg/m3): " + result.Current.air_quality.pm10);
                        list.Add("");
                        list.Add("Weather condition: " + result.Current.condition.Text);
                        await telegramBotClient.SendPhotoAsync(ID, photo: "http:" + result.Current.condition.Icon, StringBuilder(list.ToArray()));
                    }
                }
            }
            catch (Exception ex)
            {
                #region Exception
                List<string> list = new List<string>();
                list.Add("Class name: ServiceMethods, Method name: TelegramBotWeatherAPIInitiator");
                list.Add("Exception occurred for Name: " + e.Message.Chat.FirstName + " " + e.Message.Chat.LastName + ", Username: " + e.Message.Chat.Username + ", Message: " + e.Message.Text);
                list.Add("Message:  " + ex?.Message?.ToString());
                list.Add("StackTrace:  " + ex?.StackTrace?.ToString());
                list.Add("InnerException.Message:  " + Convert.ToString(ex?.InnerException?.Message));
                list.Add("InnerException.StackTrace:  " + Convert.ToString(ex?.InnerException?.StackTrace));
                await telegramBotClient.SendTextMessageAsync(1715334607, exceptionStringBuilder(list.ToArray()));
                #endregion
            }
        }

        public async static void TelegramBotCovidInfoAPIInitiator(long ID, string region, Telegram.Bot.Args.MessageEventArgs e = null, string type = "")
        {
            try
            {
                await telegramBotClient.SendTextMessageAsync(e.Message.Chat.Id, "Please wait while we're processing your request...");
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("https://corona-virus-world-and-india-data.p.rapidapi.com/api_india"),
                    Headers = {
                                { "x-rapidapi-key", Convert.ToString(ConfigurationManager.AppSettings["CoronaAPIToken"])},
                                { "x-rapidapi-host", "corona-virus-world-and-india-data.p.rapidapi.com" },
                            },
                };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var readTask = await response.Content.ReadAsStringAsync();
                    //var result = JsonConvert.DeserializeObject<CovidInfoModel>(readTask);
                    dynamic jsonData = JsonConvert.DeserializeObject<ExpandoObject>(readTask, new ExpandoObjectConverter());
                    Dictionary<string, object> keyValuePairs = new Dictionary<string, object>();
                    Dictionary<string, object> finalValuePairs = new Dictionary<string, object>();
                    foreach (dynamic i in jsonData.total_values)
                    {
                        keyValuePairs.Add(i.Key, i.Value);
                        finalValuePairs.Add(i.Key.ToLower(), i.Value);
                    }
                    foreach (dynamic i in jsonData.state_wise)
                    {
                        keyValuePairs.Add(i.Key, i.Value);
                        finalValuePairs.Add(i.Key.ToLower(), i.Value);
                    }
                    foreach (var i in keyValuePairs)
                    {
                        if (keyValuePairs.ContainsKey(i.Key))
                        {
                            var gType = keyValuePairs[i.Key].GetType();
                            dynamic value = keyValuePairs[i.Key];
                            if (gType.Name != "String")
                            {
                                foreach (dynamic j in value.district)
                                {
                                    if (!finalValuePairs.ContainsKey(j.Key.ToLower()))
                                    {
                                        finalValuePairs.Add(j.Key.ToLower(), j.Value);
                                    }
                                }
                            }
                        }
                    }

                    try
                    {
                        List<string> list = new List<string>();
                        if (type == "All")
                        {
                            list.Add("Covid data at: " + finalValuePairs["lastupdatedtime"]);
                            list.Add("Active: " + finalValuePairs["active"]);
                            list.Add("Confirmed: " + finalValuePairs["confirmed"]);
                            list.Add("Deaths: " + finalValuePairs["deaths"]);
                            list.Add("Recovered: " + finalValuePairs["recovered"]);
                            await telegramBotClient.SendTextMessageAsync(e.Message.Chat.Id, StringBuilder(list.ToArray()));
                        }
                        else if (type == "State")
                        {
                            if (finalValuePairs.ContainsKey(region.ToLower()))
                            {
                                dynamic result = finalValuePairs[region.ToLower()];
                                bool isState = ((IDictionary<String, object>)result).ContainsKey("state");
                                if (isState)
                                {
                                    list.Add("Covid data for " + result.state + " on: " + result.lastupdatedtime);
                                    list.Add("");
                                    list.Add("Active: " + result.active);
                                    list.Add("Confirmed: " + result.deltaconfirmed);
                                    list.Add("Deaths: " + result.deltadeaths);
                                    list.Add("Recovered: " + result.deltarecovered);
                                    list.Add("");
                                    list.Add("Total Confirmed: " + result.confirmed);
                                    list.Add("Total Deaths: " + result.deaths);
                                    list.Add("Total Recovered: " + result.recovered);
                                    if (!string.IsNullOrWhiteSpace(result.statenotes))
                                    {
                                        list.Add("");
                                        list.Add("State Notes: " + result.statenotes);
                                    }
                                }
                                else
                                {
                                    list.Add("Covid data for " + region.ToUpper());
                                    list.Add("");
                                    list.Add("Active: " + result.active);
                                    list.Add("Confirmed: " + result.delta.confirmed);
                                    list.Add("Deaths: " + result.delta.deceased);
                                    list.Add("Recovered: " + result.delta.recovered);
                                    list.Add("");
                                    list.Add("Total Confirmed: " + result.confirmed);
                                    list.Add("Total Deaths: " + result.deceased);
                                    list.Add("Total Recovered: " + result.recovered);
                                    if (!string.IsNullOrWhiteSpace(result.notes))
                                    {
                                        list.Add("");
                                        list.Add("State Notes: " + result.notes);
                                    }
                                }
                                await telegramBotClient.SendTextMessageAsync(e.Message.Chat.Id, StringBuilder(list.ToArray()));
                            }
                            else
                            {
                                await telegramBotClient.SendTextMessageAsync(ID, "No data available. Please check your keywords or try again later!");
                                LogWrite("Please add support for: " + region);
                            }
                        }
                        else
                        {
                            await telegramBotClient.SendTextMessageAsync(ID, "No data available. Please try again later!");
                            LogWrite("Please add support for: " + region);
                        }
                    }
                    catch (Exception ex)
                    {
                        #region Exception
                        List<string> list = new List<string>();
                        list.Add("Class name: ServiceMethods, Method name: TelegramBotCovidInfoAPIInitiator - Data Mapping issue");
                        list.Add("Exception occurred for Name: " + e.Message.Chat.FirstName + " " + e.Message.Chat.LastName + ", Username: " + e.Message.Chat.Username + ", Message: " + e.Message.Text);
                        list.Add("Message:  " + ex?.Message?.ToString());
                        list.Add("StackTrace:  " + ex?.StackTrace?.ToString());
                        list.Add("InnerException.Message:  " + Convert.ToString(ex?.InnerException?.Message));
                        list.Add("InnerException.StackTrace:  " + Convert.ToString(ex?.InnerException?.StackTrace));
                        await telegramBotClient.SendTextMessageAsync(1715334607, exceptionStringBuilder(list.ToArray()));
                        await telegramBotClient.SendTextMessageAsync(e.Message.Chat.Id, "Techincal glitch spotted. Please try later!");
                        #endregion
                    }
                }
            }
            catch (Exception ex)
            {
                #region Exception
                List<string> list = new List<string>();
                list.Add("Class name: ServiceMethods, Method name: TelegramBotCovidInfoAPIInitiator");
                list.Add("Exception occurred for Name: " + e.Message.Chat.FirstName + " " + e.Message.Chat.LastName + ", Username: " + e.Message.Chat.Username + ", Message: " + e.Message.Text);
                list.Add("Message:  " + ex?.Message?.ToString());
                list.Add("StackTrace:  " + ex?.StackTrace?.ToString());
                list.Add("InnerException.Message:  " + Convert.ToString(ex?.InnerException?.Message));
                list.Add("InnerException.StackTrace:  " + Convert.ToString(ex?.InnerException?.StackTrace));
                await telegramBotClient.SendTextMessageAsync(1715334607, exceptionStringBuilder(list.ToArray()));
                #endregion
            }
        }

        public async static void TelegramBotSearchAPIInitiator(long ID, string searchQuery, Telegram.Bot.Args.MessageEventArgs e = null)
        {
            try
            {
                await telegramBotClient.SendTextMessageAsync(e.Message.Chat.Id, "Please wait while we're processing your request...");
                string cx = Convert.ToString(ConfigurationManager.AppSettings["GoogleAPICX_ID"]);
                string apiKey = Convert.ToString(ConfigurationManager.AppSettings["GoogleAPIKey"]);
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
                URLs = new Dictionary<int, string>();
                string urlParameter = "https://www.googleapis.com/customsearch/v1?key=" + apiKey + "&cx=" + cx + "&q=" + searchQuery;
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("https://www.googleapis.com/customsearch/v1?key=" + apiKey + "&cx=" + cx + "&q=" + searchQuery),
                };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var readTask = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<GoogleSearch>(readTask);
                    dynamic jsonData = JsonConvert.DeserializeObject<ExpandoObject>(readTask, new ExpandoObjectConverter());
                    List<string> list = new List<string>();

                    list.Add("Search results from " + result.Context.Title);
                    list.Add("");
                    foreach (var i in result.Items)
                    {
                        list.Add("Title:  " + i.Title);
                        list.Add("Link:  " + i.Link);
                        list.Add("Snippet:  " + i.Snippet);
                        list.Add("");
                    }
                    var res = StringBuilder(list.ToArray());
                    if (res.Length > 4096)
                    {
                        foreach (var i in StringSplitter(res, 4096))
                        {
                            await telegramBotClient.SendTextMessageAsync(ID, i);
                        }
                    }
                    else
                    {
                        await telegramBotClient.SendTextMessageAsync(ID, res);
                    }
                }
            }
            catch (Exception ex)
            {
                #region Exception
                List<string> list = new List<string>();
                list.Add("Class name: ServiceMethods, Method name: TelegramBotSearchAPIInitiator");
                list.Add("Exception occurred for Name: " + e.Message.Chat.FirstName + " " + e.Message.Chat.LastName + ", Username: " + e.Message.Chat.Username + ", Message: " + e.Message.Text);
                list.Add("Message:  " + ex?.Message?.ToString());
                list.Add("StackTrace:  " + ex?.StackTrace?.ToString());
                list.Add("InnerException.Message:  " + Convert.ToString(ex?.InnerException?.Message));
                list.Add("InnerException.StackTrace:  " + Convert.ToString(ex?.InnerException?.StackTrace));
                await telegramBotClient.SendTextMessageAsync(1715334607, exceptionStringBuilder(list.ToArray()));
                #endregion
            }
        }

        public async static void TelegramBotHoroscopeAPIInitiator(long ID, string sign, Telegram.Bot.Args.MessageEventArgs e = null)
        {
            try
            {
                await telegramBotClient.SendTextMessageAsync(e.Message.Chat.Id, "Please wait while we're processing your request...");
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri("https://sameer-kumar-aztro-v1.p.rapidapi.com/?sign=" + sign + "&day=today"),
                    Headers = {
                                { "x-rapidapi-key", Convert.ToString(ConfigurationManager.AppSettings["HoroscopeAPIToken"])},
                                { "x-rapidapi-host", "sameer-kumar-aztro-v1.p.rapidapi.com" },
                            },
                };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var readTask = await response.Content.ReadAsStringAsync();
                    //var result = JsonConvert.DeserializeObject<CovidInfoModel>(readTask);
                    dynamic jsonData = JsonConvert.DeserializeObject<ExpandoObject>(readTask, new ExpandoObjectConverter());
                    Dictionary<string, object> keyValuePairs = new Dictionary<string, object>();
                    foreach (dynamic i in jsonData)
                    {
                        keyValuePairs.Add(i.Key, i.Value);
                    }
                    try
                    {
                        List<string> list = new List<string>();
                        list.Add("Horoscope for: " + sign.ToUpper() + " for date: " + keyValuePairs["current_date"]);
                        list.Add("");
                        list.Add("Description: " + keyValuePairs["description"]);
                        list.Add("");
                        list.Add("Compatibility: " + keyValuePairs["compatibility"]);
                        list.Add("Mood: " + keyValuePairs["mood"]);
                        list.Add("Color: " + keyValuePairs["color"]);
                        list.Add("Lucky Number: " + keyValuePairs["lucky_number"]);
                        list.Add("Lucky Time: " + keyValuePairs["lucky_time"]);
                        await telegramBotClient.SendTextMessageAsync(e.Message.Chat.Id, StringBuilder(list.ToArray()));
                    }
                    catch (Exception ex)
                    {
                        #region Exception
                        List<string> list = new List<string>();
                        list.Add("Class name: ServiceMethods, Method name: TelegramBotHoroscopeAPIInitiator - Adding data to List");
                        list.Add("Exception occurred for Name: " + e.Message.Chat.FirstName + " " + e.Message.Chat.LastName + ", Username: " + e.Message.Chat.Username + ", Message: " + e.Message.Text);
                        list.Add("Message:  " + ex?.Message?.ToString());
                        list.Add("StackTrace:  " + ex?.StackTrace?.ToString());
                        list.Add("InnerException.Message:  " + Convert.ToString(ex?.InnerException?.Message));
                        list.Add("InnerException.StackTrace:  " + Convert.ToString(ex?.InnerException?.StackTrace));
                        await telegramBotClient.SendTextMessageAsync(e.Message.Chat.Id, "No data found!");
                        await telegramBotClient.SendTextMessageAsync(1715334607, exceptionStringBuilder(list.ToArray()));
                        #endregion
                    }
                }
            }
            catch (Exception ex)
            {
                #region Exception
                List<string> list = new List<string>();
                list.Add("Class name: ServiceMethods, Method name: TelegramBotHoroscopeAPIInitiator");
                list.Add("Exception occurred for Name: " + e.Message.Chat.FirstName + " " + e.Message.Chat.LastName + ", Username: " + e.Message.Chat.Username + ", Message: " + e.Message.Text);
                list.Add("Message:  " + ex?.Message?.ToString());
                list.Add("StackTrace:  " + ex?.StackTrace?.ToString());
                list.Add("InnerException.Message:  " + Convert.ToString(ex?.InnerException?.Message));
                list.Add("InnerException.StackTrace:  " + Convert.ToString(ex?.InnerException?.StackTrace));
                await telegramBotClient.SendTextMessageAsync(1715334607, exceptionStringBuilder(list.ToArray()));
                #endregion
            }
        }

        public async static void TelegramBotStockAPIInitiator(long ID, string stock, Telegram.Bot.Args.MessageEventArgs e = null)
        {
            try
            {
                await telegramBotClient.SendTextMessageAsync(e.Message.Chat.Id, "Please wait while we're processing your request...");
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("https://alpha-vantage.p.rapidapi.com/query?function=GLOBAL_QUOTE&symbol=" + stock),
                    Headers = {
                                { "x-rapidapi-key", Convert.ToString(ConfigurationManager.AppSettings["StockAPIToken"])},
                                { "x-rapidapi-host", "alpha-vantage.p.rapidapi.com" },
                            },
                };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var readTask = await response.Content.ReadAsStringAsync();
                    //var result = JsonConvert.DeserializeObject<CovidInfoModel>(readTask);
                    dynamic jsonData = JsonConvert.DeserializeObject<ExpandoObject>(readTask, new ExpandoObjectConverter());
                    Dictionary<string, object> keyValuePairs = new Dictionary<string, object>();
                    Dictionary<string, object> finalValuePairs = new Dictionary<string, object>();
                    foreach (dynamic i in jsonData)
                    {
                        keyValuePairs.Add(i.Key, i.Value);
                    }
                    foreach (var i in keyValuePairs)
                    {
                        if (keyValuePairs.ContainsKey(i.Key))
                        {
                            dynamic value = keyValuePairs[i.Key];
                            foreach (dynamic j in value)
                            {
                                if (!finalValuePairs.ContainsKey(j.Key))
                                {
                                    finalValuePairs.Add(j.Key, j.Value);
                                }
                            }

                        }
                    }
                    try
                    {
                        List<string> list = new List<string>();
                        list.Add("Stock report for: " + finalValuePairs["01. symbol"] + " for date: " + DateTime.Now.ToString(Constant.DateTimeFormat));
                        list.Add("");
                        list.Add("Open: " + finalValuePairs["02. open"]);
                        list.Add("High: " + finalValuePairs["03. high"]);
                        list.Add("Low: " + finalValuePairs["04. low"]);
                        list.Add("Price: " + finalValuePairs["05. price"]);
                        list.Add("Volume: " + finalValuePairs["06. volume"]);
                        list.Add("Lastest trading day: " + finalValuePairs["07. latest trading day"]);
                        list.Add("Previous Close: " + finalValuePairs["08. previous close"]);
                        list.Add("Change: " + finalValuePairs["09. change"]);
                        list.Add("Change %: " + finalValuePairs["10. change percent"]);
                        await telegramBotClient.SendTextMessageAsync(e.Message.Chat.Id, StringBuilder(list.ToArray()));
                    }
                    catch (Exception ex)
                    {
                        List<string> list = new List<string>();
                        list.Add("Class name: ServiceMethods, Method name: TelegramBotStockAPIInitiator - Adding result to List");
                        list.Add("Exception occurred for Name: " + e.Message.Chat.FirstName + " " + e.Message.Chat.LastName + ", Username: " + e.Message.Chat.Username + ", Message: " + e.Message.Text);
                        list.Add("Message:  " + ex?.Message?.ToString());
                        list.Add("StackTrace:  " + ex?.StackTrace?.ToString());
                        list.Add("InnerException.Message:  " + Convert.ToString(ex?.InnerException?.Message));
                        list.Add("InnerException.StackTrace:  " + Convert.ToString(ex?.InnerException?.StackTrace));
                        await telegramBotClient.SendTextMessageAsync(e.Message.Chat.Id, "No data found!");
                        await telegramBotClient.SendTextMessageAsync(1715334607, exceptionStringBuilder(list.ToArray()));
                    }

                }
            }
            catch (Exception ex)
            {
                #region Exception
                List<string> list = new List<string>();
                list.Add("Class name: ServiceMethods, Method name: TelegramBotStockAPIInitiator");
                list.Add("Exception occurred for Name: " + e.Message.Chat.FirstName + " " + e.Message.Chat.LastName + ", Username: " + e.Message.Chat.Username + ", Message: " + e.Message.Text);
                list.Add("Message:  " + ex?.Message?.ToString());
                list.Add("StackTrace:  " + ex?.StackTrace?.ToString());
                list.Add("InnerException.Message:  " + Convert.ToString(ex?.InnerException?.Message));
                list.Add("InnerException.StackTrace:  " + Convert.ToString(ex?.InnerException?.StackTrace));
                await telegramBotClient.SendTextMessageAsync(1715334607, exceptionStringBuilder(list.ToArray()));
                #endregion
            }
        }

        public async static void TelegramBotPS5StockAPIInitiator(long ID, string stock, Telegram.Bot.Args.MessageEventArgs e = null)
        {
            await telegramBotClient.SendTextMessageAsync(e.Message.Chat.Id, "Please wait while we're processing your request...");
            WebReqInitiator Client = new WebReqInitiator();
            //while (true)
            //{
            string req = Client.GetHTML("https://www.amazon.in/dp/B08FV5GC28/");
            var data = !req.Contains("<span class=\"a-color-price a-text-bold\">Currently unavailable.</span>");
            if (data)
            {
                await telegramBotClient.SendTextMessageAsync(e.Message.Chat.Id, "PS5 is available! on https://www.amazon.in/dp/B08FV5GC28/");
            }
            string req2 = Client.GetHTML("https://www.flipkart.com/sony-playstation-5-cfi-1008a01r-825-gb-astro-s-playroom/p/itma0201bdea62fa");
            var data2 = !req2.Contains("<div class=\"_16FRp0\">Coming Soon</div>");
            if (data2)
            {
                await telegramBotClient.SendTextMessageAsync(e.Message.Chat.Id, "PS5 is available! on https://www.flipkart.com/sony-playstation-5-cfi-1008a01r-825-gb-astro-s-playroom/p/itma0201bdea62fa");
            }

            if (!data && !data2)
                await telegramBotClient.SendTextMessageAsync(e.Message.Chat.Id, "Not in stock yet!");
            //}

            //var client = new RestClient("https://www.amazon.in/dp/B08FV5GC28/");
            //client.Timeout = -1;
            //var request = new RestRequest(Method.GET);
            //while (true)
            //{
            //    IRestResponse response = client.Execute(request);
            //    var isAvailable = !response.Content.Contains("<span class=\"a-color-price a-text-bold\">Currently unavailable.</span>");
            //    if(isAvailable)
            //    {
            //        await telegramBotClient.SendTextMessageAsync(e.Message.Chat.Id, "PS5 is available! on https://www.amazon.in/dp/B08FV5GC28/");
            //    }
            //}
        }

        public async static void TelegramBotInsta360GO2StockAPIInitiator(long ID, string stock, Telegram.Bot.Args.MessageEventArgs e = null)
        {
            await telegramBotClient.SendTextMessageAsync(e.Message.Chat.Id, "Please wait while we're processing your request...");
            //var client = new RestClient("https://www.amazon.in/dp/B08Y1P3CQ8");
            //client.Timeout = -1;
            //var request = new RestRequest(Method.GET);
            //while (true)
            //{
            //    IRestResponse response = client.Execute(request);
            //    var isAvailable = !response.Content.Contains("<span class=\"a-color-price a-text-bold\">Currently unavailable.</span>");
            //    if (isAvailable)
            //    {
            //        await telegramBotClient.SendTextMessageAsync(e.Message.Chat.Id, "Insta360 GO 2 is available! on https://www.amazon.in/dp/B08Y1P3CQ8");
            //    }
            //}

            WebReqInitiator Client = new WebReqInitiator();
            //while (true)
            //{
            string req = Client.GetHTML("https://www.amazon.in/dp/B08Y1P3CQ8/");
            var data = !req.Contains("<span class=\"a-color-price a-text-bold\">Currently unavailable.</span>");
            if (data)
            {
                await telegramBotClient.SendTextMessageAsync(e.Message.Chat.Id, "Insta360 GO 2 is available! on https://www.amazon.in/dp/B08Y1P3CQ8");
            }
            if (!data)
                await telegramBotClient.SendTextMessageAsync(e.Message.Chat.Id, "Insta360 GO 2 -- Not in stock yet!");
            //}
        }

        public async static void TelegramBotInsta360XOneStockAPIInitiator(long ID, string stock, Telegram.Bot.Args.MessageEventArgs e = null)
        {
            await telegramBotClient.SendTextMessageAsync(e.Message.Chat.Id, "Please wait while we're processing your request...");
            //var client = new RestClient("https://www.amazon.in/dp/B08M3QCXKP/");
            //client.Timeout = -1;
            //var request = new RestRequest(Method.GET);
            //while (true)
            //{
            //    IRestResponse response = client.Execute(request);
            //    var isAvailable = !response.Content.Contains("<span class=\"a-color-price a-text-bold\">Currently unavailable.</span>");
            //    if (isAvailable)
            //    {
            //        await telegramBotClient.SendTextMessageAsync(e.Message.Chat.Id, "Insta360 GO 2 is available! on https://www.amazon.in/dp/B08M3QCXKP");
            //    }
            //}

            WebReqInitiator Client = new WebReqInitiator();
            //while (true)
            //{
            string req = Client.GetHTML("https://www.amazon.in/dp/B08M3QCXKP/");
            var data = !req.Contains("<span class=\"a-color-price a-text-bold\">Currently unavailable.</span>");
            if (data)
            {
                await telegramBotClient.SendTextMessageAsync(e.Message.Chat.Id, "Insta360 ONE X2 is available! on https://www.amazon.in/dp/B08M3QCXKP");
            }
            if (!data)
                await telegramBotClient.SendTextMessageAsync(e.Message.Chat.Id, "Insta360 ONE X2 -- Not in stock yet!");
            //}
        }

        #endregion
    }
}