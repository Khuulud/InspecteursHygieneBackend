namespace Domaine.Entities;

public class Inspecteur
{
    public int Id { get; set; }
    public string Nom { get; set; } = string.Empty;
    public string Prenom { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string MotDePasse { get; set; } = string.Empty;
    public string? Telephone { get; set; }
    public bool Actif { get; set; } = true;
    public DateTime DateCreation { get; set; } = DateTime.UtcNow;

    public ICollection<Planning> Plannings { get; set; } = new List<Planning>();
    public ICollection<Inspection> Inspections { get; set; } = new List<Inspection>();
}