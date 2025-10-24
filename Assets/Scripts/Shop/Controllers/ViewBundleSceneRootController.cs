using Shop.Managers;
using Shop.Views;

namespace Shop.Controllers
{
    internal class ViewBundleSceneRootController : IController
    {
        private readonly IBundleItemView _bundleItemView;
        private readonly ISimpleButtonView _backButtonView;

        private ViewBundleItemController _viewBundleItemController;
        
        public ViewBundleSceneRootController(IBundleItemView bundleItemView, ISimpleButtonView backButtonView)
        {
            _bundleItemView = bundleItemView;
            _backButtonView = backButtonView;
        }

        public void Start()
        {
            _viewBundleItemController = new ViewBundleItemController(_bundleItemView);
            _viewBundleItemController.Start();

            Subscribe();
        }

        public void Stop()
        {
            Unsubscribe();
            
            _viewBundleItemController.Stop();
            _viewBundleItemController = null;
        }

        private void Subscribe()
        {
            _backButtonView.Click += OnBackButtonClick;
        }

        private void Unsubscribe()
        {
            _backButtonView.Click -= OnBackButtonClick;
        }

        private void OnBackButtonClick()
        {
            SceneTransitionManager.Instance.SwitchToShopScene();
        }
    }
}