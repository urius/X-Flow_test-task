using System;
using Core;
using Shop.ControllersInitializers;
using Shop.Views;

namespace Shop.Controllers
{
    internal class ResourcesBarItemController : IController
    {
        private readonly PlayerData _playerData = PlayerData.Instance;
        
        private readonly IResourceView _resourceView;
        private readonly ResourcesBarItemSetting _itemSetting;

        public ResourcesBarItemController(IResourceView resourceView, ResourcesBarItemSetting itemSetting)
        {
            _resourceView = resourceView;
            _itemSetting = itemSetting;
        }

        public void Start()
        {
            _resourceView.SetResourceName(_itemSetting.DisplayEntityInfo.EntityName);
            UpdateResourceValue();

            Subscribe();
        }

        public void Stop()
        {
            Unsubscribe();
        }

        private void UpdateResourceValue()
        {
            _resourceView.SetResourceValue(_itemSetting.DisplayEntityInfo.GetStringValue());
        }

        private void Subscribe()
        {
            _resourceView.AddButtonClicked += OnAddButtonClicked;
            _playerData.ValueChanged += OnValueChanged;
        }

        private void Unsubscribe()
        {           
            _resourceView.AddButtonClicked -= OnAddButtonClicked;
            _playerData.ValueChanged -= OnValueChanged;
        }

        private void OnValueChanged(Type entityType)
        {
            if (entityType == _itemSetting.DisplayEntityInfo.CashedType)
            {
                UpdateResourceValue();
            }
        }

        private void OnAddButtonClicked()
        {
            _itemSetting.ButtonAction.Perform();
        }
    }
}