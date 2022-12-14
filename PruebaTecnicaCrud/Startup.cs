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
using PruebaTecnicaCrud.Repositories;
using PruebaTecnicaCrud.DataContext;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using PruebaTecnicaCrud.Mapper;

namespace PruebaTecnicaCrud
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

            services.AddDbContext<PruebaTecnicaCrudDbContext>(opts => opts.UseSqlServer(
                Configuration.GetConnectionString("DefaultConnection")), ServiceLifetime.Transient);

            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();


            services.AddCors(c => c.AddPolicy("corsapp", builder =>
            {
                builder.WithOrigins("*").AllowAnyHeader().AllowAnyMethod();
            }));

            var mapperConfig = new MapperConfiguration(mpc =>
            {
                mpc.AddProfile(new MappingConfig());
            });

            services.AddSingleton(mapperConfig.CreateMapper());

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

            app.UseCors("corsapp");

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Client}/{action=Index}/{id?}");
            });
        }
    }
}
