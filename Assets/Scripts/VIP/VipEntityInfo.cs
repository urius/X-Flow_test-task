using System;
using Core;
using UnityEngine;

namespace VIP
{
    [CreateAssetMenu(fileName = "VipEntityInfo", menuName = "ScriptableObject/EntityInfo/VipEntityInfo")]
    public class VipEntityInfo : EntityInfoBase<TimeSpan>
    {
        public const string EntityKey = "VIP";

        public override string Key => EntityKey;
        
        public override string GetStringValue()
        {
            var value = PlayerData.Instance.GetEntityValue<VipEntityInfo, TimeSpan>();
            
            return $"{value.TotalSeconds} сек";
        }
    }
}