using System.Web.Http;
using Unity;
using Unity.WebApi;
using refactor_this.Service;
using refactor_this.Models.BusinessModel;
using refactor_this;
namespace refactor_this
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            
            container.RegisterType<IAccount, Account>();
            
            container.RegisterType<ITransaction, Transaction>();
            container.RegisterType<ITestService, TestService>();
           
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
           
        }
    }
}