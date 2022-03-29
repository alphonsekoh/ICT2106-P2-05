using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PainAssessment.Areas.Admin.Data;
using PainAssessment.Areas.Admin.Services;
using PainAssessment.Data;


using PainAssessment.Areas.ModuleTwo.Data;

namespace PainAssessment
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<HospitalContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddDatabaseDeveloperPageExceptionFilter();

            // Add DI for Services
            services.AddScoped<IClinicalAreaService, ClinicalAreaService>();
            services.AddScoped<IPracticeTypeService, PracticeTypeService>();
            services.AddScoped<IPractitionerService, PractitionerService>();
            services.AddScoped<IPatientService, PatientService>();
            services.AddScoped<IGatewayManager, GatewayManager>();
            services.AddScoped<IPainEducationService, PainEducationService>();


            services.AddControllersWithViews();

            services.AddDbContext<MvcChecklistContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("MvcChecklistContext")));

            services.AddDbContext<MvcConsultationChecklistContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("MvcConsultationChecklistContext")));


            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddDbContext<ConsultationContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("ConsultationContext")));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllerRoute(
                      name: "Admin",
                      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                    );
                    endpoints.MapControllerRoute(
                      name: "Module2",
                      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                    );
                });
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
