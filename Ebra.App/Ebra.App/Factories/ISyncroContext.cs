using Ebra.App.Repositories;
using Ebra.App.Services.Interfaces;
using Ebra.Models.Models;
using System.Collections.Generic;

namespace Ebra.App.Factories
{
    public interface ISyncroContext
    {
        IGenericRepository<Article> GenericRepository { get; set; }
        IArticleRepository ArticleRepository { get; set; }
        List<Article> Articles { get; set; }
        IArticleService ArticleService { get; set; }
        List<Offer> Offers { get; set; }
        IOfferService OfferService { get; set; }
        IOrderService OrderService { get; set; }
        IVersionEntityRepository VersionEntityRepository { get; set; }
        List<Order> Orders { get; set; }
    }
}
