using FakeChatbot.Domain;

namespace FakeChatbot.Database.Repositories
{
    public interface IChatHistoryItemRepository
    {
        Task<ChatHistoryItem?> GetForUpdateByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<List<ChatHistoryItem>> ListAsync(bool asTracking = false, CancellationToken cancellationToken = default);
        Task AddHistoryItemAsync(ChatHistoryItem item, CancellationToken cancellationToken = default);
        Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
