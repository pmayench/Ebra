using System;
using Tamarack.Pipeline;

namespace Ebra.App.ViewModels.Start
{
    public class SyncVersions : IFilter<SyncroContext, SyncroContext>
    {
        public SyncroContext Execute(SyncroContext context, Func<SyncroContext, SyncroContext> executeNext)
        {
            callService(context);

            return executeNext(context);
        }

        private void callService(SyncroContext context)
        {
            context.Articles = context.ArticleService.GetArticles();
        }
    }
}