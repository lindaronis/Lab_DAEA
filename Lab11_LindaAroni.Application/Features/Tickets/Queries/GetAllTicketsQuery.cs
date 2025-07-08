using Lab11_LindaAroni.Application.DTOs.Tickets;
using Lab11_LindaAroni.Application.DTOs.Tickets;
using MediatR;

namespace Lab11_LindaAroni.Application.Features.Tickets.Queries;

public class GetAllTicketsQuery : IRequest<IEnumerable<TicketDto>>;

