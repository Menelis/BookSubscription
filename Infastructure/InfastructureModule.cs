using Autofac;
using Core.Interfaces.Gateways.Repositories;
using Core.Interfaces.Services;
using Infastructure.Auth;
using Infastructure.Data.Repositories;

namespace Infastructure
{
    public class InfastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerLifetimeScope();
            builder.RegisterType<JwtFactory>().As<IJwtFactory>().InstancePerLifetimeScope();
        }
    }
}
