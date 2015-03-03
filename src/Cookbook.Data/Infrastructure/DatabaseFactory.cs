using Cookbook.Data.Models;

namespace Cookbook.Data.Infrastructure
{
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        private CookbookEntities dataContext;
        public CookbookEntities Get()
        {
            return dataContext ?? (dataContext = new CookbookEntities());
        }
        protected override void DisposeCore()
        {
            if (dataContext != null)
                dataContext.Dispose();
        }
    }
}
