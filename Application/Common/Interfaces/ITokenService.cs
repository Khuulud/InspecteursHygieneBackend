using Domaine.Entities;

namespace Application.Common.Interfaces;

public interface ITokenService
{
    string GenerateToken(Inspecteur inspecteur);
}