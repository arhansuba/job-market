using Autofac;

namespace JobMarket.Infrastructure.AutoFac
{
    public class ServiceHandlerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Autofac.Core.KeyedService>().As<ISeedService>();

            _ = builder.RegisterType<ApplicationUserService>().As<IApplicationUserService>();
            builder.RegisterType<RoleService>().As<IRoleService>();
            builder.RegisterType<AuthService>().As<IAuthService>();
            builder.RegisterType<JobCategoryService>().As<IJobCategoryService>();
            builder.RegisterType<JobTypeService>().As<IJobTypeService>();
            builder.RegisterType<JobOfferService>().As<IJobOfferService>();
        }
    }

    
}
