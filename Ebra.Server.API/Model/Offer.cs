namespace Ebra.Server.API.Model
{
    public class Offer
    {
        public double discount { get; set; }
        public DateTime endDate { get; set; }
        public DateTime startDate { get; set; }
        public List<Article> articles { get; set; }

        public Offer(double discount, DateTime endDate, DateTime startDate, List<Article> articles)
        {
            this.discount = discount;
            this.endDate = endDate;
            this.startDate = startDate;
            this.articles = articles;
        }

        public Offer() { }
    }
}