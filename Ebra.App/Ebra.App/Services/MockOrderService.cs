using Ebra.Models.Models;
using Ebra.App.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ebra.App.Services
{
    public class MockOrderService : IOrderService
    {
        public Task<List<Order>> GetOrdersAsync()
        {
            return Task.Run(() => new List<Order>());
        }

        public Task<string> GetVersionAsync()
        {
            var task = new Task<string>(() => "1.0");
            return task;
        }
    }
}