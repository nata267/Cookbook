﻿using System;
using System.Collections.Generic;
using System.Linq;
using Cookbook.Data.Repository;
using Cookbook.Data.Models;
using Cookbook.Data.Infrastructure;
using Cookbook.Model.Models;

namespace Cookbook.Data.Repository
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {

        }
    }

    public interface ICategoryRepository : IRepository<Category>
    {
    }
}
