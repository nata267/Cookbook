using Cookbook.Data.Infrastructure;
using Cookbook.Model.Models;
using System.Collections.Generic;
using System.Linq;
using Cookbook.Data.Repository;
using Cookbook.Data.Models;
using System.Data.Entity;
using System;

namespace Cookbook.Data.Repository
{
    public class RecipeRepository : RepositoryBase<Recipe>, IRecipeRepository
    {
        public RecipeRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {

        }


        public IEnumerable<Recipe> GetRecipesByPage(int currentPage, int noOfRecords, string sortBy, string filterBy)
        {
            var skipRecipes = noOfRecords * currentPage;

            var recipes = this.GetAll();
            recipes = recipes.OrderBy(r => r.Name);

            recipes = recipes.Skip(skipRecipes).Take(noOfRecords);

            return recipes.ToList();
        }
    }

    public interface IRecipeRepository : IRepository<Recipe>
    {
        /// <summary>
        /// /// Method will return recipes as different page with specified number of records ,filter condition and sort criteria
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="currentPage"></param>
        /// <param name="noOfRecords"></param>
        /// <param name="sortBy"></param>
        /// <param name="filterBy"></param>
        /// <returns></returns>
        IEnumerable<Recipe> GetRecipesByPage(int currentPage, int noOfRecords, string sortBy, string filterBy);
    }
}
