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
    public interface ICategoryService
    {
        IEnumerable<Category> GetAll();
    }

    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        #region ICategoryService Members

        public IEnumerable<Category> GetAll()
        {
            var categories = categoryRepository.GetAll().OrderBy(i => i.Name);
            return categories;
        }

        #endregion
    }
}
