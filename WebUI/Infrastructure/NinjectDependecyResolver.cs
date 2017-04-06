using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Ninject;
using Ninject.Web.Common;
using Domain.Abstract;
using Moq;
using Domain.Entities;
using Domain.Concrete;

namespace WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }
        private void AddBindings()
        {

            kernel.Bind<IItemRepository>().To<EFItemRepository>();
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

            public IEnumerable<object> GetServices(Type serviceType)
           {
              return kernel.GetAll(serviceType);
        }
    }
}