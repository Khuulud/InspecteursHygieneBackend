namespace Domaine.Entities;

public class EvaluationCritere
{
    public int Id { get; set; }
    public int InspectionId { get; set; }
    public Inspection Inspection { get; set; } = null!;
    public int CritereId { get; set; }
    public Critere Critere { get; set; } = null!;
    public int Note { get; set; }
    public string? Commentaire { get; set; }
    public bool AnomalieDetectee { get; set; } = false;
    public string? PhotoFirebaseUrl { get; set; }
}