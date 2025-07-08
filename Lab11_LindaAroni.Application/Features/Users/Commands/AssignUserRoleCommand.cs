using MediatR;

namespace Lab11_LindaAroni.Application.Features.Users.Commands;

public record AssignUserRoleCommand : IRequest<bool>
{
    public Guid UserId { get; set; }
    public Guid RoleId { get; set; }

    public AssignUserRoleCommand(Guid userId, Guid roleId)
    {
        UserId = userId;
        RoleId = roleId;
    }
}

