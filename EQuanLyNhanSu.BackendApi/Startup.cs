using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EQuanLyNhanSu.Application.Catalog.Employee;
using EQuanLyNhanSu.Application.Catalog.Employee.Service;
using EQuanLyNhanSu.Application.Catalog.System;
using EQuanLyNhanSu.Data.EF;
using EQuanLyNhanSu.Data.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace EQuanLyNhanSu.BackendApi
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
            services.AddDbContext<EQuanLyNhanSuDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("EQuanLyNhanSuDb")));
            services.AddIdentity<User, Role>()
            .AddEntityFrameworkStores<EQuanLyNhanSuDbContext>()
            .AddDefaultTokenProviders();
            services.AddTransient<IPublicEmployeeService, PublicEmployeeService>();
            services.AddTransient<IManagedEmployeeService, ManagedEmployeeService>();
            services.AddTransient<UserManager<User>, UserManager<User>>();
            services.AddTransient<SignInManager<User>, SignInManager<User>>();
            services.AddTransient<IUserService, UserService>();
            services.AddSwaggerGen(c=> {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Swagger QuanLyNhanSu", Version = "v1" });
                });
            services.AddControllersWithViews();
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

            app.UseSwagger();

            app.UseSwaggerUI(c=> {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger QuanLyNhanSu V1");
                }
            );
            app.UseAuthentication();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
