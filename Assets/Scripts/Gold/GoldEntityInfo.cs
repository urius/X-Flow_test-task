using Core;
using UnityEngine;

namespace Gold
{
    [CreateAssetMenu(fileName = "GoldEntityInfo", menuName = "ScriptableObject/EntityInfo/GoldEntityInfo")]
    internal class GoldEntityInfo : EntityInfoBase
    {
        public const string EntityKey = "Gold";

        public override bool IsUnique => false;
        public override string Key => EntityKey;
        
        public override string FormatValue(string valueStr)
        {
            return string.IsNullOrEmpty(valueStr) ? "0" : valueStr;
        }
    }
}
