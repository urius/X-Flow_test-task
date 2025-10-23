using System;
using Core;
using Shop.Views;

namespace Shop.Presenters
{
    internal class TopBarResourceItemPresenter : IDisposable
    {
        private readonly PlayerData _playerData = PlayerData.Instance;
        
        private ResourceView _resourceView;
        private TopBarCanvasPresenterItemSetting _itemSetting;

        public void Present(ResourceView resourceView, TopBarCanvasPresenterItemSetting itemSetting)
        {
            _resourceView = resourceView;
            _itemSetting = itemSetting;
            
            _resourceView.SetResourceName(_itemSetting.DisplayEntityInfo.EntityName);
            UpdateResourceValue();

            Subscribe();
        }

        public void Dispose()
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

        private void OnValueChanged(string entityKey)
        {
            if (entityKey == _itemSetting.DisplayEntityInfo.Key)
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