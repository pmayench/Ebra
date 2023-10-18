using Ebra.Models.Models;
using Ebra.App.Services.Interfaces;
using System.Collections.Generic;
using Ebra.Models.Interfaces;

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
