using ArticlesModule.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace ArticlesModule
{
    public class ModuleArticlesModule : IModule
    {
        // Registrar las vistas y regiones de este módulo
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion("ContentRegion", typeof(ucArticleList));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            
        }
    }
}
