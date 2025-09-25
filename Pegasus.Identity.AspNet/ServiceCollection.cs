using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Pegasus.Identity.Data;

namespace Pegasus.Identity.AspNet;

public static class ServiceCollection {
    public static IServiceCollection AddIdentityServices(this IServiceCollection services, string connectionString) {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlite(connectionString, builder => builder.MigrationsAssembly("Pegasus.Identity")));
        services.AddDatabaseDeveloperPageExceptionFilter();
        
        services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();
        
        services.AddScoped<SignInManager<ApplicationUser>>();
        
        return services;
    }
}