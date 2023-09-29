using AutoMapper;
using Ebra.Server.API.DTO;
using Ebra.Server.API.Model;

namespace TestProject
{
    [TestClass]
    [TestCategory("AutoMappers")]
    public class AutoMapperTest
    {
        [TestMethod]
        public void ArticleAutoMapperTest()
        {
            var article = new Article("proveedor", "description", "name", 1.5);
            var config = new MapperConfiguration(c => c.CreateMap<Article, ArticleDTO>());
            var mapper = config.CreateMapper();
            var result = mapper.Map<ArticleDTO>(article);

            Assert.AreEqual(typeof(ArticleDTO), result.GetType());
            Assert.AreEqual(article.description, result.description);
        }

        [TestMethod]
        public void ArticleDTOAutoMapperTest()
        {
            var article = new ArticleDTO("description", "name", 1.5);
            var config = new MapperConfiguration(c => c.CreateMap<ArticleDTO, Article>());
            var mapper = config.CreateMapper();
            var result = mapper.Map<Article>(article);

            Assert.AreEqual(typeof(Article), result.GetType());
            Assert.AreEqual(article.description, result.description);
        }
    }
}
