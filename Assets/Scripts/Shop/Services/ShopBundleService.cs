using System;
using System.Threading.Tasks;
using Shop.Bundles;
using Shop.Model;

namespace Shop.Services
{
    internal class ShopBundleService
    {
        public static readonly ShopBundleService Instance = new();

        public async Task ProcessBuyBundle(ShopBundle bundleData)
        {
            ShopStateModel.Instance.SetBundleProcessing(bundleData);
            
            await Task.Delay(new TimeSpan(hours: 0, minutes: 0, seconds: 3));

            PerformBundleActions(bundleData);
            
            ShopStateModel.Instance.SetBundleProcessingFinished();
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