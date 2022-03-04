using Autofac;
using Oponeo.Domain;

namespace Oponeo.Infrastructure;

public class OponeoModule: Module
{
    protected override void Load(ContainerBuilder builder)
    {
        base.Load(builder);

        builder
            .RegisterAssemblyTypes(typeof(Offer).Assembly, ThisAssembly)
            .Where(x => x.IsAssignableTo<IIocScoped>())
            .AsImplementedInterfaces()
            .InstancePerLifetimeScope();
    }
}