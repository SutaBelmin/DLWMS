using Microsoft.Extensions.DependencyInjection;

namespace DLWMS_StudentskiOnlineServis.Services
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IForumService, ForumService>();
            services.AddScoped<IGreskaService, GreskaService>();
            services.AddScoped<IPotvrdaService, PotvrdaService>();
            services.AddScoped<IUspjehService, UspjehService>();
            services.AddScoped<IProfesor_PredmetService, Profesor_PredmetService>();
            services.AddScoped<IStudent_PredmetService, Student_PredmetService>();
            services.AddScoped<IImageService, ImageService>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IPredmetService, PredmetService>();
            services.AddScoped<IErrorService, ErrorService>();

            return services;
        }
    }
}
