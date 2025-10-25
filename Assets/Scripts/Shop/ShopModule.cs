using Core;
using Shop.Managers;
using UnityEngine;

namespace Shop
{
    [CreateAssetMenu(fileName = "ShopModule", menuName = "ScriptableObject/Modules/ShopModule")]
    public class ShopModule : ModuleBase
    {
        public override void Initialize()
        {
            SceneTransitionManager.Instance.SwitchToShopScene();
        }
    }
}