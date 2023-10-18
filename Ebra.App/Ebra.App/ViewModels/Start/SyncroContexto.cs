using Ebra.App.Factories;
using Ebra.App.Repositories;
using Ebra.App.Services.Interfaces;
using Ebra.Models.Models;
using System.Collections.Generic;

namespace Ebra.App.ViewModels.Start
{
    public class SyncroContexto : ISyncroContext
    {
        public List<Article> Articles { get;  set; }
        public List<Offer> Offers { get;  set; }
        public IOfferService OfferService { get;  set; }
        public IVersionEntityRepository VersionEntityRepository { get;  set; }
        public IArticleRepository ArticleRepository { get;  set; }

        public SyncroContexto(IOfferService offerService, IArticleService articleService, IOrderService orderService, IVersionEntityRepository versionEntityRepository, IArticleRepository articleRepository, IGenericRepository<Article> genericRepository)
        {
            OfferService = offerService;
            ArticleService = articleService;
            OrderService = orderService;
            VersionEntityRepository = versionEntityRepository;
            ArticleRepository = articleRepository;
            GenericRepository = genericRepository;
        }

        public List<Order> Orders { get; set; }
        public IArticleService ArticleService { get;  set; }
        public IOrderService OrderService { get;  set; }
        public IGenericRepository<Article> GenericRepository { get; set; }

     
    }
}