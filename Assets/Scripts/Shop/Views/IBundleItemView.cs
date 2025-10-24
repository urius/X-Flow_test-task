using System;

namespace Shop.Views
{
    internal interface IBundleItemView
    {
        public event Action InfoButtonClicked;
        public event Action BuyButtonClicked;

        public void SetBundleText(string text);
        public void SetBuyButtonAvailableMode();
        public void SetBuyButtonNotAvailableMode();
        public void SetBuyButtonProcessingMode();
        public void SetInfoButtonVisibility(bool isVisible);
    }
}