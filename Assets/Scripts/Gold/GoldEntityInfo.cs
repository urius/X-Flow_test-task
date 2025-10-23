using Core;
using UnityEngine;

namespace Gold
{
    [CreateAssetMenu(fileName = "GoldEntityInfo", menuName = "ScriptableObject/EntityInfo/GoldEntityInfo")]
    internal class GoldEntityInfo : EntityInfoBase<int>
    {
        public const string EntityKey = "Gold";

        public override string Key => EntityKey;
        
        public override string GetStringValue()
        {
            return PlayerData.Instance.GetEntityValue<GoldEntityInfo, int>().ToString();
        }
    }
}
