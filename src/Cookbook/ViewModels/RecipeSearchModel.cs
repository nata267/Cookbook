using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cookbook.Model.Models;

namespace Cookbook.Web.ViewModels
{
    public class RecipeSearchModel
    {
        public ICollection<Ingredient> Ingredients { get; set; }
        public ICollection<Category> Categories { get; set; }
        public int[] SelectedIngredients { get; set; }
        public int[] SelectedCategories { get; set; }
        public string InputText { get; set; }
    }
}