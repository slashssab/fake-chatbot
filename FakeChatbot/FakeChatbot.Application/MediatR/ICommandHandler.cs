using MediatR;

namespace FakeChatbot.Application.MediatR
{
    public interface ICommandHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
        where TRequest : ICommand<TResponse>;
}
