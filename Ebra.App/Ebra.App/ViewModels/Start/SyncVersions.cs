using System;
using Tamarack.Pipeline;

namespace Ebra.App.ViewModels.Start
{
    public class SyncVersions : IFilter<SyncroContexto, SyncroContexto>
    {
        public SyncroContexto Execute(SyncroContexto context, Func<SyncroContexto, SyncroContexto> executeNext)
        {
            callService(context);

            return executeNext(context);
        }

        private void callService(SyncroContexto context)
        {
            context.Articles = context.ArticleService.GetArticles();
        }
    }
}