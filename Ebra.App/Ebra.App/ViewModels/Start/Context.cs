using Ebra.App.Models;
using Ebra.App.Repositories;
using Ebra.App.Services.Interfaces;
using System.Collections.Generic;

namespace Ebra.App.ViewModels.Start
{
    public class Context
    {
        public List<Article> Articles { get; internal set; }
        public List<Offer> Offers { get; internal set; }
        public IOfferService OfferService { get; internal set; }
        public IVersionEntityRepository VersionEntityRepository { get; internal set; }
        public IArticleRepository ArticleRepository { get; internal set; }

        public Context(IOfferService offerService, IArticleService articleService, IOrderService orderService, IVersionEntityRepository versionEntityRepository, IArticleRepository articleRepository)
        {
            OfferService = offerService;
            ArticleService = articleService;
            OrderService = orderService;
            VersionEntityRepository = versionEntityRepository;
            ArticleRepository = articleRepository;
        }

        public List<Order> Orders;
        public IArticleService ArticleService { get; internal set; }
        public IOrderService OrderService { get; internal set; }

        internal int Save(Context p)
        {

            return 1;
        }
    }
}