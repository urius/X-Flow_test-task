using Shop.Bundles;
using Shop.Data;
using UnityEngine.SceneManagement;

namespace Shop.Managers
{
    internal class SceneTransitionManager
    {
        public static readonly SceneTransitionManager Instance = new();

        public void SwitchToViewBundleScene(ShopBundle targetBundle)
        {
            ViewBundleSceneParams.Instance.TargetBundle = targetBundle;

            SceneManager.LoadScene("Scenes/ViewBundleScene");
        }
        
        public void SwitchToShopScene()
        {
            ViewBundleSceneParams.Instance.TargetBundle = null;

            SceneManager.LoadScene("Scenes/ShopScene");
        }
    }
}