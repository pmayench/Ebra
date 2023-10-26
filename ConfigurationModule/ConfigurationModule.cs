using ConfigurationModule.Views;
using Ebra.Infrastructure.Prism;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace ConfigurationModule
{
    public class ConfigurationModule : IModule
    {
        // Registrar las vistas y regiones de este módulo
        public void OnInitialized(IContainerProvider containerProvider)
        {
            //var regionManager = containerProvider.Resolve<IRegionManager>();
            //regionManager.RegisterViewWithRegion(RegionNames.LeftRegion.ToString(), typeof(ConfigurationListView));
            //regionManager.RegisterViewWithRegion(RegionNames.CentralRegion.ToString(), typeof(ConfigurationDetailView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<ConfigurationListView>();
            containerRegistry.RegisterForNavigation<ConfigurationDetailView>();
        }
    }
}
