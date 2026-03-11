namespace Domaine.Entities;

public class Planning
{
    public int Id { get; set; }
    public int InspecteurId { get; set; }
    public Inspecteur Inspecteur { get; set; } = null!;
    public int EtablissementId { get; set; }
    public Etablissement Etablissement { get; set; } = null!;
    public DateTime DatePrevue { get; set; }
    public string Statut { get; set; } = "planifiee";
    public string? NotesAdmin { get; set; }
    public DateTime DateCreation { get; set; } = DateTime.UtcNow;
}