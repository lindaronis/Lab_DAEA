using Lab11_LindaAroni.Application.DTOs.Tickets;
using Lab11_LindaAroni.Application.Features.Tickets.Queries;
using Lab11_LindaAroni.Domain.Interfaces.UnitOfWork;
using MediatR;

namespace Lab11_LindaAroni.Application.Features.Tickets.Handlers;

internal class GetAllTicketsQueryHandler : IRequestHandler<GetAllTicketsQuery, IEnumerable<TicketDto>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllTicketsQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<TicketDto>> Handle(GetAllTicketsQuery request, CancellationToken cancellationToken)
    {
        var tickets = await _unitOfWork.Tickets.GetAllAsync();
        return tickets.Select(t => new TicketDto(t)).ToList();
    }
}

