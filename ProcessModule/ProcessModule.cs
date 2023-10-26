using AutoMapper;
using Ebra.Infrastructure.Prism;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using ProcessModule.Mappers;
using ProcessModule.Views;

namespace ProcessModule
{
    public class ProcessModule : IModule
    {
        // Registrar las vistas y regiones de este módulo
        public void OnInitialized(IContainerProvider containerProvider)
        {
            //var regionManager = containerProvider.Resolve<IRegionManager>();
            //regionManager.RegisterViewWithRegion(RegionNames.LeftRegion.ToString(), typeof(ProcessListView));
            //regionManager.RegisterViewWithRegion(RegionNames.CentralRegion.ToString(), typeof(ProcessDetailView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<ProcessListView>();
            containerRegistry.RegisterForNavigation<ProcessDetailView>();

            MapperConfiguration mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProcessAutoMapper>();
            });
        }
    }
}
