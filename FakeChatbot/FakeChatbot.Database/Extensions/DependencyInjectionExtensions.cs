using FakeChatbot.Database.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FakeChatbot.Database.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddFakeChatbotDatabase(this IServiceCollection services)
        {
            services.AddDbContext<FakeChatbotDbContext>(opt =>
            {
                opt.UseInMemoryDatabase("FakeChatbotDb");
            });

            services.AddSingleton<IChatHistoryItemRepository, ChatHistoryItemRepository>();

            return services;
        }
    }
}
