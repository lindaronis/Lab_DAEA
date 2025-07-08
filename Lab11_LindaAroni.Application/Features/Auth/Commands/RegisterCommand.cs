using Lab11_LindaAroni.Application.DTOs.Auth;
using MediatR;

namespace Lab11_LindaAroni.Application.Features.Auth.Commands;

public class RegisterCommand : IRequest<AuthResultDto>
{
    public RegisterRequestDto RegisterDto { get; }

    public RegisterCommand(RegisterRequestDto dto)
    {
        RegisterDto = dto;
    }
}

