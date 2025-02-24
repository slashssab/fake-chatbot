using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace FakeChatbot.Application.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            return services.AddMediatR(Assembly.GetExecutingAssembly());
        }
    }
}
