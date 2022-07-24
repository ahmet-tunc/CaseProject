using CaseProject.Business.Abstract;
using CaseProject.Business.Abstract.BaseServices;
using CaseProject.Business.Concrete;
using CaseProject.Business.Concrete.BaseManagers;
using CaseProject.DataAccess.Abstract;
using CaseProject.DataAccess.Concrete;
using Core.DataAccess;
using Core.DataAccess.EntityFramework;
using Core.Utilities.Security.Jwt.Abstract;
using Core.Utilities.Security.Jwt.Concrete;
using Microsoft.Extensions.DependencyInjection;

namespace CaseProject.Business.IOC
{
    public static class MicrosoftDependencies
    {
        public static void AddCustomDependencies(this IServiceCollection services)
        {
            services.AddSingleton<AppDbContext>();
            services.AddScoped<IHistoryService, HistoryManager>();
            services.AddScoped<IHistoryDal, EfHistoryDal>();

            services.AddScoped<IHistoryCategoryService, HistoryCategoryManager>();
            services.AddScoped<IHistoryCategoryDal, EfHistoryCategoryDal>();

            services.AddScoped<IUserService, UserManager>();
            services.AddScoped<IUserDal, EfUserDal>();

            services.AddScoped<IAuthService, AuthManager>();
            services.AddScoped<ITokenHelper, JwtHelper>();

            services.AddScoped(typeof(IBaseService<>), typeof(BaseManager<>));
            services.AddScoped(typeof(IEntityRepository<>), typeof(EfEntityRepositoryBase<,>));
        }
    }
}
