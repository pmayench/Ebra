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
using System.Windows.Controls;
using Ebra.WPF.Views;
using Ebra.WPF.VM;
using Ebra.Infrastructure.Prism;
using ProcessModule;
using ProcessModule.Views;
using ProcessModule.VM;
using AutoMapper;
using ProcessModule.Mappers;

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

            MapperConfiguration  mapper = new MapperConfiguration(c => c.AddProfile<ProcessAutoMapper>());
            IMapper iMapper = mapper.CreateMapper();

            containerRegistry.RegisterInstance<IMapper>(iMapper);
        }

        protected override IModuleCatalog CreateModuleCatalog()
        {
            return new ConfigurationModuleCatalog();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<ArticlesModule.ModuleArticlesModule>();
            moduleCatalog.AddModule<ProcessModule.ProcessModule>();
            moduleCatalog.AddModule<ConfigurationModule.ConfigurationModule>();
            //reflectionSample();
            //    .ConfigureViewModelLocator2();
        }

        protected override void ConfigureViewModelLocator()
        {
            base.ConfigureViewModelLocator();
            // type / type
            ViewModelLocationProvider.Register(typeof(ucArticleList).ToString(), typeof(ArticleViewModelPrism));
            ViewModelLocationProvider.Register(typeof(MenuView).ToString(), typeof(MenuViewModel));
            ViewModelLocationProvider.Register(typeof(ProcessListView).ToString(), typeof(ProcessViewModel));

            // type / factory
            //ViewModelLocationProvider.Register(typeof(ucArticleList).ToString(), () => Container.Resolve<ArticleViewModelPrism>());

            // generic factory
            //ViewModelLocationProvider.Register<ucArticleList>(() => Container.Resolve<ArticleViewModelPrism>());

            // generic type
            //ViewModelLocationProvider.Register<ucArticleList, ArticleViewModelPrism>();
        }

        //protected override void ConfigureRegionAdapterMappings(RegionAdapterMappings regionAdapterMappings)
        //{
        //    base.ConfigureRegionAdapterMappings(regionAdapterMappings);
        //    regionAdapterMappings.RegisterMapping(typeof(StackPanel), Container.Resolve<StackPanelRegionAdapter>());
        //    this.ConfigureRegionsApp();
        //}

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
}
