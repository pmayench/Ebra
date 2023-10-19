using Prism.DryIoc;
using System.Windows;
using Prism.Ioc;
using Ebra.Models.Interfaces;
using Ebra.Models.Services;
using Prism.Modularity;
using System.Reflection;

namespace Ebra.WPF
{
    class Bootstrapper : PrismBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IVersionEntityRepository, MockRepositoryVersion>();
            containerRegistry.Register<IOfferService, MockOfferService>();
            containerRegistry.Register<IArticleService, MockArticleService>();
            containerRegistry.Register<IOrderService, MockOrderService>();
        }

        protected override IModuleCatalog CreateModuleCatalog()
        {
            return new ConfigurationModuleCatalog();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<ArticlesModule.ModuleArticlesModule>();
        }
    }
}
