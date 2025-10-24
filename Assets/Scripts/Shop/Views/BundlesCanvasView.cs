using UnityEngine;

namespace Shop.Views
{
    internal class BundlesCanvasView : MonoBehaviour, IBundlesCanvasView
    {
        [SerializeField] private BundleItemView _itemPrefab;
        [SerializeField] private Transform _contentTransform;

        public IBundleItemView CreateNewBundleItemView()
        {
            return Instantiate(_itemPrefab, _contentTransform);
        }
    }
}