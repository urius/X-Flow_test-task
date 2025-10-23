using Core;
using UnityEngine;

namespace Health
{
    [CreateAssetMenu(fileName = "HealthEntityInfo", menuName = "ScriptableObject/EntityInfo/HealthEntityInfo")]
    internal class HealthEntityInfo : EntityInfoBase<int>
    {
        public const string EntityKey = "Health";

        public override string Key => EntityKey;
        
        public override string GetStringValue()
        {
            return PlayerData.Instance.GetEntityValue<HealthEntityInfo, int>().ToString();
        }
    }
}