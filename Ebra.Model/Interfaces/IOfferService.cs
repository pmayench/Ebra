using Ebra.Models.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ebra.Models.Interfaces
{
    public interface IOfferService
    {
        //obtener versión listas de hoy
        Task<string> GetVersionAsync();
        //obtener ofertas
        Task<List<Offer>> GetOffersAsync();
    }
}
