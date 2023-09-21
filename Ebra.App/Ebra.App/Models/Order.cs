using System.Collections.Generic;

namespace TestProject.Modelo
{
    public class Order : EntityBase
	{
		public Customer customer { get; set; }
		public List<Article> articles { get; set; }
		public double total { get; set; }
		public double totalDiscount { get; set; }
	}
}
