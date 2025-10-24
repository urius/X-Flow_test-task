using UnityEngine;

namespace Shop.Views
{
    public class ResourcesBarView : MonoBehaviour, IResourcesBarView
    {
        [SerializeField] private ResourceView _itemPrefab;

        public IResourceView CreateNewResourceItemView()
        {
            return Instantiate(_itemPrefab, transform);
        }
    }
}