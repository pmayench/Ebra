using System.Collections.Generic;
using System.Threading.Tasks;
using TestProject.Modelo;

namespace Ebra.App.Services.Interfaces
{
    public interface IArticleService
    {
        //obtener versión listas de hoy
        Task<string> GetVersionAsync();
        //obtener articulos
        Task<List<Article>> GetArticlesAsync();
    }

}
