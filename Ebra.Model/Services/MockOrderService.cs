using Ebra.Models.Interfaces;
using Ebra.Models.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ebra.Models.Services
{
    public class MockOrderService : IOrderService, IMock
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