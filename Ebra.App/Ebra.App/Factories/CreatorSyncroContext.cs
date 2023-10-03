﻿using Ebra.App.Models;
using Ebra.App.Repositories;
using Ebra.App.Services.Interfaces;
using Ebra.App.ViewModels.Start;
using Xamarin.Forms;

namespace Ebra.App.Factories
{
    class CreatorSyncroContext : CreatorBase
    {
        public override ISyncroContext FactoryMethod()
        {
            var _offerService = DependencyService.Get<IOfferService>();
            var _articleService = DependencyService.Get<IArticleService>();
            var _orderService = DependencyService.Get<IOrderService>();
            var _versionEntityRepository = DependencyService.Get<IVersionEntityRepository>();
            var _articleRepository = DependencyService.Get<IArticleRepository>();
            var _genericRepository = DependencyService.Get < IGenericRepository<Article>>();

            return new SyncroContext(_offerService, _articleService, _orderService, _versionEntityRepository, _articleRepository, _genericRepository);
        }
    }
}
