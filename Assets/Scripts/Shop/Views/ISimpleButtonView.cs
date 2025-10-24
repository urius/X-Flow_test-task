using System;

namespace Shop.Views
{
    internal interface ISimpleButtonView
    {
        public event Action Click;
    }
}