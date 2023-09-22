using Ebra.App.Exceptions;
using Ebra.App.Models;
using System;
using System.Globalization;
using System.Threading.Tasks;
using Tamarack.Pipeline;

namespace Ebra.App.ViewModels.Start
{
    public class SyncArticles : IFilter<Context, Context>
    {
        public Context Execute(Context context, Func<Context, Context> executeNext)
        {
            string serviceVersion = null;
            try
            {
                serviceVersion = context.ArticleService.GetVersion(typeof(Article));
                var localVersion = context.VersionEntityRepository.GetByType(typeof(Article));

                if(serviceVersion == localVersion.version) return executeNext(context);

                populateArticles(context, serviceVersion);

            }
            catch (NotFoundVersionException ex)
            {
                populateArticles(context, serviceVersion);
            }
            catch (Exception)
            {
                throw;
            }
            return executeNext(context);
        }

        private void populateArticles(Context context, string serviceVersion)
        {
            callService(context);
            context.ArticleRepository.DeleteAll();
            context.ArticleRepository.AddRange(context.Articles);
            context.VersionEntityRepository.Insert(new VersionEntity
            {
                type = typeof(Article),
                version = serviceVersion
            });
        }

        private void callService(Context context)
        {
            context.Articles = context.ArticleService.GetArticles();
        }
    }

    public class SyncVersions : IFilter<Context, Context>
    {
        public Context Execute(Context context, Func<Context, Context> executeNext)
        {
            callService(context);

            return executeNext(context);
        }

        private void callService(Context context)
        {
            context.Articles = context.ArticleService.GetArticles();
        }
    }
}