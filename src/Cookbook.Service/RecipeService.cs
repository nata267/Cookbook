using System;
using System.Collections.Generic;
using System.Linq;
using Cookbook.Data;
using Cookbook.Data.Infrastructure;
using Cookbook.Model.Models;
//using Cookbook.Core.Common;
//using Cookbook.Service.Properties;
using Cookbook.Data.Repository;

namespace Cookbook.Service
{
    public interface IRecipeService
    {
        Recipe GetRecipe(int id);

        /*IEnumerable<Goal> GetGoals();
        IEnumerable<Goal> GetGoalByDefault(string userid);
        IEnumerable<Goal> GetGoals(string userid);
        IEnumerable<Goal> GetGoalsbyPopularity(string userid);
        IEnumerable<Goal> GetGoalsofFollowingByPopularity(string userid);
        IEnumerable<Goal> GetPublicGoalsbyPopularity();
        IEnumerable<Goal> GetGoalsofFollowing(string userid);
        Goal GetLastCreatedGoal(string userid);
        IEnumerable<Goal> GetTop20GoalsofFollowing(string userid);
        IEnumerable<Goal> GetTop20Goals(string userid);
        IEnumerable<Goal> GetMyGoals(string userid);
        IEnumerable<ValidationResult> CanAddGoal(Goal newGoal,IUpdateService updateService);*/       
        /*void CreateGoal(Goal goal);
        void EditGoal(Goal goalToEdit);
        void DeleteGoal(int id);
        void SaveGoal();
        IEnumerable<Goal> SearchGoal(string goal);*/

        IEnumerable<Recipe> GetRecipesByPage(int currentPage, int noOfRecords, string sortBy, int[] ingredients, int[] categories, string text);
    }

    public class RecipeService : IRecipeService
    {
        private readonly IRecipeRepository recipeRepository;

        public RecipeService(IRecipeRepository recipeRepository)
        {
            this.recipeRepository = recipeRepository;
        }
        
        #region IGoalService Members

