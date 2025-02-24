using FakeChatbot.Application.MediatR;
using FakeChatbot.Domain;

namespace FakeChatbot.Application.Messages
{
    public record ProcessMessageCommand(string UserInput) : ICommand<List<ChatHistoryItem>>;
}
