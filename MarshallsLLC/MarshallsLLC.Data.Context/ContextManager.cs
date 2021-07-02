using MarshallsLLC.Data.Context.Interfaces;

namespace MarshallsLLC.Data.Context
{
    public class ContextManager<TContext> : IContextManager<TContext> where TContext : IDbContext, new()
    {
        private readonly string ContextKey;
        public ContextManager()
        {
            ContextKey = "ContextKey." + typeof(TContext).Name;
        }
        public IDbContext GetContext()
        {
            return null as IDbContext;
        }
        public void Finish() { }
    }
}
