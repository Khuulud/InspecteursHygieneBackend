using Application.Common.Interfaces;
using Application.Common.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Auth.Commands;

public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ITokenService _tokenService;

    public LoginCommandHandler(IUnitOfWork unitOfWork, ITokenService tokenService)
    {
        _unitOfWork = unitOfWork;
        _tokenService = tokenService;
    }

    public async Task<LoginDto> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var inspecteurs = await _unitOfWork.Inspecteurs.GetAllAsync();
        var inspecteur = inspecteurs
            .FirstOrDefault(i => i.Email == request.Email && i.Actif);

        if (inspecteur == null)
            throw new UnauthorizedAccessException("Email ou mot de passe incorrect.");

        bool passwordValid = BCrypt.Net.BCrypt.Verify(request.Password, inspecteur.MotDePasse);
        if (!passwordValid)
            throw new UnauthorizedAccessException("Email ou mot de passe incorrect.");

        var token = _tokenService.GenerateToken(inspecteur);

        return new LoginDto
        {
            Token = token,
            InspecteurId = inspecteur.Id,
            Nom = inspecteur.Nom,
            Prenom = inspecteur.Prenom,
            Email = inspecteur.Email
        };
    }
}