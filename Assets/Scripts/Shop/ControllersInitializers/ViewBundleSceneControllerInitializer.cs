using Shop.Controllers;
using Shop.Views;
using UnityEngine;

namespace Shop.ControllersInitializers
{
    internal class ViewBundleSceneControllerInitializer : MonoBehaviour
    {
        [SerializeField] private SimpleButtonView _backButton;
        [SerializeField] private BundleItemView _bundlesItemView;

        private ViewBundleSceneRootController _rootController;
        
        private void Start()
        {
            _rootController = new ViewBundleSceneRootController(_bundlesItemView, _backButton);
            _rootController.Start();
        }

        private void OnDestroy()
        {
            _rootController.Stop();
        }
    }
}