using Lab11_LindaAroni.Application.DTOs.Auth;
using MediatR;

namespace Lab11_LindaAroni.Application.Features.Auth.Commands;

public class LoginCommand : IRequest<AuthResultDto>
{
    public string Username;
    public string Password;
}

