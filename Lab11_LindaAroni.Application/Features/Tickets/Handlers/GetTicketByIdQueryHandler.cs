using Lab11_LindaAroni.Application.DTOs.Tickets;
using Lab11_LindaAroni.Domain.Interfaces.UnitOfWork;
using MediatR;

namespace Lab11_LindaAroni.Application.Features.Tickets.Handlers;

internal class GetTicketByIdQueryHandler : IRequestHandler<GetTicketByIdQuery, TicketDto>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetTicketByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<TicketDto> Handle(GetTicketByIdQuery request, CancellationToken cancellationToken)
    {
        var ticket = await _unitOfWork.Tickets.GetByIdAsync(request.TicketId);
        if (ticket == null) return null;
        return new TicketDto(ticket);
    }
}

