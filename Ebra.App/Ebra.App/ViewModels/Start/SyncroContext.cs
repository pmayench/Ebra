using Ebra.App.Factories;
using Ebra.App.Models;
using Ebra.App.Repositories;
using Ebra.App.Services.Interfaces;
using System.Collections.Generic;

namespace Ebra.App.ViewModels.Start
{
    public class SyncroContext : ISyncroContext
    {
        public List<Article> Articles { get;  set; }
        public List<Offer> Offers { get;  set; }
        public IOfferService OfferService { get;  set; }
        public IVersionEntityRepository VersionEntityRepository { get;  set; }
        public IArticleRepository ArticleRepository { get;  set; }

        public SyncroContext(IOfferService offerService, IArticleService articleService, IOrderService orderService, IVersionEntityRepository versionEntityRepository, IArticleRepository articleRepository)
        {
            OfferService = offerService;
            ArticleService = articleService;
            OrderService = orderService;
            VersionEntityRepository = versionEntityRepository;
            ArticleRepository = articleRepository;
        }

        public List<Order> Orders { get; set; }
        public IArticleService ArticleService { get;  set; }
        public IOrderService OrderService { get;  set; }

        internal int Save(SyncroContext p)
        {

            return 1;
        }
    }
}