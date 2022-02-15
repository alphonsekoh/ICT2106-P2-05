using System;
using System.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PainAssessment.Data;

[assembly: HostingStartup(typeof(PainAssessment.Areas.Identity.IdentityHostingStartup))]
namespace PainAssessment.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<HospitalContext>(options =>
                   //options.UseSqlServer(context.Configuration.GetConnectionString("DefaultConnection")));
                options.UseMySQL(context.Configuration.GetConnectionString("DefaultConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<HospitalContext>();
            });
        }
    }
}