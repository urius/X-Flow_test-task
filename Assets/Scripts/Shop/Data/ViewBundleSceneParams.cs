using Shop.Bundles;

namespace Shop.Data
{
    internal class ViewBundleSceneParams
    {
        public static ViewBundleSceneParams Instance = new();

        public ShopBundle TargetBundle;
    }
}