using System.Reflection;
using E_Association.Service.UnitOfWorks;
using Microsoft.Extensions.DependencyInjection;

namespace E_Association.Core
{
    public static class CoreServices
    {
        public static void  AddCoreServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(CoreServices).Assembly);
            services.AddMediatR(mediator => mediator.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        }
    }
}
