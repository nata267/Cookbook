using System;
using System.Collections.Generic;
using System.Linq;
using Cookbook.Data;
using Cookbook.Data.Infrastructure;
using Cookbook.Model.Models;
using Cookbook.Data.Repository;

namespace Cookbook.Service
{
    public interface IRecipeCategoryService
    {
        IEnumerable<RecipeCategory> GetRecipeCategoriesList(int recipeId);
    }

    public class RecipeCategoryService : IRecipeCategoryService
    {
        private readonly IRecipeCategoryRepository recipeCategoryRepository;
        private readonly ICategoryRepository categoryRepository;

        public RecipeCategoryService(IRecipeCategoryRepository recipeCategoryRepository, ICategoryRepository categoryRepository)
        {
            this.recipeCategoryRepository = recipeCategoryRepository;
            this.categoryRepository = categoryRepository;
        }


        public IEnumerable<RecipeCategory> GetRecipeCategoriesList(int recipeId)
        {
            var recipeCategories = recipeCategoryRepository.GetMany(r => r.RecipeID == recipeId)
                .OrderByDescending(r => r.CategoryID).ToList();
            foreach (var ri in recipeCategories)
            {
                ri.Category = categoryRepository.GetById(ri.CategoryID);
            }
            return recipeCategories;
        }

    }
}
