using FakeChatbot.Domain;

namespace FakeChatbot.Resources.Api.Requests
{
    public record PatchChatHistoryItemRequest(MessageMarkEnum mark);
}
