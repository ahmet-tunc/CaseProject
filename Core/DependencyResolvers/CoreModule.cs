﻿using CaseProject.Core.CrossCuttingConcerns.Caching;
using CaseProject.Core.CrossCuttingConcerns.Caching.Microsoft;
using CaseProject.Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace CaseProject.Core.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddSingleton<ICacheManager, MemoryCacheManager>();
        }
    }
}
