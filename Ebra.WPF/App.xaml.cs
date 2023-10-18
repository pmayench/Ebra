using Prism.DryIoc;
using System.Windows;
using Prism.Ioc;
using Ebra.Models.Interfaces;
using Ebra.Models.Services;

namespace Ebra.WPF
{
    /// <summary>
    /// Lógica de interacción para Page1.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IVersionEntityRepository, MockRepositoryVersion>();
            containerRegistry.Register<IOfferService, MockOfferService>();
            containerRegistry.Register<IArticleService, MockArticleService>();
            containerRegistry.Register<IOrderService, MockOrderService>();
        }

        protected override Window CreateShell()
        {
            //throw new NotImplementedException();
            return Container.Resolve<MainWindow>();
        }
    }
}
