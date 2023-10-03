using Ebra.Server.API.Model;
using System.Xml.Schema;

namespace Ebra.Server.API.DTO
{
    public class OfferDTO
    {
        public double discount { get; set; }
        public DateTime endDate { get; set; }
        public DateTime startDate { get; set; }
        public List<Article> articles { get; set; }

        public OfferDTO(double discount, DateTime endDate, DateTime startDate, List<Article> articles) 
        {
            this.discount = discount;
            this.endDate = endDate;
            this.startDate = startDate;
            this.articles = articles;
        }
    }
}