namespace Ebra.Server.API.DTO
{
    public class ArticleDTO
    {
        public string description { get; set; }
        public string name { get; set; }
        public double price { get; set; }

        public ArticleDTO(string description, string name, double price)
        {
            this.description = description;
            this.name = name;
            this.price = price;
        }
    }
}