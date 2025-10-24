using System;
using System.Threading.Tasks;
using Shop.Bundles;
using Shop.Dispatcher;

namespace Shop.Services
{
    internal class ShopBundleService
    {
        public static readonly ShopBundleService Instance = new();

        public async Task ProcessBuyBundle(ShopBundle bundleData)
        {
            ShopDispatcher.Instance.DispatchBuyBundleStarted(bundleData);
            
            await Task.Delay(new TimeSpan(hours: 0, minutes: 0, seconds: 3));

            PerformBundleActions(bundleData);
            
            ShopDispatcher.Instance.DispatchBuyBundleFinished(bundleData);
        }

        private static void PerformBundleActions(ShopBundle bundleData)
        {
            foreach (var action in bundleData.Actions)
            {
                action.Perform();
            }
        }
    }
}