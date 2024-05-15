using JobMarket.Models.JobCategoryViewModels;
using JobMarket.Models.JobOfferViewModels;
using JobMarket.Models.JobTypeViewModels;
using JobMarket.Models.JobTypeVİewModels;
using JobMarket.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;
using AutoMapper;

namespace JobMarket.Infrastructure.AutoMapper
{
    public class DefaultProfile : Profile
    {
        public DefaultProfile()
        {
            #region JobCategory

            CreateMap<JobCategory, JobCategoryViewModel>();
            CreateMap<JobCategory, CreateJobCategoryViewModel>();
            CreateMap<JobCategory, DeleteJobCategoryViewModel>();
            CreateMap<JobCategory, DetailsJobCategoryViewModel>();
            CreateMap<JobCategory, EditJobCategoryViewModel>();

            CreateMap<CreateJobCategoryViewModel, JobCategory>();
            CreateMap<DeleteJobCategoryViewModel, JobCategory>();
            CreateMap<DetailsJobCategoryViewModel, JobCategory>();
            CreateMap<EditJobCategoryViewModel, JobCategory>();

            #endregion

            #region JobType

            CreateMap<JobType, JobTypeViewModel>();
            CreateMap<JobType, CreateJobTypeViewModel>();
            CreateMap<JobType, DeleteJobTypeViewModel>();
            CreateMap<JobType, DetailsJobTypeViewModel>();
            CreateMap<JobType, EditJobTypeViewModel>();

            CreateMap<JobTypeViewModel, JobType>();
            CreateMap<CreateJobTypeViewModel, JobType>();
            CreateMap<DeleteJobTypeViewModel, JobType>();
            CreateMap<DetailsJobTypeViewModel, JobType>();
            CreateMap<EditJobTypeViewModel, JobType>();

            #endregion

            #region JobOffer

            CreateMap<JobOffer, JobOfferViewModel>()
                .ForMember(dest => dest.Author,
                    opts => opts.MapFrom(src => src.Author));
            CreateMap<JobOffer, PopularJobOfferViewModel>();
            CreateMap<JobOffer, CreateJobOfferViewModel>()
                .ForMember(dest => dest.JobCategoryId,
                    opts => opts.MapFrom(src => src.JobCategory.JobCategoryId))
                .ForMember(dest => dest.JobTypeId,
                    opts => opts.MapFrom(src => src.JobType.JobTypeId))
                .ForMember(dest => dest.AuthorId,
                    opts => opts.MapFrom(src => src.Author.Id));
            CreateMap<JobOffer, DeleteJobOfferViewModel>();
            CreateMap<JobOffer, DetailsJobOfferViewModel>();
            CreateMap<JobOffer, EditJobOfferViewModel>()
                .ForMember(dest => dest.JobCategoryId,
                    opts => opts.MapFrom(src => src.JobCategory.JobCategoryId))
                .ForMember(dest => dest.JobTypeId,
                    opts => opts.MapFrom(src => src.JobType.JobTypeId));

            CreateMap<CreateJobOfferViewModel, JobOffer>();
            CreateMap<DeleteJobOfferViewModel, JobOffer>();
            CreateMap<DetailsJobOfferViewModel, JobOffer>();
            CreateMap<EditJobOfferViewModel, JobOffer>();

            #endregion
        }

        private new void CreateMap<T1, T2>()
        {
            throw new NotImplementedException();
        }
    }
}
