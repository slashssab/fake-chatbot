using MediatR;

namespace FakeChatbot.Application.MediatR
{
    public interface ICommand<TResponse> : IRequest<TResponse>;
}
