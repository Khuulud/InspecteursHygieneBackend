namespace Domaine.Entities;

public class Inspection
{
    public int Id { get; set; }
    public int? PlanningId { get; set; }
    public Planning? Planning { get; set; }
    public int InspecteurId { get; set; }
    public Inspecteur Inspecteur { get; set; } = null!;
    public int EtablissementId { get; set; }
    public Etablissement Etablissement { get; set; } = null!;
    public DateTime DateDebut { get; set; } = DateTime.UtcNow;
    public DateTime? DateFin { get; set; }
    public string Statut { get; set; } = "en_cours";
    public decimal? NoteGlobale { get; set; }
    public string? CommentaireGlobal { get; set; }
    public bool SyncOffline { get; set; } = false;

    public ICollection<EvaluationCritere> Evaluations { get; set; } = new List<EvaluationCritere>();
}