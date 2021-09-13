using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace Events
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                //.UseUrls(@"http://*:80/events")
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}
