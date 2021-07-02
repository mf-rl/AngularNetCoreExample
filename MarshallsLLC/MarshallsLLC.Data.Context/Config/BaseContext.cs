using Microsoft.EntityFrameworkCore;

namespace MarshallsLLC.Data.Context.Config
{
    public class BaseContext : DbContext
    {
        public BaseContext(DbContextOptions<BaseContext> options) : base(options) { }
        public new DbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }
        public int? CurrentUserId { get; private set; }
    }
}