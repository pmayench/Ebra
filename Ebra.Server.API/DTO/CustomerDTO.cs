using Ebra.Server.API.Model;

namespace Ebra.Server.API.DTO
{
    public class CustomerDTO
    {
        public string name { get; set; }
        public string surname { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public DateTime birthday { get; set; }
        public List<Order> orders { get; set; }

        public CustomerDTO(string name, string surname, string email, string phone, DateTime birthday, List<Order> orders)
        {
            this.name = name;
            this.surname = surname;
            this.email = email;
            this.phone = phone;
            this.birthday = birthday;
            this.orders = orders;
        }
    }
}