using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cookbook.Web.ViewModels
{
    public class RecipeListViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Instructions { get; set; }

        public int Serves { get; set; }

        public string Preptime { get; set; }

        public string Photo { get; set; }
    }
}