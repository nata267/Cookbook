using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Cookbook.Model.Models
{
    public class RecipeCategory
    {
        public Recipe Recipe { get; set; }

        public Category Category { get; set; }

        [Key, Column(Order = 1)]
        public int RecipeID { get; set; }

        [Key, Column(Order = 2)]
        public int CategoryID { get; set; }
    }
}
