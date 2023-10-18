using Ebra.Models.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ebra.Models.Interfaces
{
    public interface IOrderService
    {
        //obtener pedido
        Task<List<Order>> GetOrdersAsync();

        //obtener pedidos
        Task<string> GetVersionAsync();
    }

}
