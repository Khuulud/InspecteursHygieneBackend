using Application.Common.Models;
using MediatR;

namespace Application.Auth.Commands;

//implémentation de l’interface IRequest de MediatR//
public class LoginCommand : IRequest<LoginDto>
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}