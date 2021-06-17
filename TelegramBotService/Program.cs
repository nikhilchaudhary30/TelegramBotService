using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace TelegramBotService
{
    class Program
    {
        static void Main(string[] args)
        {
            var exitCode = HostFactory.Run(x =>
            {
                x.Service<ServiceMethods>(s =>
                {
                    s.ConstructUsing(service => new ServiceMethods());
                    s.WhenStarted(service => service.Start());
                    s.WhenStopped(service => service.Stop());
                });

                x.RunAsLocalSystem();

                x.SetServiceName("TelegramBotService");
                x.SetDisplayName("Telegram Bot Service");
                x.SetDescription("This is the Telegram Bot Notification Service.");
            });

            int exitCodeValue = (int)Convert.ChangeType(exitCode, exitCode.GetTypeCode());
            Environment.ExitCode = exitCodeValue;
        }
    }
}
