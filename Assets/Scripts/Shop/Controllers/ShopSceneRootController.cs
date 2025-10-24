using System.Collections.Generic;
using Shop.Bundles;
using Shop.Views;

namespace Shop.Controllers
{
    internal class ShopSceneRootController : IController
    {
        private readonly IBundlesCanvasView _bundlesCanvasView;
        private readonly ShopBundle[] _bundlesData;
        private readonly List<IController> _subControllers = new();

        public ShopSceneRootController(IBundlesCanvasView bundlesCanvasView, ShopBundle[] bundlesData)
        {
            _bundlesCanvasView = bundlesCanvasView;
            _bundlesData = bundlesData;
        }

        public void Start()
        {
            CreateBundleControllers();
        }

        public void Stop()
        {
            foreach (var controller in _subControllers)
            {
                controller.Stop();
            }
            
            _subControllers.Clear();
        }

        private void CreateBundleControllers()
        {
            foreach (var shopBundle in _bundlesData)
            {
                if (shopBundle.IsValid() == false) continue;
                
                var bundleView = _bundlesCanvasView.CreateNewBundleItemView();

                var bundleItemController = new ShopBundleItemController(bundleView, shopBundle);
                bundleItemController.Start();
                
                _subControllers.Add(bundleItemController);
            }
        }
    }
}