using Todo.DataAccess;
using Todo.DataAccess.Repository;
using Todo.Domain.Service;

namespace Todo.Api
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServiceDependency (
            this IServiceCollection services)
            {
                services.AddScoped<ITodoService, TodoService>();
                services.AddScoped<ITodoListRepository, TodoListRepository>();
                services.AddTransient<TodoContext>();

                return services;
            }
    }
}