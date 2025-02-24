using FakeChatbot.Application.MediatR;
using FakeChatbot.Database.Repositories;
using FakeChatbot.Domain;

namespace FakeChatbot.Application.Messages
{
    class ProcessMessageCommandHandler : ICommandHandler<ProcessMessageCommand, List<ChatHistoryItem>>
    {
        private readonly IChatHistoryItemRepository _repository;

        public ProcessMessageCommandHandler(IChatHistoryItemRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ChatHistoryItem>> Handle(ProcessMessageCommand request, CancellationToken cancellationToken)
        {
            var userInputHistoryItem = ChatHistoryItem.Create(AuthorEnum.User, request.UserInput);
            var chatbotHistoryItem = ChatHistoryItem.Create(AuthorEnum.Chatbot, "Test");

            var chatHisatoryItems = await _repository.ListAsync(true, cancellationToken);
            
            chatHisatoryItems.Add(userInputHistoryItem);
            chatHisatoryItems.Add(chatbotHistoryItem);
            
            await _repository.SaveChangesAsync(cancellationToken);

            return chatHisatoryItems;
        }
    }
}
