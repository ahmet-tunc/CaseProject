using Microsoft.Extensions.DependencyInjection;

namespace CaseProject.Core.Utilities.IoC
{
    public interface ICoreModule
    {
        void Load(IServiceCollection collection);
    }
}
