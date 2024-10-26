using PavelVasilevKT_31_21.Interfaces;
using PavelVasilevKT_31_21.Services;

namespace PavelVasilevKT_31_21.ServiceExtensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ITeacherService, TeacherService>();
            services.AddScoped<IDisciplineService, DisciplineService>();
            services.AddScoped<ILoadService, LoadService>();

            return services;
        }
    }
}
