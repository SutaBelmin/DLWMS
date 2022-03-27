using Microsoft.Extensions.DependencyInjection;

namespace DLWMS_StudentskiOnlineServis.Services
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IForumService, ForumService>();

            return services;
        }
    }
}