        /*public IEnumerable<Goal> GetGoals()
        {
            var goal = goalRepository.GetMany(g => g.GoalType == false).OrderByDescending(g => g.CreatedDate);
            return goal;
        }

        public IEnumerable<Goal> GetGoalByDefault(string userid)
        {
            var goal = goalRepository.GetMany(g => (g.UserId == userid && g.GoalType == false)).OrderByDescending(g => g.CreatedDate);
            return goal;
        }

        public IEnumerable<Goal> GetGoalsofFollowing(string userid)
        {
            var goals = (from g in goalRepository.GetMany(g => g.GoalType == false) where (from f in followUserrepository.GetMany(fol => fol.FromUserId == userid) select f.ToUserId).ToList().Contains(g.UserId) select g).OrderByDescending(g => g.CreatedDate);
            return goals;
        }
        public IEnumerable<Goal> GetGoalsofFollowingByPopularity(string userid)
        {
            var goals = (from g in goalRepository.GetMany(g => g.GoalType == false) where (from f in followUserrepository.GetMany(fol => fol.FromUserId == userid) select f.ToUserId).ToList().Contains(g.UserId) select g).OrderByDescending(g => g.Supports.Count());
            return goals;
        }


        public IEnumerable<Goal> GetPublicGoalsbyPopularity()
        {
            var goals = goalRepository.GetMany(g => g.GoalType == false).OrderByDescending(g => g.Supports.Count()).ToList();
            return goals;
        }
        public Goal GetLastCreatedGoal(string userid)
        {
            var goal = goalRepository.GetMany(g => g.UserId == userid).Last();
            return goal;
        }
        public IEnumerable<Goal> GetGoals(string userid)
        {

            var goals = goalRepository.GetMany(g => (g.UserId == userid && g.GoalType == false)).OrderByDescending(g => g.GoalId).ToList();
            return goals;
        }
        public IEnumerable<Goal> GetGoalsbyPopularity(string userid)
        {

            var goals = goalRepository.GetMany(g => (g.UserId == userid && g.GoalType == false)).OrderByDescending(g => g.Supports.Count()).ToList();
            return goals;
        }

        public IEnumerable<Goal> GetMyGoals(string userid)
        {

            var goals = goalRepository.GetMany(g => (g.UserId == userid)).OrderByDescending(g => g.GoalId).ToList();
            return goals;
        }

        public IEnumerable<Goal> GetTop20GoalsofFollowing(string userid)
        {
            var goals = (from g in goalRepository.GetMany(g => g.GoalType == false) where (from f in followUserrepository.GetMany(fol => fol.FromUserId == userid) select f.ToUserId).ToList().Contains(g.UserId) select g);
            return goals;
        }

        public IEnumerable<Goal> GetTop20Goals(string userid)
        {

            var goals = goalRepository.GetMany(g => (g.GoalType == false) && (g.UserId == userid)).OrderByDescending(g => g.CreatedDate).Take(20).ToList();
            return goals;
        }
        public IEnumerable<Goal> SearchGoal(string goal)
        {
            return goalRepository.GetMany(g => g.GoalName.ToLower().Contains(goal.ToLower()) && g.GoalType == false).OrderBy(g => g.GoalName);
        }
        

        public void CreateGoal(Goal goal)
        {
            goalRepository.Add(goal);
            SaveGoal();
        }

        public void DeleteGoal(int id)
        {
            var goal = goalRepository.GetById(id);
            goalRepository.Delete(goal);
            SaveGoal();
        }

        public void EditGoal(Goal goalToEdit)
        {
            goalRepository.Update(goalToEdit);
            SaveGoal();
        }
        public IEnumerable<ValidationResult> CanAddGoal(Goal newGoal, IUpdateService updateService)
        {
            Goal goal;
            if (newGoal.GoalId == 0)
                goal = goalRepository.Get(g => g.GoalName == newGoal.GoalName);
            else
                goal = goalRepository.Get(g => g.GoalName == newGoal.GoalName && g.GoalId != newGoal.GoalId);
            if (goal != null)
            {
                yield return new ValidationResult("GoalName", Resources.GoalExists);
            }
            if (newGoal.StartDate.Subtract(newGoal.EndDate).TotalSeconds > 0)
            {
                yield return new ValidationResult("EndDate", Resources.EndDate);
            }

            int flag = 0;
            int status = 0;
            if (newGoal.GoalId != 0)
            {
                var Updates = updateService.GetUpdatesByGoal(newGoal.GoalId).OrderByDescending(g => g.UpdateDate).ToList();
                if (Updates.Count() > 0)
                {
                    if ((Updates[0].UpdateDate.Subtract(newGoal.EndDate).TotalSeconds > 0))
                    {
                        flag = 1;
                    }
                    if ((newGoal.StartDate.Subtract(Updates[0].UpdateDate).TotalSeconds > 0))
                    {
                        status = 1;
                    }
                    if (flag == 1)
                    {
                        yield return new ValidationResult("EndDate", Resources.EndDateNotValid + " "+Updates[0].UpdateDate.ToString("dd-MMM-yyyy"));
                    }
                    else if (status == 1)
                    {
                        yield return new ValidationResult("StartDate", Resources.StartDate + " "+Updates[0].UpdateDate.ToString("dd-MMM-yyyy"));
                    }
                }
               

                
            }
        }

        public void SaveGoal()
        {
            unitOfWork.Commit();
        }*/

        public Recipe GetRecipe(int id)
        {
            var recipe = recipeRepository.GetById(id);
            return recipe;
        }

        public IEnumerable<Recipe> GetRecipesByPage(int currentPage, int noOfRecords, string sortBy, int[] ingredients, int[] categories, string text)
        {
            return recipeRepository.GetRecipesByPage(currentPage, noOfRecords, sortBy, ingredients, categories, text);
        }

        #endregion
    }
}
