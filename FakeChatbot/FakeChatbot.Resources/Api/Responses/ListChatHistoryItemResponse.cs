using FakeChatbot.Domain;

namespace FakeChatbot.Resources.Api.Responses
{
    public record ListChatHistoryItemResponse(Guid Id, AuthorEnum Author, string Text, MessageMarkEnum? Mark, DateTime Timestamp);
}
