using System;
using UnityEngine;
using UnityEngine.UI;

namespace Shop.Views
{
    internal class BundleItemView : MonoBehaviour, IBundleItemView
    {
        public event Action InfoButtonClicked;
        public event Action BuyButtonClicked;

        private const string BuyStr = "Купить";
        private const string ProcessingStr = "Обработка...";
        
        [SerializeField] private Text _bundleText;
        [SerializeField] private Button _infoButton;
        [SerializeField] private Button _buyButton;
        [SerializeField] private Text _buyButtonText;

        private void Awake()
        {
            _infoButton.onClick.AddListener(OnInfoButtonClick);
            _buyButton.onClick.AddListener(OnBuyButtonClick);
        }

        public void SetBundleText(string text)
        {
            _bundleText.text = text;
        }

        public void SetBuyButtonAvailableMode()
        {
            _buyButtonText.text = BuyStr;
            SetBuyButtonInteractable(true);
        }
        
        public void SetBuyButtonNotAvailableMode()
        {
            _buyButtonText.text = BuyStr;
            SetBuyButtonInteractable(false);
        }
        
        public void SetBuyButtonProcessingMode()
        {
            _buyButtonText.text = ProcessingStr;
            SetBuyButtonInteractable(false);
        }

        public void SetInfoButtonVisibility(bool isVisible)
        {
            _infoButton.gameObject.SetActive(isVisible);
        }

        private void SetBuyButtonInteractable(bool interactable)
        {
            _buyButton.interactable = interactable;
        }

        private void OnInfoButtonClick()
        {
            InfoButtonClicked?.Invoke();
        }

        private void OnBuyButtonClick()
        {
            BuyButtonClicked?.Invoke();
        }
    }
}