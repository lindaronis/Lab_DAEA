using Lab11_LindaAroni.Application.Features.Tickets.Commands;
using Lab11_LindaAroni.Domain.Interfaces.UnitOfWork;
using MediatR;

namespace Lab11_LindaAroni.Application.Features.Tickets.Handlers;

internal class UpdateTicketStatusHandler : IRequestHandler<UpdateTicketStatusCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateTicketStatusHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(UpdateTicketStatusCommand request, CancellationToken cancellationToken)
    {
        var ticket = await _unitOfWork.Tickets.GetByIdAsync(request.TicketId);
        if (ticket == null) return false;

        ticket.Status = request.Status;
        await _unitOfWork.SaveAsync();

        return true;
    }
}


