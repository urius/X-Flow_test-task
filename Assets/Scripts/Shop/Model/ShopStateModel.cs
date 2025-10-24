using System;
using Shop.Bundles;

namespace Shop.Model
{
    internal class ShopStateModel
    {
        public static ShopStateModel Instance = new ShopStateModel();

        public event Action ProcessBundleStateChanged;
        
        public ShopBundle CurrentProcessingBundle { get; private set; }

        public void SetBundleProcessing(ShopBundle bundle)
        {
            if (CurrentProcessingBundle == bundle) return;
            
            CurrentProcessingBundle = bundle;
            
            ProcessBundleStateChanged?.Invoke();
        }
        
        public void SetBundleProcessingFinished()
        {
            SetBundleProcessing(null);
        }
    }
}