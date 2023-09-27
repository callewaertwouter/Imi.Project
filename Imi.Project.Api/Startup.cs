using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace IMI.Identity;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<RecipesDbContext>(options =>
    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

        services.AddIdentity<User, IdentityRole>(options =>
        {
            // Identity configuration options
            options.Password.RequiredLength = 6;
            // Other Identity options here
        })
        .AddEntityFrameworkStores<RecipesDbContext>()
        .AddDefaultTokenProviders();

        services.AddControllers();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthentication();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
