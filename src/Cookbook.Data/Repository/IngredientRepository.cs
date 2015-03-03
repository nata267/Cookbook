using System;
using System.Collections.Generic;
using System.Linq;
using Cookbook.Data.Repository;
using Cookbook.Data.Models;
using Cookbook.Data.Infrastructure;
using Cookbook.Model.Models;

namespace Cookbook.Data.Repository
{
    public class IngredientRepository : RepositoryBase<Ingredient>, IIngredientRepository
    {
        public IngredientRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {

        }
    }

    public interface IIngredientRepository : IRepository<Ingredient>
    {
    }
}
