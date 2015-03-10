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


        public IEnumerable<Recipe> GetRecipesByPage(int currentPage, int noOfRecords, string sortBy, int[] ingredients, int[] categories, string text)
        {
            var skipRecipes = noOfRecords * currentPage;

            var recipes = this.GetAll();

            if (ingredients != null)
            {
                foreach(int ingredient in ingredients)
                   recipes = (from r in recipes
                               join ri in this.DataContext.RecipeIngredients on r.Id equals ri.RecipeID
                              where ri.IngredientID == ingredient
                              select r).Distinct();
            }

            if (categories != null)
            {
                foreach (int category in categories)
                    recipes = (from r in recipes
                               join rc in this.DataContext.RecipeCategories on r.Id equals rc.RecipeID
                               where rc.CategoryID == category
                               select r).Distinct();
            }

            if (text != null)
            {
                recipes = from r in recipes
                          where r.Name.ToLower().Contains(text.ToLower())
                          || r.Instructions.ToLower().Contains(text.ToLower())
                           select r;
            }

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
        IEnumerable<Recipe> GetRecipesByPage(int currentPage, int noOfRecords, string sortBy, int[] ingredients, int[] categories, string text);
    }
}
