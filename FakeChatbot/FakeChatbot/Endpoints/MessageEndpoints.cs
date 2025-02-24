using FakeChatbot.Application.Messages;
using FakeChatbot.Resources.Api.Requests;
using FakeChatbot.Resources.Api.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FakeChatbot.Endpoints
{
    public static class MessageEndpoints
    {
        public static void MapMessageEndpoints(this IEndpointRouteBuilder endpointRouteBuilder)
        {
            endpointRouteBuilder.MapGet("api/messages", async (ISender sender) =>
            {
                var response = await sender.Send(new ListChatHistoryItemsQuery());

                return Results.Ok(response.Select(x => new ListChatHistoryItemResponse(x.Id, x.Author, x.Text, x.Mark, DateTime.Now)));
            });

            endpointRouteBuilder.MapPost("api/messages", async ([FromBody]ProcessMessageRequest request, ISender sender) => 
            {
                var response = await sender.Send(new ProcessMessageCommand(request.UserInput));

                return Results.Ok(response.Select(x => new ListChatHistoryItemResponse(x.Id, x.Author, x.Text, x.Mark, DateTime.Now)));
            });

            endpointRouteBuilder.MapPatch("api/messages/{id}",async ([FromBody] PatchChatHistoryItemRequest request, string id, ISender sender) =>
            {
                var response = await sender.Send(new PatchChatHistoryItemCommand(Guid.Parse(id), request.mark));

                return Results.Ok(response.Select(x => new ListChatHistoryItemResponse(x.Id, x.Author, x.Text, x.Mark, DateTime.Now)));
            });
        }
    }
}
