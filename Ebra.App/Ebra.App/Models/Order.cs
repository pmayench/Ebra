using System.Collections.Generic;

namespace Ebra.App.Models
{
    public class Order : EntityBase
    {
        public Customer customer { get; set; }
        public List<Article> articles { get; set; }
        public double total { get; set; }
        public double totalDiscount { get; set; }
    }
}
