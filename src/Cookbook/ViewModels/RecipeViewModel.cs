using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cookbook.Model.Models;

namespace Cookbook.Web.ViewModels
{
    public class RecipeViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Instructions { get; set; }

        public int Serves { get; set; }

        public string Preptime { get; set; }

        public string Photo { get; set; }

        public int RatingID { get; set; }

        public Rating Rating { get; set; }

        public ICollection<RecipeIngredient> RecipeIngredients { get; set; }

        public ICollection<RecipeCategory> RecipeCategories { get; set; }
    }
}