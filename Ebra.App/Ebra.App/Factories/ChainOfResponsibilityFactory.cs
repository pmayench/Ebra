using Ebra.App.ViewModels.Start;
using Tamarack.Pipeline;

namespace Ebra.App.Factories
{
    public static class ChainOfResponsibilityFactory
    {
        public static IPipeline<ISyncroContext, ISyncroContext> CreateCORSyncro()
        {
            IPipeline<ISyncroContext, ISyncroContext> pipeline = new Pipeline<ISyncroContext, ISyncroContext>()
            .Add(new SyncArticles())
            //.Add(new SyncOffers())
            //.Add(new SyncOrders())
            .Finally(context => context);

            return pipeline;
        }
    }
}
