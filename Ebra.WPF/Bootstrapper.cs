using Prism.DryIoc;
using System.Windows;
using Prism.Ioc;
using Ebra.Models.Interfaces;
using Ebra.Models.Services;
using Prism.Modularity;
using System.Reflection;
using System;
using System.Linq;
using Prism.Mvvm;
using ArticlesModule.Views;
using ArticlesModule.VM;
using Prism.Regions;
using Ebra.WPF.VM;
using Ebra.WPF.Views;

namespace Ebra.WPF
{
    public partial class Bootstrapper : PrismBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<TaskManager>();
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
            reflectionSample();
            this.ConfigureRegionsApp()
                .ConfigureViewModelLocator2();
        }

        protected override void ConfigureViewModelLocator()
        {
            base.ConfigureViewModelLocator();
            // type / type
            ViewModelLocationProvider.Register(typeof(ucArticleList).ToString(), typeof(ArticleViewModelPrism));

            // type / factory
            //ViewModelLocationProvider.Register(typeof(ucArticleList).ToString(), () => Container.Resolve<ArticleViewModelPrism>());

            // generic factory
            //ViewModelLocationProvider.Register<ucArticleList>(() => Container.Resolve<ArticleViewModelPrism>());

            // generic type
            //ViewModelLocationProvider.Register<ucArticleList, ArticleViewModelPrism>();
        }


        private void reflectionSample()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var assemblyModule = typeof(ArticlesModule.ModuleArticlesModule).Assembly;

            var type = typeof(IModule);
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p));
        }
    }
    

    public static class BootstrapperExtensions
    {
        public static Bootstrapper ConfigureRegionsApp(this Bootstrapper bootstrapper)
        {
            var _regionManager = bootstrapper.Container.Resolve<IRegionManager>();
            _regionManager.AddToRegion(RegionNames.MenuRegion.ToString(), typeof(MenuView));


            return bootstrapper;
        }

        public static Bootstrapper ConfigureViewModelLocator2(this Bootstrapper bootstrapper)
        {
            return bootstrapper;
        }
    }

    public class OtherModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            throw new NotImplementedException();
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            throw new NotImplementedException();
        }
    }
}
