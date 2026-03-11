using Domaine.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    public DbSet<Inspecteur> Inspecteurs => Set<Inspecteur>();
    public DbSet<Etablissement> Etablissements => Set<Etablissement>();
    public DbSet<Planning> Plannings => Set<Planning>();
    public DbSet<Inspection> Inspections => Set<Inspection>();
    public DbSet<Critere> Criteres => Set<Critere>();
    public DbSet<EvaluationCritere> EvaluationCriteres => Set<EvaluationCritere>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Inspecteur
        modelBuilder.Entity<Inspecteur>(e => {
            e.HasKey(i => i.Id);
            e.Property(i => i.Email).IsRequired().HasMaxLength(200);
            e.HasIndex(i => i.Email).IsUnique();
            e.Property(i => i.Nom).IsRequired().HasMaxLength(100);
            e.Property(i => i.Prenom).IsRequired().HasMaxLength(100);
            e.Property(i => i.MotDePasse).IsRequired();
        });

        // Etablissement
        modelBuilder.Entity<Etablissement>(e => {
            e.HasKey(x => x.Id);
            e.Property(x => x.Nom).IsRequired().HasMaxLength(200);
            e.Property(x => x.TypeEtablissement).IsRequired().HasMaxLength(100);
            e.HasIndex(x => x.QrCode).IsUnique();
        });

        // Planning
        modelBuilder.Entity<Planning>(e => {
            e.HasKey(x => x.Id);
            e.HasOne(x => x.Inspecteur)
             .WithMany(i => i.Plannings)
             .HasForeignKey(x => x.InspecteurId)
             .OnDelete(DeleteBehavior.Restrict);
            e.HasOne(x => x.Etablissement)
             .WithMany(et => et.Plannings)
             .HasForeignKey(x => x.EtablissementId)
             .OnDelete(DeleteBehavior.Restrict);
        });

        // Inspection
        modelBuilder.Entity<Inspection>(e => {
            e.HasKey(x => x.Id);
            e.Property(x => x.NoteGlobale).HasColumnType("decimal(5,2)");
            e.HasOne(x => x.Inspecteur)
             .WithMany(i => i.Inspections)
             .HasForeignKey(x => x.InspecteurId)
             .OnDelete(DeleteBehavior.Restrict);
            e.HasOne(x => x.Etablissement)
             .WithMany(et => et.Inspections)
             .HasForeignKey(x => x.EtablissementId)
             .OnDelete(DeleteBehavior.Restrict);
        });

        // EvaluationCritere
        modelBuilder.Entity<EvaluationCritere>(e => {
            e.HasKey(x => x.Id);
            e.HasOne(x => x.Inspection)
             .WithMany(i => i.Evaluations)
             .HasForeignKey(x => x.InspectionId)
             .OnDelete(DeleteBehavior.Cascade);
            e.HasOne(x => x.Critere)
             .WithMany()
             .HasForeignKey(x => x.CritereId)
             .OnDelete(DeleteBehavior.Restrict);
        });
    }
} 