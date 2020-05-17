using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
//using Ninject.Web.Common;
using University.Persistence.Repositories;

namespace University.DI
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver()
        {
            kernel = new StandardKernel();
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
        private void AddBindings()
        {
            kernel.Bind<IUnitOfWork>().To<UnitOfWork>();
        }
    }
    //public class NinjectDependencyResolver : IDependencyResolver
    //{
    //    private IKernel _kernel;

    //    public NinjectDependencyResolver(IKernel kernel)
    //    {
    //        _kernel = kernel;
    //        AddBindings();
    //    }

    //    private void AddBindings()// all the dependency bindings should be there
    //    {
    //        _kernel.Bind<IUnitOfWork>().To<UnitOfWork>();
    //    }

    //    public object GetService(Type serviceType)
    //    {
    //        return _kernel.TryGet(serviceType);
    //    }

    //    public IEnumerable<object> GetServices(Type serviceType)
    //    {
    //        return _kernel.GetAll(serviceType);
    //    }


    //}
}