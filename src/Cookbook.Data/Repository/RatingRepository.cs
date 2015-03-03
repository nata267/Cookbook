using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cookbook.Data.Repository;
using Cookbook.Data.Models;
using Cookbook.Data.Infrastructure;
using Cookbook.Model.Models;

namespace Cookbook.Data.Repository
{
    public class RatingRepository : RepositoryBase<Rating>, IRatingRepository
    {
        public RatingRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {

        }
    }

    public interface IRatingRepository : IRepository<Rating>
    {
    }
}
