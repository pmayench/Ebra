using System;
using System.Collections.Generic;

namespace TestProject.Modelo
{
    public class Customer : EntityBase
	{
		public string name { get; set; }
		public string surname { get; set; }
		public string email { get; set; }
		public string phone { get; set; }
		public DateTime birthday { get; set; }
		public List<Order> orders { get; set; }
	}
}
