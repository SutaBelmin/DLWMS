using Microsoft.Extensions.DependencyInjection;

namespace DLWMS_StudentskiOnlineServis.Repositories
{
    public static class RepositoryExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IForumRepository, ForumRepository>();

            return services;
        }
    }
}
