using Tamarack.Pipeline;
using Ebra.Models.Services;
using Ebra.App.ViewModels.Start;
using Ebra.Models.Interfaces;
using Ebra.Models.Models;
using Moq;
using Ebra.App.Factories;

namespace TestProject
{
    [TestClass]
    [TestCategory("Patterns")]
    public class PatternChainOfResponibilityTest
    {
        [TestMethod]
        public void CORBasic()
        {
            var contexto = new SyncroContext(new MockOfferService(), new MockArticleService(), new MockOrderService(), new MockRepositoryVersion(), new MockArticleRepository(), null);
            var pipeline = new Pipeline<ISyncroContext, ISyncroContext>()
            .Add(new SyncArticles())
            .Add(new SyncOffers())
            .Add(new SyncOrders())
            .Finally(context => context);

            var response = pipeline.Execute(contexto);

            Assert.IsNotNull(response);
        }
    }

    [TestClass]
    [TestCategory("Services")]
    public class SyncArticlesTest
    {
        [TestMethod]
        public void SameArticleVersion()
        {
            var mockRepositoryVersion = new MockRepositoryVersion();
            mockRepositoryVersion.Insert(new VersionEntity
            {
                type = typeof(Article),
                version = "1.0"
            });

            var mockArticleService = new Mock<IArticleService>();
            mockArticleService.Setup(x => x.GetVersion(typeof(Article))).Returns("1.0");
            

            var context = new SyncroContext(new MockOfferService(), mockArticleService.Object, new MockOrderService(), mockRepositoryVersion, new MockArticleRepository(), null);
            var target = new SyncArticles();
            target.Execute(context, funcion);


            //Assert.AreEqual(1, context.Articles.Count() );
            Assert.AreEqual("1.0", context.VersionEntityRepository.GetByType(typeof(Article)).version);

        }


        [TestMethod]
        public void DifferentArticleVersion()
        {
            var mockRepositoryVersion = new MockRepositoryVersion();
            mockRepositoryVersion.Insert(new VersionEntity
            {
                type = typeof(Article),
                version = "1.0"
            });

            var mockArticleService = new Mock<IArticleService>();
            mockArticleService.Setup(x => x.GetVersion(typeof(Article))).Returns("2.0");

            mockArticleService.Setup(x => x.GetArticles()).Returns(new List<Article>() { new Article("a", "b", 1.5)});

            var context = new SyncroContext(new MockOfferService(), mockArticleService.Object, new MockOrderService(), mockRepositoryVersion, new MockArticleRepository(), null);
            var target = new SyncArticles();
            target.Execute(context, funcion);


            Assert.AreEqual(1, context.Articles.Count());
            Assert.AreEqual("2.0", context.VersionEntityRepository.GetByType(typeof(Article)).version);
            Assert.AreEqual(1, context.ArticleRepository.GetAll().Count());

        }

        private ISyncroContext funcion(ISyncroContext c)
        { return c;

        }
    }

}