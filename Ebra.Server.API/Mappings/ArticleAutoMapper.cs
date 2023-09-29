using AutoMapper;
using Ebra.Server.API.DTO;
using Ebra.Server.API.Model;

namespace Ebra.Server.API.Mappings
{
    public class ArticleAutoMapper : Profile
    {
        public ArticleAutoMapper() 
        {
            CreateMap<Article, ArticleDTO>().ReverseMap();
        }
    }
}
