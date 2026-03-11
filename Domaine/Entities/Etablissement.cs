namespace Domaine.Entities;

public class Etablissement
{
    public int Id { get; set; }
    public string Nom { get; set; } = string.Empty;
    public string Adresse { get; set; } = string.Empty;
    public string Ville { get; set; } = string.Empty;
    public string TypeEtablissement { get; set; } = string.Empty;
    public string? Telephone { get; set; }
    public string? ResponsableNom { get; set; }
    public string? QrCode { get; set; }
    public bool Actif { get; set; } = true;
    public DateTime DateInscription { get; set; } = DateTime.UtcNow;

    public ICollection<Planning> Plannings { get; set; } = new List<Planning>();
    public ICollection<Inspection> Inspections { get; set; } = new List<Inspection>();
}
