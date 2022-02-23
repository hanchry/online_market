using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database.Persistance;
using Database.Persistance.Readers;
using Database.Persistance.Readers.Implemented;
using market.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace market
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
            services.AddControllers();
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo {Title = "market", Version = "v1"}); });
            
            services.AddDbContextFactory<AlbionMarketContext>(opt => opt.UseNpgsql(@"User ID = ozohxixh; Password = IUQZq23Jd3_OE8RA5Ry9NTiEIeOfDhAR; Server = abul.db.elephantsql.com; Database = ozohxixh"));

            services.AddTransient<IItemIdReader, ItemReader>();
            services.AddTransient<ICityReader, CityReader>();
            services.AddTransient<AlbionData>();
            services.AddSingleton<Calculator>();
            services.AddTransient<Diference>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "market v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}