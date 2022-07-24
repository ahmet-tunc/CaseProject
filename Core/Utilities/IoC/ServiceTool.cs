using Core.DataAccess;
using Core.DataAccess.EntityFramework;
using Core.Utilities.Security.Jwt.Abstract;
using Core.Utilities.Security.Jwt.Concrete;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CaseProject.Core.Utilities.IoC
{
    public static class ServiceTool
    {
        public static IServiceProvider ServiceProvider { get; private set; }
        public static IServiceCollection Create(IServiceCollection services)
        {
            ServiceProvider = services.BuildServiceProvider();  //Servisleri yapılandırır
            return services;
        }
    }
}
