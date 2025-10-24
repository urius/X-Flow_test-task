using System;
using Core;
using UnityEngine;

namespace Shop.Presenters
{
    [Serializable]
    internal class TopBarCanvasPresenterItemSetting
    {
        [SerializeField] private EntityInfoBase _displayEntityInfo;
        [SerializeField] private EntityActionBase _buttonAction;

        public EntityInfoBase DisplayEntityInfo => _displayEntityInfo;
        public EntityActionBase ButtonAction => _buttonAction;
    }
}