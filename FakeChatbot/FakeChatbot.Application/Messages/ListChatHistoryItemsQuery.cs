using FakeChatbot.Application.MediatR;
using FakeChatbot.Domain;

namespace FakeChatbot.Application.Messages
{
    public record ListChatHistoryItemsQuery : IQuery<List<ChatHistoryItem>>;
}
