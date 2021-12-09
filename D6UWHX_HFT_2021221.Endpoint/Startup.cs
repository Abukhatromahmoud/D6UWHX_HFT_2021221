using D6UWHX_HFT_2021221.Data;
using D6UWHX_HFT_2021221.Logic;
using D6UWHX_HFT_2021221.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace D6UWHX_HFT_2021221.Endpoint
{
    public class Startup
    {

  

        public IConfiguration Configuration { get; set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddTransient<ITrackLogic, TrackLogic>();
            services.AddTransient<IAlbumLogic, AlbumLogic>();
            services.AddTransient<IArtistLogic, ArtistLogic>();

            services.AddTransient<ITrackRepository, TrackRepository>();
            services.AddTransient<IAlbumRepository, AlbumRepository>();
            services.AddTransient<IArtistRepository, ArtistRepository>();
            services.AddSingleton<MusicLibraryContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
