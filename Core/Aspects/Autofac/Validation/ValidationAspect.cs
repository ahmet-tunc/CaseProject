﻿using CaseProject.Core.Utilities.Interceptors;
using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation.FluentValidation;
using FluentValidation;
using System;
using System.Linq;

namespace CaseStudy.Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new Exception("Wrong validation type");
            }
            _validatorType = validatorType;
        }

        protected override void OnBefore(IInvocation invocation) //İlgili method çalıştırılmadan hemen önce, method parametrelerini validate eder
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}