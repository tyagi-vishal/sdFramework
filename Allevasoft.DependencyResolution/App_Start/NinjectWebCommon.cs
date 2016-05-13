[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Allevasoft.DependencyResolution.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Allevasoft.DependencyResolution.App_Start.NinjectWebCommon), "Stop")]

namespace Allevasoft.DependencyResolution.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Allevasoft.DataAccess.Edmx;
    using Allevasoft.DataAccess.Repository;
    using Allevasoft.Services;
    using Allevasoft.DependencyResolution;
    using Allevasoft.Services.Interfaces;
    using Allevasoft.Services.Classes;
    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {

            kernel.Bind<IDbContext>().To<AllevasoftEntities>().InRequestScope();
            kernel.Bind<IUnitOfWork>().To<UnitOfWork<AllevasoftEntities>>();
            kernel.Bind<IUserService>().To<UserService>();
            kernel.Bind<ICommonService>().To<CommonService>();
            kernel.Bind<IReferralService>().To<ReferralService>();
            kernel.Bind<IUserManagement>().To<UserManagementService>();
            kernel.Bind<ILeadService>().To<LeadService>();
            ServiceLocator.SetServiceLocator(() => new NinjectServiceLocator(kernel));


        }
    }
}
