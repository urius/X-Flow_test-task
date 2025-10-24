using System;
using Shop.Bundles;

namespace Shop.Dispatcher
{
    internal class ShopDispatcher
    {
        public static ShopDispatcher Instance = new();

        public event Action<ShopBundle> BuyBundleStarted;
        public event Action<ShopBundle> BuyBundleFinished;

        public void DispatchBuyBundleStarted(ShopBundle bundle)
        {
            BuyBundleStarted?.Invoke(bundle);
        }

        public void DispatchBuyBundleFinished(ShopBundle bundle)
        {
            BuyBundleFinished?.Invoke(bundle);
        }
    }
}