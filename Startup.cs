using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using WebApiAutores.Middleware;
using WebApiAutores.services;

namespace WebApiAutores {
    public class Startup {
        public Startup( IConfiguration configuration ) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices( IServiceCollection services ) {
            services.AddControllers().AddJsonOptions(
                x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles // evitar ciclos en relaciones
            );

            services.AddDbContext<ApplicationDbContext>( 
                options => options.UseSqlServer(
                    Configuration.GetConnectionString("defaultConnection")
                )
            );

            // inyección de dependencias
            services.AddTransient<IService, ServiceA>();
            services.AddTransient<ServiceTrasient>();
            services.AddScoped<ServiceScoped>();
            services.AddSingleton<ServiceSingleton>();
            // services.AddScoped<ServiceA>(); // addscoped crea una instancia por solicitud
            // services.AddSingleton<IService, ServiceA>(); // crear siempre diferentes instancias

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }

        public void Configure( IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger ) {

            // app.UseMiddleware<LoggerResponseMiddleware>();
            app.UseLoggerResponseMiddleware();
            
            /* app.Map("ruta", app => {
                 app.Run(async context => {
                    await context.Response.WriteAsync("paré");
                });
            }); */
           
            if (env.IsDevelopment()) {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });
        }
    }
}