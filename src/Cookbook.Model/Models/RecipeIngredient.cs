using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Cookbook.Model.Models
{
    public class RecipeIngredient
    {
        public Recipe Recipe { get; set; }

        public Ingredient Ingredient { get; set; }

        [Key, Column(Order = 1)]
        public int RecipeID { get; set; }

        [Key, Column(Order = 2)]
        public int IngredientID { get; set; }

        [ForeignKey("Unit")]
        public int UnitID { get; set; }

        public Unit Unit { get; set; }

        public int Quantity { get; set; }
    }
}
