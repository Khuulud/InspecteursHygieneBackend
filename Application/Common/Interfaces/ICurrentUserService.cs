namespace Application.Common.Interfaces;
public interface ICurrentUserService
{
    int? InspecteurId { get; }
    string? Email { get; }
}
