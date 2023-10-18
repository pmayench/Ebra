using Ebra.App.Exceptions;
using Ebra.App.Factories;
using Ebra.Models.Models;
using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Tamarack.Pipeline;

namespace Ebra.App.ViewModels.Start
{
    public class SyncArticles : IFilter<ISyncroContext, ISyncroContext>
    {
        public ISyncroContext Execute(ISyncroContext context, Func<ISyncroContext, ISyncroContext> executeNext)
        {
            string serviceVersion = null;
            try
            {
                serviceVersion = context.ArticleService.GetVersion(typeof(Article));
                var localVersion = context.VersionEntityRepository.GetByType(typeof(Article));

                if(serviceVersion == localVersion.version)
                {
                    context.Articles = context.ArticleRepository.GetAll().ToList();

                    return executeNext(context);
                }

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

        private void populateArticles(ISyncroContext context, string serviceVersion)
        {
            callService(context);
            context.GenericRepository.DeleteAll();

            context.GenericRepository.AddRange(context.Articles);
            context.VersionEntityRepository.Insert(new VersionEntity
            {
                type = typeof(Article),
                version = serviceVersion
            });
        }

        private void callService(ISyncroContext context)
        {
            context.Articles = context.ArticleService.GetArticles();
        }

        //private void populateArticles(ISyncroContext context, string serviceVersion)
        //{
        //    callService(context);
        //    context.ArticleRepository.DeleteAll();

        //    context.ArticleRepository.AddRange(context.Articles);
        //    context.VersionEntityRepository.Insert(new VersionEntity
        //    {
        //        type = typeof(Article),
        //        version = serviceVersion
        //    });
        //}
    }
}