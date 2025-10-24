using System.Collections.Generic;
using System.Linq;
using Core;
using UnityEngine;

namespace Shop.Bundles
{
    [CreateAssetMenu(fileName = "ShopBundle", menuName = "ScriptableObject/Shop/ShopBundle")]
    internal class ShopBundle : ScriptableObject
    {
        [SerializeField] private string _title;
        [SerializeField] private EntityActionBase[] _actions;

        public string Title => _title;
        public IReadOnlyList<EntityActionBase> Actions => _actions;
        
        public bool IsValid()
        {
            for (var i = 0; i < _actions.Length; i++)
            {
                for (var j = i + 1; j < _actions.Length; j++)
                {
                    if (_actions[i].EntityKey == _actions[j].EntityKey)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public bool CanBuy()
        {
            return IsValid() && _actions.All(action => action.CanPerform());
        }
    }
}