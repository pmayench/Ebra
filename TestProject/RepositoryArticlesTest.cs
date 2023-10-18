using Ebra.Models.Models;
using Ebra.Models.Interfaces;
using Ebra.Models.Exceptions;

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
