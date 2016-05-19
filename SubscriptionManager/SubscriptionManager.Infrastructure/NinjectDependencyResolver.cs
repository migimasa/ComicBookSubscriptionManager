using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Configuration;
using System.Threading.Tasks;
using Ninject;
using Ninject.Modules;
using SubscriptionManager.DataLayer.Abstract;
using SubscriptionManager.DataLayer.Access;
using SubscriptionManager.Domain.Abstract;
using SubscriptionManager.Domain.CustomerManagement;
using SubscriptionManager.Domain.StoreManagement;
using Ninject.Parameters;
using Ninject.Syntax;

namespace SubscriptionManager.Infrastructure
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
            kernel.Bind<IStoreAccess>().To<StoreAccess>();
            kernel.Bind<ICustomerAccess>().To<CustomerAccess>();
            kernel.Bind<IClientele>().To<Customers>();
            kernel.Bind<ICustomer>().To<Customer>();
            kernel.Bind<IStores>().To<Stores>();
            kernel.Bind<IStore>().To<Store>();
        }
    }
}
