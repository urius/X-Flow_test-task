using Core;
using Shop.Bundles;
using Shop.Dispatcher;
using Shop.Managers;
using Shop.Services;
using Shop.Views;

namespace Shop.Controllers
{
    internal class ShopBundleItemController : IController
    {
        protected readonly IBundleItemView BundleView;
        protected readonly ShopBundle BundleData;
        
        private readonly ShopDispatcher _shopDispatcher = ShopDispatcher.Instance;
        private readonly PlayerData _playerData = PlayerData.Instance;
        
        private bool _blockUpdateButtonState;

        public ShopBundleItemController(IBundleItemView bundleView, ShopBundle bundleData)
        {
            BundleView = bundleView;
            BundleData = bundleData;
        }

        public void Start()
        {
            SetupView();
            Subscribe();
        }

        public void Stop()
        {
            Unsubscribe();
        }

        protected virtual void SetupView()
        {
            BundleView.SetBundleText(BundleData.Title);
            UpdateButtonState();
        }

        private void Subscribe()
        {
            BundleView.BuyButtonClicked += OnBuyButtonClicked;
            BundleView.InfoButtonClicked += OnInfoButtonClicked;
            _shopDispatcher.BuyBundleStarted += OnBuyBundleStarted;
            _shopDispatcher.BuyBundleFinished += BuyBundleFinished;
            _playerData.ValueChanged += OnPlayerDataValueChanged;
        }

        private void Unsubscribe()
        {
            BundleView.BuyButtonClicked -= OnBuyButtonClicked;
            BundleView.InfoButtonClicked -= OnInfoButtonClicked;
            _shopDispatcher.BuyBundleStarted -= OnBuyBundleStarted;
            _shopDispatcher.BuyBundleFinished -= BuyBundleFinished;
            _playerData.ValueChanged -= OnPlayerDataValueChanged;
        }

        private void OnBuyBundleStarted(ShopBundle bundle)
        {
            if (BundleData == bundle)
            {
                BundleView.SetBuyButtonProcessingMode();
            }
            else
            {
                BundleView.SetBuyButtonNotAvailableMode();
            }

            _blockUpdateButtonState = true;
        }

        private void BuyBundleFinished(ShopBundle _)
        {
            _blockUpdateButtonState = false;
            UpdateButtonState();
        }

        private void OnPlayerDataValueChanged(string key)
        {
            UpdateButtonState();
        }

        private async void OnBuyButtonClicked()
        {
            await ShopBundleService.Instance.ProcessBuyBundle(BundleData);
        }

        private void OnInfoButtonClicked()
        {
            SceneTransitionManager.Instance.SwitchToViewBundleScene(BundleData);
        }

        private void UpdateButtonState()
        {
            if (_blockUpdateButtonState) return;
            
            if (BundleData.CanBuy())
            {
                BundleView.SetBuyButtonAvailableMode();
            }
            else
            {
                BundleView.SetBuyButtonNotAvailableMode();
            }
        }
    }
}