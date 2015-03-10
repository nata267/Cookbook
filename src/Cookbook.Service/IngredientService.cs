using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cookbook.Data;
using Cookbook.Data.Infrastructure;
using Cookbook.Model.Models;
using Cookbook.Data.Repository;

namespace Cookbook.Service
{
    public interface IIngredientService
    {
        IEnumerable<Ingredient> GetAll();
    }

    public class IngredientService : IIngredientService
    {
        private readonly IIngredientRepository ingredientRepository;

        public IngredientService(IIngredientRepository ingredientRepository)
        {
            this.ingredientRepository = ingredientRepository;
        }

        #region IIngredientService Members

        public IEnumerable<Ingredient> GetAll()
        {
            var ingredients = ingredientRepository.GetAll().OrderBy(i => i.Name);
            return ingredients;
        }

        #endregion
    }
}
