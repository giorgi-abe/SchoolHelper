using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SchoolHelperApplicationServices.Abstraction;
using SchoolHelperApplicationServices.Implementation;
using SchoolHelperDomainServices.Abstraction;
using SchoolHelperDomainServices.Abstraction.LoginServices;
using SchoolHelperDomainServices.Abstraction.ModelServices;
using SchoolHelperDomainServices.Implementation;
using SchoolHelperDomainServices.Implementation.LoginServices;
using SchoolHelperDomainServices.Implementation.ModelServices;
using StudentMSDomainServices.implementations;

namespace SchoolHelperWeb
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
            services.AddScoped<IPhotoService, PhotoService>();
            services.AddScoped<IStudentAccountService, StudentAccountService>();
            services.AddScoped<ITeacherAccountService, TeacherAccountService>();
            services.AddScoped<ISendMailService, SendMailService>();
            services.AddScoped<ISchoolHelperManager, SchoolHelperManager>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<ISubjectService, SubjectService>();
            services.AddScoped<IToDoService, ToDoService>();
            services.AddScoped<IUserStudentService, UserStudentService>();
            services.AddScoped<IUserSubjectService, UserSubjectService>();
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
