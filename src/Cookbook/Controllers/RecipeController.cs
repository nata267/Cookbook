using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cookbook.Service;
using Cookbook.Model.Models;
using Cookbook.Web.ViewModels;
using AutoMapper;

namespace Cookbook.Web.Controllers
{
    public class RecipeController : Controller
    {
        private readonly IRecipeService recipeService;
        private readonly IRatingService ratingService;
        private readonly IRecipeIngredientService recipeIngredientService;
        private readonly IRecipeCategoryService recipeCategoryService;

        public RecipeController(IRecipeService recipeService, IRatingService ratingService, IRecipeIngredientService recipeIngredientService, IRecipeCategoryService recipeCategoryService)
        {
            this.recipeService = recipeService;
            this.ratingService = ratingService;
            this.recipeIngredientService = recipeIngredientService;
            this.recipeCategoryService = recipeCategoryService;
        }

        public ActionResult Index(int id)
        {
            var recipe = recipeService.GetRecipe(id);
            if (recipe == null)
            {
                return HttpNotFound();
            }
            var recipeDetails = Mapper.Map<Recipe, RecipeViewModel>(recipe);
            recipeDetails.Rating = ratingService.GetRating(recipe.RatingID);
            recipeDetails.RecipeIngredients = recipeIngredientService.GetRecipeIngredientsList(recipe.Id).ToList();
            recipeDetails.RecipeCategories = recipeCategoryService.GetRecipeCategoriesList(recipe.Id).ToList();
            return View(recipeDetails);
        }
        /// <summary>
        /// Action to load recipe list
        /// </summary>
        /// <param name="sortBy"></param>
        /// <param name="filterBy"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        /// 
        public ActionResult RecipeList(string sortBy = "Date", string filterBy = "All", int page = 0)
        {
            var recipes = recipeService.GetRecipesByPage(page, 5, sortBy, filterBy).ToList();

            var recipesViewModel = Mapper.Map<IEnumerable<Recipe>, IEnumerable<RecipeListViewModel>>(recipes).ToList();
            var recipesList = new RecipesPageViewModel(filterBy, sortBy);
            recipesList.RecipeList = recipesViewModel;

            if (Request.IsAjaxRequest())
            {
                return Json(recipesViewModel, JsonRequestBehavior.AllowGet);
            }
            return View("ListOfRecipes", recipesList);
        }
    }
}