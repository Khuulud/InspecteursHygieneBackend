using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Common.Interfaces;

public interface IUnitOfWork : IDisposable
{
    // Retourne le repository générique pour n'importe quelle entité
    IGenericRepository<T> Repository<T>() where T : class;

    // Sauvegarder les changements dans la base
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    // Gestion des transactions
    Task BeginTransactionAsync();
    Task CommitTransactionAsync();
    Task RollbackTransactionAsync();

    // Libération des ressources
    void Dispose();
}