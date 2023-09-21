using System.Threading.Tasks;

namespace Ebra.App.Services.Interfaces
{
    public interface IOrderService
    {
        //obtener pedido
        Task<string> GetOrderAsync(string id);
        //obtener pedidos
        Task<string> GetOrdersAsync();
    }

}
