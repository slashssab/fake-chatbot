using MediatR;

namespace FakeChatbot.Application.MediatR
{
    public interface IQuery<TResponse> : IRequest<TResponse>;
}
