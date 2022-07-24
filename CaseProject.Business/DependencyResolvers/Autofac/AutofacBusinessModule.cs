using Autofac;
using Autofac.Extras.DynamicProxy;
using CaseProject.Business.Abstract;
using CaseProject.Business.Abstract.BaseServices;
using CaseProject.Business.Concrete;
using CaseProject.Business.Concrete.BaseManagers;
using CaseProject.DataAccess.Abstract;
using CaseProject.DataAccess.Concrete;
using CaseStudy.Core.Utilities.Interceptors;
using Castle.DynamicProxy;

namespace CaseProject.Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = System.Reflection.Assembly.GetExecutingAssembly(); //Mevcut assemblye ulaşıldı
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces() //Assemblyde ki bütün tipleri kayıt et
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
