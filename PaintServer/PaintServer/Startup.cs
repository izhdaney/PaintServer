using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PaintServer.DAL;
using PaintServer.Services;
using PaintServer.Middleware;

namespace PaintServer
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
            services.AddTransient<IAutorizationService, AutorizationService>();
            services.AddTransient<IRegistrationService, RegistrationService>();
            services.AddTransient<ISaveImageService, SaveImageService>();
            services.AddTransient<ILoadImageService, LoadImageService>();
            services.AddTransient<IDeleteImageService, DeleteImageService>();
            services.AddTransient<IGetFileListService, GetFilesListService>();
            services.AddTransient<IStatisticService, StatisticService>();

            services.AddTransient<IAutorizationDAL, AutorizationDALmsSQL>();
            services.AddTransient<IOperationDAL, OperationDALmsSQL>();
            services.AddTransient<IStatisticDAL, StatisticDALmsSQL>();


            services.AddControllers();
            services.Configure<MyConfiguration>(Configuration.GetSection("ConnectionStrings"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();

            

            app.UseRouting();

            app.UseAuthorization();

            //app.UseMiddleware<PaintServerExceptionMiddleware>();

            //app.UseExceptionHandler

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
