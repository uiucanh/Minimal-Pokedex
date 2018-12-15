using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using MinimalPokedex.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace MinimalPokedex
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                Configuration["Data:MinimalPokedexPokemons:ConnectionString"]));
            services.AddTransient<IPokemonRepository, EFPokemonRepository>();
            services.AddScoped<Team>(sp => SessionTeam.GetTeam(sp));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddMvc();
            services.AddMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }
            app.UseStaticFiles();
            app.UseSession();

            app.UseMvc(routes => {
                routes.MapRoute(
                name: "pokemonDetail",
                template: "Pokemon/{id:int}/",
                defaults: new { controller = "Pokemon", action = "Pkm" });

                routes.MapRoute(
                name: "pokemonPagination",
                template: "Pokemon/Page{listPage}",
                defaults: new { controller = "Pokemon", action="List"});

                routes.MapRoute(
                name: null,
                template: "Search/Page{listPage}/",
                defaults: new { controller = "Search", action = "Index" });

                routes.MapRoute(
                name: null,
                template: "Types/",
                defaults: new { controller = "Search", action = "ListType" });

                routes.MapRoute(
                name: null,
                template: "Types/{typeName}",
                defaults: new { controller = "Search", action = "FilterType" });

                routes.MapRoute(
                name: null,
                template: "Gens/",
                defaults: new { controller = "Search", action = "ListGeneration" });

                routes.MapRoute(
                name: null,
                template: "Gens/Num{genNum}/Page{listPage}",
                defaults: new { controller = "Search", action = "FilterGen" });

                routes.MapRoute(
                name: null,
                template: "Gens/Num{genNum}",   
                defaults: new { controller = "Search", action = "FilterGen" });

                routes.MapRoute(
                name: "default",
                template: "{controller=Pokemon}/{action=List}/{id?}");
            });
        }
    }
}
