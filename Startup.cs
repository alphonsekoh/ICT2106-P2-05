using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PainAssessment.Areas.Admin.Data;
using PainAssessment.Areas.Admin.Services;
using PainAssessment.Data;
using PainAssessment.Domain;
using PainAssessment.Interfaces;
using System;

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
            //services.Configure<IdentityOptions>(options =>
            //{
            //    // Password settings.
            //    options.Password.RequireDigit = true;
            //    options.Password.RequireLowercase = true;
            //    options.Password.RequireNonAlphanumeric = true;
            //    options.Password.RequireUppercase = true;
            //    options.Password.RequiredLength = 6;
            //    options.Password.RequiredUniqueChars = 1;

            //    // Lockout settings.
            //    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            //    options.Lockout.MaxFailedAccessAttempts = 5;
            //    options.Lockout.AllowedForNewUsers = true;

            //    // User settings.
            //    options.User.AllowedUserNameCharacters =
            //    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
            //    options.User.RequireUniqueEmail = false;
            //});

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(x => x.LoginPath = "/Login/Index");

            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

                options.LoginPath = "/Login";
                //options.AccessDeniedPath = "/Identity/Account/Logout";
                options.SlidingExpiration = true;
            });

            services.AddDbContext<HospitalContext>(options =>
            // Localdb connection 
            // options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            // MySQL connection
            options.UseMySQL(Configuration.GetConnectionString("DefaultConnection")));

            services.AddDatabaseDeveloperPageExceptionFilter();

            // Add DI for Services
            services.AddScoped<IClinicalAreaService, ClinicalAreaService>();
            services.AddScoped<IPracticeTypeService, PracticeTypeService>();
            services.AddScoped<IPractitionerService, PractitionerService>();
            services.AddScoped<IPatientService, PatientService>();
            services.AddScoped<IGatewayManager, GatewayManager>();
            services.AddScoped<IPainEducationService, PainEducationService>();

            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            // To add everytime there's new interface
            services.AddTransient<ITemplateChecklistService, TemplateChecklistService>();
            services.AddTransient<IDefaultQuestionsService, DefaultQuestionService>();
            services.AddTransient<ILoginService, LoginService>();
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

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //app.UseEndpoints(endpoints =>
                //{
                //    endpoints.MapControllerRoute(
                //      name: "Login",
                //      pattern: "{controller=Login}/{action=Index}/{id?}"
                //    );
                //});
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
                
            });
        }
    }
}
