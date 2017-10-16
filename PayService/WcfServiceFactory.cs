using Microsoft.Practices.Unity;
using Payment.DAL.Core.Repository.Interface;
using Payment.DAL.Core.Service;
using PaymentBLL.Implementation;
using PaymentBLL.Interface;
using PayService.Implementation.Implementation;
using PayService.Implementation.Interface;
using Unity.Wcf;

namespace PayService   
{
	public class WcfServiceFactory : UnityServiceHostFactory
    {
        protected override void ConfigureContainer(IUnityContainer container)
        {
            // register all your components with the container here
            // container
            //    .RegisterType<IService1, Service1>()
            //    .RegisterType<DataContext>(new HierarchicalLifetimeManager());

            //Business Logic
            container.RegisterType<IAdminManager, AdminManager>();
            //Unit of Work
            container.RegisterType<IPaymentCoreContext, PaymentCoreContext>();
            //Services
            container.RegisterType<IBankService, BankService>();
            container.RegisterType<ISchoolService, SchoolService>();
        }
    }    
}