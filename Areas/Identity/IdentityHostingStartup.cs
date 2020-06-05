using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(LoginApp.Areas.Identity.IdentityHostingStartup))]
namespace LoginApp.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}