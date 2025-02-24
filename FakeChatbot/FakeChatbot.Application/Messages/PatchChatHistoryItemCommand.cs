using FakeChatbot.Application.MediatR;
using FakeChatbot.Domain;

namespace FakeChatbot.Application.Messages
{
    public record PatchChatHistoryItemCommand(Guid Id, MessageMarkEnum Mark) : ICommand<List<ChatHistoryItem>>;
}
