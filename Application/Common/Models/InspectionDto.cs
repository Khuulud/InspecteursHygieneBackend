namespace Application.Common.Models;

public class InspectionDto
{
    public int Id { get; set; }
    public int EtablissementId { get; set; }
    public string NomEtablissement { get; set; } = string.Empty;
    public string TypeEtablissement { get; set; } = string.Empty;
    public DateTime DateDebut { get; set; }
    public string Statut { get; set; } = string.Empty;
    public decimal? NoteGlobale { get; set; }
}