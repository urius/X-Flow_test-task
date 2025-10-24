using System.Collections.Generic;
using Shop.Controllers;
using Shop.Views;
using UnityEngine;

namespace Shop.ControllersInitializers
{
    internal class ResourcesBarControllerInitializer : MonoBehaviour
    {
        [SerializeField] private ResourcesBarItemSetting[] _items;
        [SerializeField] private ResourcesBarView _resourcesBarView;

        private readonly List<ResourcesBarItemController> _itemControllers = new();
        
        private void Awake()
        {
            CreateItemControllers();
        }

        private void OnDestroy()
        {
            foreach (var itemController in _itemControllers)
            {
                itemController.Stop();
            }

            _itemControllers.Clear();
        }

        private void CreateItemControllers()
        {
            foreach (var itemSetting in _items)
            {
                CreateItemController(itemSetting);
            }
        }

        private void CreateItemController(ResourcesBarItemSetting itemSetting)
        {
            var itemView = _resourcesBarView.CreateNewResourceItemView();
            
            var itemController = new ResourcesBarItemController(itemView, itemSetting);
            itemController.Start();
            
            _itemControllers.Add(itemController);
        }
    }
}