using Ebra.App.Exceptions;
using Ebra.App.Repositories;
using Ebra.Models.Models;

namespace TestProject
{
    [TestClass]
    [TestCategory("Repositories")]
    public class RepositoryArticlesTest
    {
        [TestMethod]
        public void repositoryArticlesAddTest()
        {
            var repository = new MockRepositoryVersion();
            var target = repository.GetByType(typeof(Article));

            Assert.AreEqual("1.0", target.version);
        }

        [TestMethod]
        [ExpectedException(typeof(NotFoundVersionException))]
        public void repositoryOffersAddTest()
        {
            var repository = new MockRepositoryVersion();
            var target = repository.GetByType(typeof(Offer));

            Assert.AreEqual("1.0", target.version);
        }
    }

    
}
