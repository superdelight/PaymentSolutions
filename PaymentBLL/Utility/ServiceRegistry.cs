using Microsoft.Practices.Unity;
using Payment.DAL.Core.Repository.Interface;
using Payment.DAL.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentBLL.Utility
{
   public class ServiceRegistry
    {
        public static IUnityContainer Configure()
        {
            var container = new UnityContainer();

            container.RegisterType<IPaymentCoreContext, PaymentCoreContext>();

            return container;
        }
    }
}
