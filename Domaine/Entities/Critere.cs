namespace Domaine.Entities;

public class Critere
{
    public int Id { get; set; }
    public string? TypeEtablissement { get; set; } // null = commun à tous
    public string Categorie { get; set; } = string.Empty; // Milieu, Matériel, Méthode...
    public string Libelle { get; set; } = string.Empty;
    public string? Description { get; set; }
    public int NoteMax { get; set; } = 5;
    public bool Obligatoire { get; set; } = true;
    public bool Actif { get; set; } = true;
}