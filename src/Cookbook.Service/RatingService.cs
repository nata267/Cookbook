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

        public RatingService(IRatingRepository ratingRepository)
        {
            this.ratingRepository = ratingRepository;
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
