﻿using System;
using System.Collections.Generic;
using System.Web.Mvc;
using ETools.Models;
using Ninject;
using Ninject.Web.Common;

namespace ETools.Infrastructure {
    public class NinjectDependencyResolver : IDependencyResolver {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam) {
            kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType) {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType) {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings() {
            kernel.Bind<IValueCalculator>().To<LinqValueCalculator>().InRequestScope();
            //kernel.Bind<IDiscountHelper>().To<DefaultDiscountHelper>().WithPropertyValue("DiscountSize", 50m);
            //kernel.Bind<IValueCalculator>().To<LinqValueCalculator>().InRequestScope();
            
            kernel.Bind<IDiscountHelper>()
              .To<DefaultDiscountHelper>().WithConstructorArgument("discountParam", 50M);
            kernel.Bind<IDiscountHelper>().To<FlexibleDiscountHelper>()
              .WhenInjectedInto<LinqValueCalculator>();
              
        }
    }
}
