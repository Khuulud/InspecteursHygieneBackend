namespace Application.Common.Models;

public class LoginDto
{
    public string Token { get; set; } = string.Empty;
    public int InspecteurId { get; set; }
    public string Nom { get; set; } = string.Empty;
    public string Prenom { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}