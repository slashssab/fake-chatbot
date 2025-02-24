using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace FakeChatbot.Database
{
    public class FakeChatbotDbContext : DbContext
    {
        public FakeChatbotDbContext(DbContextOptions<FakeChatbotDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }
    }
}
