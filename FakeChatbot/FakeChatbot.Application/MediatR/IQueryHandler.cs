using MediatR;

namespace FakeChatbot.Application.MediatR
{
    interface IQueryHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
        where TRequest: IQuery<TResponse>;
}
