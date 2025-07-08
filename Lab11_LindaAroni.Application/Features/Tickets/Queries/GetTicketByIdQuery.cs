namespace Lab11_LindaAroni.Application.DTOs.Tickets;
using MediatR;

public record GetTicketByIdQuery(Guid TicketId) : IRequest<TicketDto>;


