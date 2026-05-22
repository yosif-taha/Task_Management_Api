
namespace TaskManagement.WebApi
{
    public static class PresentationContainer
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            return services;
        }
        
    }
}
