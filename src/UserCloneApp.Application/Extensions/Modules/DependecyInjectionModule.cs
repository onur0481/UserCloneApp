using Autofac;
using System.Reflection;
using Module = Autofac.Module;

namespace UserCloneApp.Application.Extensions.Modules
{
    public class DependecyInjectionModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var apiAssembly = Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(apiAssembly).Where(
                x => x.Name.EndsWith("Validator")
                ).AsImplementedInterfaces().InstancePerLifetimeScope();
        }
    }
}
