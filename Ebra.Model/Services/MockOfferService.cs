using Ebra.Models.Interfaces;
using Ebra.Models.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ebra.Models.Services
{
    public class MockOfferService : IOfferService
    {
        public Task<List<Offer>> GetOffersAsync()
        {
            return Task.Run(() => new List<Offer>() { new Offer() });
        }

        public Task<string> GetVersionAsync()
        {
            var task = new Task<string>(() => "1.0");
            return task;
        }
    }
}