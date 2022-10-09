using Todo.Domain.Service;

namespace Todo.Api
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServiceDependency (
            this IServiceCollection services)
            {
                services.AddScoped<ITodoService, TodoService>();

                return services;
            }
    }
}