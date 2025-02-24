using FakeChatbot.Application.MediatR;
using FakeChatbot.Database.Repositories;
using FakeChatbot.Domain;

namespace FakeChatbot.Application.Messages
{
    class ListChatHistoryItemsQueryHandler : IQueryHandler<ListChatHistoryItemsQuery, List<ChatHistoryItem>>
    {
        private readonly IChatHistoryItemRepository _repository;

        public ListChatHistoryItemsQueryHandler(IChatHistoryItemRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ChatHistoryItem>> Handle(ListChatHistoryItemsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.ListAsync(cancellationToken: cancellationToken);
        }
    }
}
