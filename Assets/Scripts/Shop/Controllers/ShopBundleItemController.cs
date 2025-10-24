using Core;
using Shop.Bundles;
using Shop.Managers;
using Shop.Model;
using Shop.Services;
using Shop.Views;

namespace Shop.Controllers
{
    internal class ShopBundleItemController : IController
    {
        protected readonly IBundleItemView BundleView;
        protected readonly ShopBundle BundleData;
        
        private readonly ShopStateModel _shopStateModel = ShopStateModel.Instance;
        private readonly PlayerData _playerData = PlayerData.Instance;
        
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
            UpdateBuyButtonState();
        }

        private void Subscribe()
        {
            BundleView.BuyButtonClicked += OnBuyButtonClicked;
            BundleView.InfoButtonClicked += OnInfoButtonClicked;
            _shopStateModel.ProcessBundleStateChanged += OnProcessBundleStateChanged;
            _playerData.ValueChanged += OnPlayerDataValueChanged;
        }

        private void Unsubscribe()
        {
            BundleView.BuyButtonClicked -= OnBuyButtonClicked;
            BundleView.InfoButtonClicked -= OnInfoButtonClicked;
            _shopStateModel.ProcessBundleStateChanged -= OnProcessBundleStateChanged;
            _playerData.ValueChanged -= OnPlayerDataValueChanged;
        }

        private void OnProcessBundleStateChanged()
        {
            UpdateBuyButtonState();
        }

        private void OnPlayerDataValueChanged(string key)
        {
            UpdateBuyButtonState();
        }

        private async void OnBuyButtonClicked()
        {
            await ShopBundleService.Instance.ProcessBuyBundle(BundleData);
        }

        private void OnInfoButtonClicked()
        {
            SceneTransitionManager.Instance.SwitchToViewBundleScene(BundleData);
        }

        private void UpdateBuyButtonState()
        {
            var currentBundleProcessing = _shopStateModel.CurrentProcessingBundle;
            
            if (currentBundleProcessing != null)
            {
                if (currentBundleProcessing == BundleData)
                {
                    BundleView.SetBuyButtonProcessingMode();
                }
                else
                {
                    BundleView.SetBuyButtonNotAvailableMode();
                }
            }
            else if (BundleData.CanBuy())
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