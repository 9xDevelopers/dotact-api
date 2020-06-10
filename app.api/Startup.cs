using app.api.Extensions;
using app.core.Models;
using app.infrastructure.Models;
using app.root;
using app.signalR.Hubs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

[assembly: ApiController]

namespace app.api
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
            // Configure CORS
            services.ConfigureCors();
            
            // Configure SignalR
            services.AddSignalR();
            services.AddIdentity<AppUser, AppRole>()
                .AddEntityFrameworkStores<AppDbContext>();

            // Configurate Database
            CompositionRoot.injectDependencies(services, Configuration);
            // services.ConfigurateDatabase(Configuration);


            // Configure AutoMapper
            services.ConfigureAutoMapper();

            services.AddControllers();

            // Configurate TokenAuthentication
            services.ConfigureJwtAuthentication(Configuration);

            // Configure Swagger
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo {Title = "API", Version = "v1"}); });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Configure CORS
            app.UseCors("ApiCorsPolicy");


            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1"); });
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            // Middleware Custom Exception
            app.UseCustomExceptionMiddleware();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                // Add SignalR EndPoint
                endpoints.MapHub<ChatHub>("/chatHub");
            });
        }
    }
}