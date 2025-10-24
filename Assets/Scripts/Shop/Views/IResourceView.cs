using System;

namespace Shop.Views
{
    public interface IResourceView
    {
        public event Action AddButtonClicked;
        
        public void SetResourceName(string resourceName);
        public void SetResourceValue(string value);

    }
}