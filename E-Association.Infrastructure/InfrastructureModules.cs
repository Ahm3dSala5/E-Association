using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
namespace E_Association.Infrastructure
{
    public static class InfrastructureModules
    {
        public static void AddInfrastructureModules(this IServiceCollection service)
        {

        }
        public static void AddPasswordConfigurations(this IServiceCollection services)
        {
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
            });
        }
    }
}
