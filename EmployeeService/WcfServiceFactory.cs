using EmployeeService.Managers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services.Description;
using Unity;
using Unity.Lifetime;
using Unity.Wcf;

namespace EmployeeService
{
    public class WcfServiceFactory : UnityServiceHostFactory, IServiceFactory
    {

        public void ConfigureUnityContainer(IUnityContainer container)
        {
            ConfigureContainer(container);
        }

        protected override void ConfigureContainer(IUnityContainer container)
        {
            ConfigureContainerPart1(container);
        }

        private void ConfigureContainerPart1(IUnityContainer container)
        {
            container
                 .RegisterType<IEmploeeManager, EmploeeManager>(new HierarchicalLifetimeManager())
                 .RegisterType<IEmployeeService, ServiceClient>(new HierarchicalLifetimeManager());
        }

    }

    public  interface IServiceFactory
    {
        void ConfigureUnityContainer(IUnityContainer container);
    }
}
