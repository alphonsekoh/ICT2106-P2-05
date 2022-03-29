using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PainAssessment.Areas.Admin.Data;
using PainAssessment.Data;
using System;
using PainAssessment.Areas.ModuleTwo.Data;
using PainAssessment.Areas.ModuleTwo.Models;

namespace PainAssessment
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // IHost host = CreateHostBuilder(args).Build();
            var host = CreateHostBuilder(args).Build();

            //using (var scope = host.Services.CreateScope())
            //{
            //    var services = scope.ServiceProvider;

            //    try
            //    {
            //        PatientSeedData.Initialize(services);

            //    }
            //    catch (Exception ex)
            //    {
            //        var logger = services.GetRequiredService<ILogger<Program>>();
            //        logger.LogError(ex, "An error occurred seeding the DB.");
            //    }
            //}
            //CreateDbIfNotExists(host);
            host.Run();

        }

        //private static void CreateDbIfNotExists(IHost host)
        //{
        //    using IServiceScope scope = host.Services.CreateScope();
        //    IServiceProvider services = scope.ServiceProvider;
        //    try
        //    {
        //        HospitalContext context = services.GetRequiredService<HospitalContext>();
        //        PractitionerClinicDbInitializer.Initialize(context);
        //    }
        //    catch (Exception ex)
        //    {
        //        ILogger<Program> logger = services.GetRequiredService<ILogger<Program>>();
        //        logger.LogError(ex, "An error occurred creating the DB.");
        //    }
        //}


        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
.ConfigureWebHostDefaults(webBuilder =>
{
    webBuilder.UseStartup<Startup>();
});
        }
    }
}
