using Shop.Data;
using Shop.Views;

namespace Shop.Controllers
{
    internal class ViewBundleItemController : ShopBundleItemController
    {
        public ViewBundleItemController(IBundleItemView bundleView) 
            : base(bundleView, ViewBundleSceneParams.Instance.TargetBundle)
        {
        }

        protected override void SetupView()
        {
            BundleView.SetInfoButtonVisibility(false);
            
            base.SetupView();
        }
    }
}