//using Lab11_LindaAroni.Api.Models;
using Lab11_LindaAroni.Domain.Entities;
using Lab11_LindaAroni.Domain.Interfaces.UnitOfWork;
namespace Lab11_LindaAroni.Application.Services.Auth;

public class UserAuthenticator
{
    private readonly IUnitOfWork _unitOfWork;

    public UserAuthenticator(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<User> AuthenticateAsync(string username, string password)
    {
        var allUsers = await _unitOfWork.Usuarios.GetAllAsync();
        var user = allUsers.FirstOrDefault(u => u.Username == username);

        if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
            return null;

        return user;
    }
}