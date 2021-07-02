namespace MarshallsLLC.Data.Context.Interfaces
{
    public interface IContextManager<TContext> where TContext : new()
    {
        IDbContext GetContext();
        void Finish();
    }
}
