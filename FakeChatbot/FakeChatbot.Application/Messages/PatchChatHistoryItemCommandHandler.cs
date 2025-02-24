using FakeChatbot.Application.MediatR;
using FakeChatbot.Database.Repositories;
using FakeChatbot.Domain;
using FakeChatbot.Resources.Api.Exceptions;

namespace FakeChatbot.Application.Messages
{
    class PatchChatHistoryItemCommandHandler : ICommandHandler<PatchChatHistoryItemCommand, List<ChatHistoryItem>>
    {
        private readonly IChatHistoryItemRepository _repository;

        public PatchChatHistoryItemCommandHandler(IChatHistoryItemRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ChatHistoryItem>> Handle(PatchChatHistoryItemCommand request, CancellationToken cancellationToken)
        {
            var chatHistoryItem = await _repository.GetForUpdateByIdAsync(request.Id, cancellationToken);

            if(chatHistoryItem is null)
            {
                throw new NotFoundException($"Cannot find item with id {request.Id}.");
            }

            chatHistoryItem.UpdateMark(request.Mark);
            await _repository.SaveChangesAsync(cancellationToken);

            return await _repository.ListAsync(cancellationToken: cancellationToken);
        }
    }
}
