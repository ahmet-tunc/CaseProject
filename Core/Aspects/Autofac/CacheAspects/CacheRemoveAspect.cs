using System;
using CaseProject.Core.CrossCuttingConcerns.Caching;
using CaseProject.Core.Utilities.Interceptors;
using CaseProject.Core.Utilities.IoC;
using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;

namespace CaseProject.Core.Aspects.Autofac.CacheAspects
{
    [Serializable]
    public class CacheRemoveAspect: MethodInterception
    {
        private string _pattern;
        private readonly ICacheManager _cacheManager;

        public CacheRemoveAspect(string pattern)
        {
            _pattern = pattern;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        protected override void OnSuccess(IInvocation invocation)
        {
            _cacheManager.RemoveByPattern(_pattern);
        }
    }
}
