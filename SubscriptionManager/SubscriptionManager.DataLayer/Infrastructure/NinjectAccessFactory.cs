using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using SubscriptionManager.DataLayer.Abstract;
using SubscriptionManager.DataLayer.Access;

namespace SubscriptionManager.DataLayer.Infrastructure
{
    public class NinjectAccessFactory
    {
        private IKernel ninjectKernel;

        public NinjectAccessFactory() {
            ninjectKernel = new StandardKernel();
            AddBindings();
        }

        private void AddBindings()
        {
            ninjectKernel.Bind<IStoreAccess>().To<StoreAccess>();
        }
    }
}
