namespace Catstagram
{
    using Catstagram.Data;
    using Catstagram.Infrastructure;
    
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Hosting;

    public class Startup
    {
        public Startup(IConfiguration configuration)
       => Configuration = configuration;

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        => services
                .AddDbContext<CatstagramDbContext>(options => options
                .UseSqlServer( this.Configuration.GetDefaultConnectionString()))
                .AddIdentity()
                .AddJwtAuthentication(services.GetApplicationSettings(this.Configuration))
                .AddControllers();

        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app 
              .UseRouting()
              .UseCors(options => options
              .AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader())
              .UseAuthentication()
              .UseAuthorization()
              .UseEndpoints(endpoints =>
              {
                  endpoints.MapControllers();
              })
              .ApplyMigrations();
        }
    }
}
