using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cookbook.Data;
using Cookbook.Data.Infrastructure;
using Cookbook.Model.Models;
using Cookbook.Data.Repository;

namespace Cookbook.Service
{
    public interface IRatingService
    {
        Rating GetRating(int id);
    }

    public class RatingService : IRatingService
    {
        private readonly IRatingRepository ratingRepository;
        /*private readonly IFollowUserRepository followUserrepository;
        private readonly IUnitOfWork unitOfWork;*/

        public RatingService(IRatingRepository ratingRepository/*, IFollowUserRepository followUserRepository, IUnitOfWork unitOfWork*/)
        {
            this.ratingRepository = ratingRepository;
            /*this.unitOfWork = unitOfWork;
            this.followUserrepository = followUserRepository;*/
        }

        #region IRatingService Members

        public Rating GetRating(int id)
        {
            var rating = ratingRepository.GetById(id);
            return rating;
        }

        #endregion
    }
}
