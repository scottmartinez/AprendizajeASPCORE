using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using EcommerceSistemaVsShopify.Models;
using EcommerceSistemaVsShopify.Repository;
using Newtonsoft.Json.Serialization;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceSistemaVsShopify
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
            var conexion=Configuration.GetConnectionString("BaseDatosVICOSA");
            string urltienda=Configuration.GetValue<string>("UrlTienda");
            string tokenacceso=Configuration.GetValue<string>("TokenAcceso");
            string ClaveApi=Configuration.GetValue<string>("ClaveApi");
            string Contrasenia=Configuration.GetValue<string>("Contrasenia");
            CadenaDeConexionManager.Valor = conexion;
            CadenaDeConexionManager.TokenDeAcceso = tokenacceso;
            CadenaDeConexionManager.UrlTienda = urltienda;
            CadenaDeConexionManager.ClaveApi = ClaveApi;
            CadenaDeConexionManager.Contrasenia = Contrasenia;
            services.AddControllersWithViews();
            // Add the whole configuration object here.
            //services.AddSingleton<IConfiguration>(Configuration);
          
            services.AddTransient<IExistenciasEcommerce,ExistenciaEcommerceService>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,IWebHostEnvironment env)
        {
            if(env.IsDevelopment())
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
