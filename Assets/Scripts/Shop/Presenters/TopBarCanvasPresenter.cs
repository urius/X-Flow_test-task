using System.Collections.Generic;
using Shop.Views;
using UnityEngine;

namespace Shop.Presenters
{
    internal class TopBarCanvasPresenter : MonoBehaviour
    {
        [SerializeField] private TopBarCanvasPresenterItemSetting[] _items;
        [SerializeField] private ResourceView _itemPrefab;

        private readonly List<TopBarResourceItemPresenter> _resourceItemPresenters = new();
        
        private void Awake()
        {
            PresentItems();
        }

        private void OnDestroy()
        {
            foreach (var resourceItemPresenter in _resourceItemPresenters)
            {
                resourceItemPresenter.Dispose();
            }

            _resourceItemPresenters.Clear();
        }

        private void PresentItems()
        {
            foreach (var itemSetting in _items)
            {
                PresentItem(itemSetting);
            }
        }

        private void PresentItem(TopBarCanvasPresenterItemSetting itemSetting)
        {
            var itemView = Instantiate(_itemPrefab, transform);
            
            var presenter = new TopBarResourceItemPresenter();
            presenter.Present(itemView, itemSetting);
            
            _resourceItemPresenters.Add(presenter);
        }
    }
}