using Ebra.Server.API.Model;

namespace Ebra.Server.API.DTO
{
    public class OrderDTO
    {
        public Customer customer { get; set; }
        public List<Article> articles { get; set; }
        public double total { get; set; }
        public double totalDiscount { get; set; }

        public OrderDTO(Customer customer, List<Article> articles, double total, double totalDiscount)
        {
            this.customer = customer;
            this.articles = articles;
            this.total = total;
            this.totalDiscount = totalDiscount;
        }
    }
}