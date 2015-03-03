using System;
using System.Collections.Generic;
using System.Linq;
using Cookbook.Data;
using Cookbook.Data.Infrastructure;
using Cookbook.Model.Models;
using Cookbook.Data.Repository;

namespace Cookbook.Service
{
    public interface IRecipeIngredientService
    {
        RecipeIngredient GetRecipeIngredient(int recipeId, int ingredientId);
        IEnumerable<RecipeIngredient> GetRecipeIngredientsList(int recipeId);
    }

    public class RecipeIngredientService : IRecipeIngredientService
    {
        private readonly IRecipeIngredientRepository recipeIngredientRepository;
        private readonly IIngredientRepository ingredientRepository;
        private readonly IUnitRepository unitRepository;

        public RecipeIngredientService(IRecipeIngredientRepository recipeIngredientRepository, IIngredientRepository ingredientRepository, IUnitRepository unitRepository)
        {
            this.recipeIngredientRepository = recipeIngredientRepository;
            this.ingredientRepository = ingredientRepository;
            this.unitRepository = unitRepository;
        }

        public RecipeIngredient GetRecipeIngredient(int recipeId, int ingredientId)
        {
            return recipeIngredientRepository.Get(ri => ri.RecipeID == recipeId && ri.IngredientID == ingredientId);
        }

        public IEnumerable<RecipeIngredient> GetRecipeIngredientsList(int recipeId)
        {
            var recipeIngredients = recipeIngredientRepository.GetMany(r => r.RecipeID == recipeId)
                .OrderByDescending(r => r.IngredientID).ToList();
            foreach (var ri in recipeIngredients)
            {
                ri.Ingredient = ingredientRepository.GetById(ri.IngredientID);
                ri.Unit = unitRepository.GetById(ri.UnitID);
            }
            return recipeIngredients;           
        }

    }
}
