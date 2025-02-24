using FakeChatbot.Domain;
using Microsoft.EntityFrameworkCore;

namespace FakeChatbot.Database.Repositories
{
    public class ChatHistoryItemRepository : IChatHistoryItemRepository
    {
        private readonly FakeChatbotDbContext _dbContext;
        private DbSet<ChatHistoryItem> _dbSet => _dbContext.Set<ChatHistoryItem>();

        public ChatHistoryItemRepository(FakeChatbotDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddHistoryItemAsync(ChatHistoryItem item, CancellationToken cancellationToken = default)
        {
            await _dbSet.AddAsync(item, cancellationToken);
        }

        public async Task<ChatHistoryItem?> GetForUpdateByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _dbSet
                .AsTracking()
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<ChatHistoryItem>> ListAsync(bool asTracking = false, CancellationToken cancellationToken = default)
        {
            return asTracking
                ? await _dbSet
                .AsTracking()
                .ToListAsync(cancellationToken)
                : await _dbSet
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }
    }
}
