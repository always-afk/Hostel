using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Hostel.PresentationWeb
{
    public class Startup
    {
        private IConfigurationRoot _confStr;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            _confStr = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddMvc().AddRazorOptions(opt => 
            {
                opt.ViewLocationFormats.Add("/Views/Students/{0}.cshtml");
                opt.ViewLocationFormats.Add("/Views/Rooms/{0}.cshtml");
            });
            services.AddDbContext<DataAccess.Context.AppDBContext>(options => options.UseSqlServer(_confStr.GetConnectionString("DefaultConnection")));
            services.AddScoped<DataAccess.Repositories.Interfaces.IRoomRepository, DataAccess.Repositories.Implementation.SQLRoomRepository>();
            services.AddScoped<DataAccess.Repositories.Interfaces.IStudentRepository, DataAccess.Repositories.Implementation.SQLStudentRepository>();
            services.AddScoped<BusinessLogic.Services.Interfaces.IMockService, BusinessLogic.Services.Implementation.MockService>();
            services.AddScoped<BusinessLogic.Services.Interfaces.IStudentsService, BusinessLogic.Services.Implementation.StudentsService>();
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
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Rooms}/{id?}");
            });
        }
    }
}
