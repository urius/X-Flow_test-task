using System;
using UnityEngine;
using UnityEngine.UI;

namespace Shop.Views
{
    internal class SimpleButtonView : MonoBehaviour, ISimpleButtonView
    {
        public event Action Click;

        [SerializeField] private Button _button;
        
        private void Awake()
        {
            _button.onClick.AddListener(OnInnerButtonClick);
        }

        private void OnInnerButtonClick()
        {
            Click?.Invoke();
        }
    }
}