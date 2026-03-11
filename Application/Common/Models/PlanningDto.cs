namespace Application.Common.Models;

public class PlanningDto
{
    public int Id { get; set; }
    public int EtablissementId { get; set; }
    public string NomEtablissement { get; set; } = string.Empty;
    public string TypeEtablissement { get; set; } = string.Empty;
    public string Adresse { get; set; } = string.Empty;
    public string Ville { get; set; } = string.Empty;
    public DateTime DatePrevue { get; set; }
    public string Statut { get; set; } = string.Empty;
}