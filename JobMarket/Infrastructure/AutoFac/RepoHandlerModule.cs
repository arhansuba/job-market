using Autofac;
using JobMarket.Data.Repository.Abstract;
using JobMarket.Data.Repository;
using JobMarket.Data;

namespace JobMarket.Infrastructure.AutoFac
{
    public class RepositoryHandlerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MigrationManager>().As<IMigrationManager>();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();

            builder.RegisterType<ApplicationUserRepository>().As<IApplicationUserRepository>();
            builder.RegisterType<RoleRepository>().As<IRoleRepository>();
            builder.RegisterType<JobCategoryRepository>().As<IJobCategoryRepository>();
            builder.RegisterType<JobTypeRepository>().As<IJobTypeRepository>();
            builder.RegisterType<JobOfferRepository>().As<IJobOfferRepository>();
        }
    }

}
