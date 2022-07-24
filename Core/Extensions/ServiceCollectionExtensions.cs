using CaseProject.Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDependencyResolvers(this IServiceCollection services,
            ICoreModule[] modules)
        {
            foreach (var module in modules) //Bütün modüller .Net Core a yüklenecek
            {
                module.Load(services);
            }

            return ServiceTool.Create(services);
        }
    }
}
