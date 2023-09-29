using Ebra.App.Factories;
using System;
using Tamarack.Pipeline;

namespace Ebra.App.ViewModels.Start
{
    public class SyncOrders : IFilter<ISyncroContext, ISyncroContext>
    {
        public ISyncroContext Execute(ISyncroContext context, Func<ISyncroContext, ISyncroContext> executeNext)
        {
            callService(context);
            return executeNext(context);
        }

        private async void callService(ISyncroContext context)
        {
            context.Orders = await context.OrderService.GetOrdersAsync();
        }
    }
}