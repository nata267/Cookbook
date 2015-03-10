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
        private readonly IIngredientService ingredientService;
        private readonly ICategoryService categoryService;
        private readonly IRecipeIngredientService recipeIngredientService;
        private readonly IRecipeCategoryService recipeCategoryService;

        public RecipeController(IRecipeService recipeService, IRatingService ratingService, IRecipeIngredientService recipeIngredientService, IRecipeCategoryService recipeCategoryService
            , IIngredientService ingredientService, ICategoryService categoryService)
        {
            this.recipeService = recipeService;
            this.ratingService = ratingService;
            this.recipeIngredientService = recipeIngredientService;
            this.recipeCategoryService = recipeCategoryService;
            this.ingredientService = ingredientService;
            this.categoryService = categoryService;
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
        public ActionResult RecipeList(int page = 0)
        {
            int[] ingredients = null;
            int[] categories = null;
            string text = null;
            string sortBy = "Name";

            if (Session["search_by_ingredients"] != null)
                ingredients = (int[])Session["search_by_ingredients"];

            if (Session["search_by_categories"] != null)
                categories = (int[])Session["search_by_categories"];

            if (Session["search_by_text"] != null)
                text = (string)Session["search_by_text"];

            var recipes = recipeService.GetRecipesByPage(page, 5, sortBy, ingredients, categories, text).ToList();

            var recipesViewModel = Mapper.Map<IEnumerable<Recipe>, IEnumerable<RecipeListViewModel>>(recipes).ToList();
            var recipesList = new RecipesPageViewModel();
            recipesList.RecipeList = recipesViewModel;

            if (Request.IsAjaxRequest())
            {
                return Json(recipesViewModel, JsonRequestBehavior.AllowGet);
            }
            return View("ListOfRecipes", recipesList);
        }

        public ActionResult Search()
        {
            var recipeSearchModel = new RecipeSearchModel();
            recipeSearchModel.Ingredients = ingredientService.GetAll().ToList();
            recipeSearchModel.Categories = categoryService.GetAll().ToList();
            return View(recipeSearchModel);
        }

        [HttpPost]
        public ActionResult Search(RecipeSearchModel searchModel)
        {
            Session["search_by_ingredients"] = searchModel.SelectedIngredients;
            Session["search_by_categories"] = searchModel.SelectedCategories;
            Session["search_by_text"] = searchModel.InputText;
            return RedirectToAction("RecipeList");
        }
    }
}