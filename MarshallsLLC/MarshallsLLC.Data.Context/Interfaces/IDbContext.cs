using Microsoft.EntityFrameworkCore;

namespace MarshallsLLC.Data.Context.Interfaces
{
    public interface IDbContext
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        int SaveChanges();
        void Dispose();
        int? CurrentUserId { get; }
    }
}
