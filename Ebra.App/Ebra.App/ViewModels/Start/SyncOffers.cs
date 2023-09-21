using System;
using Tamarack.Pipeline;

namespace Ebra.App.ViewModels.Start
{
    public class SyncOffers : IFilter<Context, Context>
    {
        public Context Execute(Context context, Func<Context, Context> executeNext)
        {
            callService(context);
            return executeNext(context);
        }

        private async void callService(Context context)
        {
            context.Offers = await context.OfferService.GetOffersAsync();
        }
    }
}