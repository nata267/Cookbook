using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Cookbook.Model.Models
{
    public class Recipe
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Instructions { get; set; }

        public int Serves { get; set; }

        public string Preptime { get; set; }

        public string Photo { get; set; }

        [ForeignKey("Rating")]
        public int RatingID { get; set; }

        public Rating Rating { get; set; }

        public ICollection<RecipeIngredient> RecipeIngredients { get; set; }

        public ICollection<RecipeCategory> RecipeCategories { get; set; }
    }
}
