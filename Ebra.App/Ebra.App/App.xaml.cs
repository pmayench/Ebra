using Ebra.App.Models;
using Ebra.App.Repositories;
using Ebra.App.Services;
using Ebra.App.Services.Interfaces;
using Ebra.App.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ebra.App
{
	public partial class App : Application
	{

		public App()
		{
			InitializeComponent();

			DependencyService.Register<IGenericRepository<Article>>();

			DependencyService.Register<MockDataStore>();
            //DependencyService.Register<IArticleRepository, MockArticleRepository>();
            //DependencyService.Register<IArticleRepository, ArticleRepository>();

            DependencyService.Register<IVersionEntityRepository, MockRepositoryVersion>();
            DependencyService.Register<IOfferService,MockOfferService>();
            DependencyService.Register<IArticleService, MockArticleService>();
            DependencyService.Register<IOrderService, MockOrderService>();
            MainPage = new AppShell();
		}

		protected override void OnStart()
		{
		}

		protected override void OnSleep()
		{
		}

		protected override void OnResume()
		{
		}
	}
}
