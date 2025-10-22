using System;
using UnityEngine;
using UnityEngine.UI;

namespace Shop.Views
{
    internal class ResourceView : MonoBehaviour
    {
        public event Action AddButtonClicked;
        
        [SerializeField] private Text _resourceDataText;
        [SerializeField] private Button _addButton;

        private string _resourceName = string.Empty;
        private string _resourceValue = string.Empty;

        private void Awake()
        {
            _addButton.onClick.AddListener(OnAddClick);
        }

        public void SetResourceName(string resourceName)
        {
            _resourceName = resourceName;
            UpdateResourceText();
        }

        public void SetResourceValue(string value)
        {
            _resourceValue = value;
            UpdateResourceText();
        }

        private void OnAddClick()
        {
            AddButtonClicked?.Invoke();
        }

        private void UpdateResourceText()
        {
            _resourceDataText.text = $"{_resourceName}:{_resourceValue}";
        }
    }
}