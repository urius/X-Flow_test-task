using Shop.Bundles;
using Shop.Controllers;
using Shop.Views;
using UnityEngine;

namespace Shop.ControllersInitializers
{
    internal class ShopSceneRootControllersInitializer : MonoBehaviour
    {
        [SerializeField] private BundlesCanvasView _bundlesCanvasView;
        [SerializeField] private ShopBundle[] _bundlesData;
        
        private ShopSceneRootController _rootController;

        private void Awake()
        {
            _rootController = new ShopSceneRootController(_bundlesCanvasView, _bundlesData);
            _rootController.Start();
        }

        private void OnDestroy()
        {
            _rootController.Stop();
            _rootController = null;
        }
    }
}