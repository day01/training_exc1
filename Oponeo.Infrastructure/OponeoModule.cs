using Autofac;
using Oponeo.Domain;

namespace Oponeo.Infrastructure;

public class OponeoModule: Module
{
    protected override void Load(ContainerBuilder builder)
    {
        base.Load(builder);

        // builder
        //     .RegisterType<MockRepository>()
        //     .AsImplementedInterfaces()
        //     .InstancePerLifetimeScope();
        
            // Lifetime Scope
            
            // Scoped - na czas życia Lifetime Scope
            // Transient | PerDependency - kazde uzycie tworz nowy obiekt
            // Singleton | SingleInstance
    }
}