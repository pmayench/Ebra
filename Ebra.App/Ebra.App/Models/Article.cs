namespace Ebra.App.Models
{
    public class Article : EntityBase
    {
        public string description { get; set; }
        public string name { get; set; }
        public double price { get; set; }

        public Article(string description, string name, double price)
        {
            id = id;
            this.description = description;
            this.name = name;
            this.price = price;
        }
    }
}
