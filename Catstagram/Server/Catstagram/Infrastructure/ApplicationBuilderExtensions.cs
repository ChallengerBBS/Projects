﻿namespace Catstagram.Infrastructure
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    using Catstagram.Data;

    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseSwaggerUI(this IApplicationBuilder app)
           => app.UseSwagger()
                  .UseSwaggerUI(options =>
                       {
                           options.SwaggerEndpoint("/swagger/v1/swagger.json", "My Catstagram API");
                           options.RoutePrefix = string.Empty;
                       });
        

        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            using var services = app.ApplicationServices.CreateScope();

            var dbContext = services.ServiceProvider.GetService<CatstagramDbContext>();

            dbContext.Database.Migrate();
        }
    }
}
