namespace Ebra.Server.API.Model
{
    public class Article
    {
        public string provider { get; set; }
        public string description { get; set; }
        public string name { get; set; }
        public double price { get; set; }

        public Article(string provider, string description, string name, double price)
        {
            this.provider = provider;
            this.description = description;
            this.name = name;
            this.price = price;
        }

        public Article() { }
    }
}