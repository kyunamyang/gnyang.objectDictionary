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
using AutoMapper;
using Company.ObjectDictionary.Common;
using Company.ObjectDictionary.Database;
using Company.ObjectDictionary.Entity;
using Company.ObjectDictionary.Repository;
using Company.ObjectDictionary.Repository.Interface;
using Company.ObjectDictionary.Service;
using Company.ObjectDictionary.Service.Interface;
using Company.ObjectDictionary.ViewModel;

namespace Company.ObjectDictionary.Web
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
            services.AddControllersWithViews();
            services.AddRazorPages().AddRazorRuntimeCompilation();
            //
            services.AddAutoMapper(typeof(Startup));
            services.AddSingleton( _ => Configuration);

            // 
            services.AddTransient(typeof(IGenericCommandRepository<Account>), typeof(AccountRepository));
            services.AddTransient(typeof(IGenericQueryRepository<Account>), typeof(AccountRepository));
            services.AddTransient(typeof(IGenericCommandRepository<User>), typeof(UserRepository));
            services.AddTransient(typeof(IGenericQueryRepository<User>), typeof(UserRepository));
            services.AddTransient(typeof(IGenericCommandRepository<Model>), typeof(ModelRepository));
            services.AddTransient(typeof(IGenericQueryRepository<Model>), typeof(ModelRepository));
            services.AddTransient(typeof(IGenericCommandRepository<Field>), typeof(FieldRepository));
            services.AddTransient(typeof(IGenericQueryRepository<Field>), typeof(FieldRepository));
            services.AddTransient(typeof(IGenericCommandRepository<Source>), typeof(SourceRepository));
            services.AddTransient(typeof(IGenericQueryRepository<Source>), typeof(SourceRepository));


            services.AddTransient(typeof(ICodeService<CodeViewModel>), typeof(CodeService));

            //
            services.AddScoped(typeof(IGenericService<ModelViewModel>), typeof(ModelService));
            services.AddScoped(typeof(IGenericService<FieldViewModel>), typeof(FieldService));
            services.AddScoped(typeof(IGenericService<SourceViewModel>), typeof(SourceService));
            

            services.AddTransient(typeof(ICrud<>), typeof(MariaDb<>));
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
