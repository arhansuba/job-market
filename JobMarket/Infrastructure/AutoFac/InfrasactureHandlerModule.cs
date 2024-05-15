using Autofac;
using AutoMapper;
using System.Reflection;
using Module = Autofac.Module;

namespace JobMarket.Infrastructure.AutoFac
{
    
    
        public class InfrastructureHandlerModule : Module
        {
            protected override void Load(ContainerBuilder builder)
            {
                builder.RegisterType<Mapper>().As<IMapper>();
            }
        }
    
}
