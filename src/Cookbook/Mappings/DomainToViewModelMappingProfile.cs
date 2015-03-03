using AutoMapper;
//using PagedList;
using Cookbook.Model.Models;
//using SocialGoal.Web.Core.AutoMapperConverters;
using Cookbook.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cookbook.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<Recipe, RecipeViewModel>();
            /*Mapper.CreateMap<Goal, GoalFormModel>();
            Mapper.CreateMap<Comment, CommentsViewModel>();
            Mapper.CreateMap<UserProfile, UserProfileFormModel>();
            Mapper.CreateMap<Group, GroupGoalFormModel>();
            Mapper.CreateMap<Group, GroupFormModel>();
            Mapper.CreateMap<GroupGoal, GroupGoalFormModel>();
            Mapper.CreateMap<GroupInvitation, NotificationViewModel>();
            Mapper.CreateMap<SupportInvitation, NotificationViewModel>();
            Mapper.CreateMap<Group, GroupViewModel>();
            Mapper.CreateMap<GroupGoal, GroupGoalViewModel>();
            Mapper.CreateMap<GroupComment, GroupCommentsViewModel>();
            Mapper.CreateMap<Focus, FocusViewModel>();
            Mapper.CreateMap<Focus, FocusFormModel>();
            Mapper.CreateMap<GroupRequest, GroupRequestViewModel>();
            Mapper.CreateMap<FollowRequest, NotificationViewModel>();
            Mapper.CreateMap<ApplicationUser, FollowersViewModel>();
            Mapper.CreateMap<ApplicationUser, FollowingViewModel>();
            Mapper.CreateMap<Update, UpdateFormModel>();
            Mapper.CreateMap<GroupUpdate, GroupUpdateFormModel>();
            Mapper.CreateMap<Update, UpdateViewModel>();
            Mapper.CreateMap<GroupUpdate, GroupUpdateViewModel>();*/
            //Mapper.CreateMap<X, XViewModel>()
            //    .ForMember(x => x.Property1, opt => opt.MapFrom(source => source.PropertyXYZ));
            Mapper.CreateMap<Recipe, RecipeListViewModel>();
           /* Mapper.CreateMap<Group, GroupsItemViewModel>().ForMember(x => x.CreatedDate, opt => opt.MapFrom(source => source.CreatedDate.ToString("dd MMM yyyy")));

            Mapper.CreateMap<IPagedList<Group>, IPagedList<GroupsItemViewModel>>().ConvertUsing<PagedListConverter<Group, GroupsItemViewModel>>();
           
            */
        }
    }
}