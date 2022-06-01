using Microsoft.Extensions.DependencyInjection;

namespace DLWMS_StudentskiOnlineServis.Repositories
{
    public static class RepositoryExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IForumRepository, ForumRepository>();
            services.AddScoped<IGreskaRepository, GreskaRepository>();
            services.AddScoped<IPotvrdaRepository, PotvrdaRepository>();
            services.AddScoped<IUspjehRepository, UspjehRepository>();
            services.AddScoped<IPredmetRepository, PredmetRepository>();
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IProfesor_PredmetRepository, Profesor_PredmetRepository>();
            services.AddScoped<IStudent_PredmetRepository, Student_PredmetRepository>();
            services.AddScoped<IErrorRepository, ErrorRepository>();
            services.AddScoped<IAutentifikacijaTokenRepository, AutentifikacijaTokenRepository>();

            return services;
        }
    }
}
